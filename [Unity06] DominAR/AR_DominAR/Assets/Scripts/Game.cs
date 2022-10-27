using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    static public Game instance { get; private set; }

    public ARRaycastManager arRaycastManager;

    public Notice notice;
    public Slider rotationBar, scaleBar;

    public GameObject dominoPrefab;
    private List<Domino> dominoes = new List<Domino>();

    private Vector2 screenCenterPos;

    public Domino selectedDomino { get; private set; }
    public Color selectedColor { get; private set; } = Color.black;
    public float rotation { get; private set; } = 0f;
    public float scale { get; private set; } = 1f;
    public bool isTemp { get; private set; } = true;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        screenCenterPos =
            new Vector2(Screen.width / 2f, Screen.height / 2f);
    }

    private void Update()
    {
        if (selectedDomino == null)
        {
            Update_None();
        }
        else
        {
            if (isTemp)
                Update_Temp();
            else
                Update_Formal();
        }
    }

    private void Update_None()
    {
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPos);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, LayerMask.GetMask("Domino")))
        {
            Domino domino = hit.collider.GetComponent<Domino>();
            if (domino != null)
            {
                selectedDomino = domino;
                selectedDomino.select = Domino.Select.Temp;
                isTemp = true;
            }
        }
    }

    private void Update_Temp()
    {
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPos);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, LayerMask.GetMask("Domino")))
        {
            Domino domino = hit.collider.GetComponent<Domino>();
            if (domino != null)
            {
                if (domino != selectedDomino)
                {
                    selectedDomino.select = Domino.Select.None;
                    selectedDomino = domino;
                    selectedDomino.select = Domino.Select.Temp;
                }
            }
            else
            {
                selectedDomino.select = Domino.Select.None;
                selectedDomino = null;
            }
        }
        else
        {
            selectedDomino.select = Domino.Select.None;
            selectedDomino = null;
        }
    }

    private void Update_Formal()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (arRaycastManager.Raycast(
                screenCenterPos, hits, TrackableType.PlaneWithinPolygon))
        {
            ARPlane plane = hits[0].trackable.GetComponent<ARPlane>();
            if (plane != null)
            {
                selectedDomino.transform.position =
                    hits[0].pose.position + Vector3.up * selectedDomino.transform.localScale.y / 2f;
            }
        }
        else
        {
            selectedDomino.transform.position =
                Camera.main.transform.position + Camera.main.transform.forward * 1f;
        }
    }

    public void CreateDomino()
    {
        if (selectedDomino == null)
        {
            Vector3 pos =
                Camera.main.transform.position + Camera.main.transform.forward * 1f;
            Domino domino =
                Domino.InstantiateDomino(dominoPrefab, pos, rotation, scale, selectedColor);

            if (domino != null)
            {
                selectedDomino = domino;
                selectedDomino.select = Domino.Select.Formal;
                isTemp = false;
            }
        }
        else
        {
            if (isTemp)
            {
                float tempRotation = selectedDomino.rotation;
                float tempScale = selectedDomino.scale;
                Color tempColor = selectedDomino.color;

                selectedDomino.select = Domino.Select.None;
                selectedDomino = null;

                Vector3 pos =
                    Camera.main.transform.position + Camera.main.transform.forward * 1f;
                Domino domino =
                    Domino.InstantiateDomino(dominoPrefab, pos, tempRotation, tempScale, tempColor);

                if (domino != null)
                {
                    selectedDomino = domino;
                    selectedDomino.select = Domino.Select.Formal;
                    isTemp = false;
                }
            }
            else
            {
                if (notice != null)
                    notice.Notify("이미 도미노가 생성 되었습니다.");
            }
        }
    }

    public void DeleteDomino()
    {
        if (selectedDomino == null)
        {
            if (notice != null)
                notice.Notify("제거할 도미노가 없습니다.");
        }
        else
        {
            if (isTemp)
                dominoes.Remove(selectedDomino);

            Destroy(selectedDomino.gameObject);
            selectedDomino = null;

            if (notice != null)
                notice.Notify("도미노가 제거 되었습니다.");
        }
    }

    public void SelectDomino()
    {
        if (selectedDomino != null)
        {
            if (isTemp)
            {
                isTemp = false;
                selectedDomino.select = Domino.Select.Formal;
                selectedDomino.SetSelect();
            }
            else
            {
                if (notice != null)
                    notice.Notify("이미 선택된 도미노가 있습니다..");
            }
        }
        else
        {
            if (notice != null)
                notice.Notify("선택할 도미노가 없습니다.");
        }
    }

    public void PlaceDomino()
    {
        if (selectedDomino == null)
        {
            if (notice != null)
                notice.Notify("이곳에 놓을 도미노가 없습니다.");
        }
        else
        {
            if (isTemp)
            {
                if (notice != null)
                    notice.Notify("이곳에 놓을 도미노가 없습니다.");
            }
            else
            {
                if (selectedDomino.PlaceEnable())
                {
                    List<ARRaycastHit> hits = new List<ARRaycastHit>();
                    if (arRaycastManager.Raycast(
                            screenCenterPos, hits, TrackableType.PlaneWithinPolygon))
                    {
                        ARPlane plane = hits[0].trackable.GetComponent<ARPlane>();
                        if (plane != null)
                        {
                            dominoes.Add(selectedDomino);
                            selectedDomino.select = Domino.Select.None;
                            selectedDomino.SetPlace();
                            selectedDomino = null;
                        }
                    }
                }
                else
                {
                    if (notice != null)
                        notice.Notify("이곳에는 도미노를 놓을 수 없습니다.");
                }
            }
        }
    }

    public void SetDominoColor(string color)
    {
        Color tempColor = selectedColor;

        if (color == "Black")
            tempColor = Color.black;
        else if (color == "Red")
            tempColor = Color.red;
        else if (color == "Yellow")
            tempColor = Color.yellow;
        else if (color == "Green")
            tempColor = Color.green;
        else if (color == "Blue")
            tempColor = Color.blue;
        else if (color == "Magenta")
            tempColor = Color.magenta;
        else if (color == "White")
            tempColor = Color.white;

        if (selectedDomino == null)
        {
            selectedColor = tempColor;
        }
        else
        {
            selectedDomino.color = tempColor;

            if (!isTemp)
                selectedColor = tempColor;
        }
    }

    public void ForceDomino()
    {
        if (selectedDomino == null)
        {
            if (notice != null)
                notice.Notify("쓰러뜨릴 도미노가 없습니다.");
        }
        else
        {
            if (isTemp)
            {
                Vector3 origin = Camera.main.transform.position;
                Vector3 direction = Camera.main.transform.forward;
                if (Physics.Raycast(origin, direction, out RaycastHit hit, 100f))
                {
                    Domino domino = hit.collider.GetComponent<Domino>();
                    if (domino == selectedDomino)
                    {
                        float dot =
                            Vector3.Dot(selectedDomino.transform.up.normalized, Vector3.up);
                        if (Mathf.Cos(Mathf.PI / 4f) <= dot && dot <= 1f)
                        {
                            selectedDomino.AddForce(hit.normal);
                        }
                        else
                        {
                            if (notice != null)
                                notice.Notify("도미노가 이미 쓰러져 있습니다.");
                        }
                    }
                }
            }
            else
            {
                if (notice != null)
                    notice.Notify("선택한 도미노를 적절한 위치에 놓아주세요.");
            }
        }
    }

    public void ClearDominoes()
    {
        if (dominoes.Count > 0)
        {
            foreach (Domino domino in dominoes)
                Destroy(domino.gameObject);
            dominoes.Clear();
            if (notice != null)
                notice.Notify("모든 도미노가 제거되었습니다.");
        }
        else
        {
            if (notice != null)
                notice.Notify("제거할 도미노가 없습니다.");
        }
    }

    public void SetRotation()
    {
        if (selectedDomino == null)
        {
            if (rotationBar != null)
                rotation = rotationBar.value;
        }
        else
        {
            if (isTemp)
            {
                float dot = Vector3.Dot(selectedDomino.transform.up.normalized, Vector3.up);
                if (Mathf.Cos(Mathf.PI / 36f) <= dot && dot <= 1f)
                {
                    if (rotationBar != null)
                    {
                        selectedDomino.rotation = rotationBar.value;
                        selectedDomino.transform.rotation =
                            Quaternion.Euler(0f, selectedDomino.rotation, 0f);
                        if (!isTemp)
                            rotation = rotationBar.value;
                    }
                }
                else
                {
                    if (notice != null)
                        notice.Notify("도미노가 쓰러져 있어 회전할 수 없습니다.");
                }
            }
            else
            {
                if (rotationBar != null)
                {
                    selectedDomino.rotation = rotationBar.value;
                    selectedDomino.transform.rotation =
                        Quaternion.Euler(0f, selectedDomino.rotation, 0f);
                    if (!isTemp)
                        rotation = rotationBar.value;
                }
            }
        }
    }

    public void SetScale()
    {
        if (selectedDomino == null)
        {
            if (scaleBar != null)
                scale = scaleBar.value;
        }
        else
        {
            if (isTemp)
            {
                float dot = Vector3.Dot(selectedDomino.transform.up.normalized, Vector3.up);
                if (Mathf.Cos(Mathf.PI / 36f) <= dot && dot <= 1f)
                {
                    if (rotationBar != null)
                    {
                        selectedDomino.scale = scaleBar.value;
                        selectedDomino.transform.localScale =
                            selectedDomino.defaultScale * selectedDomino.scale;
                        if (!isTemp)
                            scale = scaleBar.value;
                    }
                }
                else
                {
                    if (notice != null)
                        notice.Notify("도미노가 쓰러져 있어 크기를 조절할 수 없습니다.");
                }
            }
            else
            {
                if (scaleBar != null)
                {
                    selectedDomino.scale = scaleBar.value;
                    selectedDomino.transform.localScale =
                        selectedDomino.defaultScale * selectedDomino.scale;
                    if (!isTemp)
                        scale = scaleBar.value;
                }
            }
        }
    }

    public void StandDominoes()
    {
        if (dominoes.Count < 1)
        {
            if (notice != null)
                notice.Notify("세울 도미노가 없습니다.");
            return;
        }

        bool isAllStood = true;

        foreach (Domino domino in dominoes)
        {
            float dot = Vector3.Dot(domino.transform.up.normalized, Vector3.up);
            if(dot < Mathf.Cos(Mathf.PI / 36f) || 1f < dot)
                isAllStood = false;

            domino.transform.position = domino.position;
            domino.transform.rotation = Quaternion.Euler(0f, domino.rotation, 0f);
        }

        if (isAllStood)
        {
            if (notice != null)
                notice.Notify("모든 도미노가 세워져 있습니다.");
        }
        else
        {
            if (notice != null)
                notice.Notify("모든 도미노를 세웠습니다.");
        }
    }

    public void GoHome()
    {
        SceneManager.LoadScene("Start");
    }
}
