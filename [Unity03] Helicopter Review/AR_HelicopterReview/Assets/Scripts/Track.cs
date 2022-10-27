using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Track : MonoBehaviour
{
    public ARTrackedImageManager manager;
    public Helicopter helicopter;
    public GameObject platform;

    private Vector3 imagePos = Vector3.zero;
    private Quaternion imageRot = Quaternion.identity;
    private Vector3 accumulativePos = Vector3.zero;
    private Quaternion accumulativeRot = Quaternion.identity;

    private Vector3 clickMousePos;

    private void OnEnable()
    {
        if (manager != null)
        {
            manager.trackedImagesChanged += OnChanged;
        }
    }

    private void OnDisable()
    {
        if (manager != null)
        {
            manager.trackedImagesChanged -= OnChanged;
        }
    }

    private void Update()
    {
        if (helicopter == null)
        {
            return;
        }

        if (helicopter.isTurnedOn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickMousePos = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0)
                && Screen.width * 5f / 100f < clickMousePos.x
                && clickMousePos.x < Screen.width * (1f - 5f / 100f)
                && Screen.height * 5f / 100f < clickMousePos.y
                && clickMousePos.y < Screen.height * (1f - 5f / 100f))
            {
                if (Input.mousePosition.y - clickMousePos.y > Screen.height / 10f
                    && helicopter.transform.position.y < imagePos.y + 1f)
                {
                    accumulativePos += Vector3.up * 0.1f * Time.deltaTime;
                }
                else if (Input.mousePosition.y - clickMousePos.y < -Screen.height / 10f
                    && helicopter.transform.position.y > imagePos.y)
                {
                    accumulativePos -= Vector3.up * 0.1f * Time.deltaTime;
                }

                if (Input.mousePosition.x - clickMousePos.x > Screen.width / 10f)
                {
                    accumulativeRot *= Quaternion.Euler(0f, -30f * Time.deltaTime, 0f);
                }
                else if (Input.mousePosition.x - clickMousePos.x < -Screen.width / 10f)
                {
                    accumulativeRot *= Quaternion.Euler(0f, 30f * Time.deltaTime, 0f);
                }
            }
        }
        else
        {
            if (helicopter.transform.position.y > imagePos.y)
            {
                if (helicopter.mainBladeSpeed > 1500f)
                {
                    accumulativePos -= Vector3.up * 0.01f * Time.deltaTime;
                }
                else if (helicopter.mainBladeSpeed > 1000f)
                {
                    accumulativePos -= Vector3.up * 0.05f * Time.deltaTime;
                }
                else if (helicopter.mainBladeSpeed > 500f)
                {
                    accumulativePos -= Vector3.up * 0.3f * Time.deltaTime;
                }
                else
                {
                    accumulativePos -= Vector3.up * 0.5f * Time.deltaTime;
                }
            }
        }

        helicopter.transform.position = imagePos + accumulativePos;
        helicopter.transform.rotation = imageRot * accumulativeRot;
    }

    private void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage t in eventArgs.added)
        {
            UpdateImage(t);
        }

        foreach (ARTrackedImage t in eventArgs.updated)
        {
            UpdateImage(t);
        }
    }

    private void UpdateImage(ARTrackedImage t)
    {
        if (helicopter != null)
        {
            imagePos = t.transform.position;
            imageRot = t.transform.rotation;
            helicopter.gameObject.SetActive(true);
        }

        if (platform != null)
        {
            platform.transform.position = t.transform.position;
            platform.transform.rotation = t.transform.rotation;
            platform.SetActive(true);
        }
    }
}
