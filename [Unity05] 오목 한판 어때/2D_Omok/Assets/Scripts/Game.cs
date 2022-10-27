using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Game : MonoBehaviour {
    public enum Place { Null, Restrict, Black, White }

    [SerializeField] RectTransform canvasRT;
    [SerializeField] GameObject middleCanvas;

    [SerializeField] GameObject blackStone;
    [SerializeField] GameObject whiteStone;
    [SerializeField] GameObject redCross;
    [SerializeField] RectTransform indicator;

    [SerializeField] RectTransform blackArea;
    [SerializeField] RectTransform whiteArea;

    [SerializeField] RectTransform blackPlaceButton;
    [SerializeField] RectTransform whitePlaceButton;

    [SerializeField] RectTransform blackWinImage;
    [SerializeField] RectTransform blackDefeatImage;
    [SerializeField] RectTransform whiteWinImage;
    [SerializeField] RectTransform whiteDefeatImage;

    Place[,] places = new Place[15, 15];
    Vector3[,] points = new Vector3[15, 15];
    List<GameObject> stones = new List<GameObject>();
    List<GameObject> redCrosses = new List<GameObject>();

    bool isBlackTurn = true;
    bool isGameOver = false;

    int x = 7, y = 7;

    void Start() {
        for (var i = 0; i < 15; i++) {
            for (var j = 0; j < 15; j++) {
                places[i, j] = Place.Null;
            }
        }

        for (var i = 0; i < 15; i++) {
            for (var j = 0; j < 15; j++) {
                points[i, j] =
                    new Vector3(72 * (i - 7), 72 * (j - 7), 0f);
            }
        }

        if (canvasRT != null) {
            var height = (canvasRT.rect.height - 1080f) / 2f;

            if (blackArea != null) {
                blackArea.sizeDelta = new Vector2(canvasRT.rect.width, height);

                if (blackPlaceButton != null) {
                    blackPlaceButton.anchoredPosition = new Vector2(0f,
                        height / 2f - blackPlaceButton.rect.height / 2f);
                }

                if (blackWinImage != null) {
                    blackWinImage.anchoredPosition = new Vector2(0f,
                            height / 2f - blackWinImage.rect.height / 2f);
                }

                if (blackDefeatImage != null) {
                    blackDefeatImage.anchoredPosition = new Vector2(0f,
                        height / 2f - blackDefeatImage.rect.height / 2f);
                }
            }

            if (whiteArea != null) {
                whiteArea.sizeDelta = new Vector2(canvasRT.rect.width, height);

                if (whitePlaceButton != null) {
                    whitePlaceButton.anchoredPosition = new Vector2(0f,
                        -(height / 2f - whitePlaceButton.rect.height / 2f));
                }

                if (whiteWinImage != null) {
                    whiteWinImage.anchoredPosition = new Vector2(0f,
                            -(height / 2f - whiteWinImage.rect.height / 2f));
                }

                if (whiteDefeatImage != null) {
                    whiteDefeatImage.anchoredPosition = new Vector2(0f,
                        -(height / 2f - whiteWinImage.rect.height / 2f));
                }
            }
        }
    }

    void Update() {
        if (isGameOver) return;

        if (indicator != null && Input.GetMouseButton(0)) {
            var mousePos = new Vector3(
                Input.mousePosition.x * canvasRT.rect.width / Screen.width - canvasRT.rect.width / 2f,
                Input.mousePosition.y * canvasRT.rect.height / Screen.height - canvasRT.rect.height / 2f, 0f);

            var (tempX, tempY) = (-1, -1);

            for (var i = 0; i < 15; i++) {
                if (points[i, 0].x - 36 < mousePos.x
                    && mousePos.x < points[i, 0].x + 36) {
                    tempX = i;
                    break;
                }
            }

            for (var j = 0; j < 15; j++) {
                if (points[0, j].y - 36 < mousePos.y
                    && mousePos.y < points[0, j].y + 36) {
                    tempY = j;
                    break;
                }
            }

            if (0 <= tempX && tempX < 15 && 0 <= tempY && tempY < 15) {
                (x, y) = (tempX, tempY);
                indicator.anchoredPosition =
                   new Vector3(points[x, y].x, points[x, y].y, 0f);
            }
        }
    }

    public void PlaceStone() {
        if (isGameOver) return;

        if (canvasRT == null || middleCanvas == null
            || blackStone == null || whiteStone == null || redCross == null
            || indicator == null) {
            return;
        }

        if ((isBlackTurn && places[x, y] == Place.Restrict)
            || places[x, y] == Place.Black || places[x, y] == Place.White) {
            return;
        }

        var stone = Instantiate(
            isBlackTurn ? blackStone : whiteStone,
            indicator.transform.position, Quaternion.identity, middleCanvas.transform);
        stones.Add(stone);
        places[x, y] = isBlackTurn ? Place.Black : Place.White;

        DontShowRestrictPlaces();

        for (var i = 0; i < 4; i++) {
            if (StoneLineNum(x, y, out bool end, i) >= 5) {
                isGameOver = true;
                GameOver();
                return;
            }
        }

        if (stones.Count >= places.Length) {
            GameRestart();
        }

        isBlackTurn = !isBlackTurn;

        if (isBlackTurn) {
            blackPlaceButton.gameObject.SetActive(true);
            whitePlaceButton.gameObject.SetActive(false);
            ShowRestrictPlaces();
        } else {
            blackPlaceButton.gameObject.SetActive(false);
            whitePlaceButton.gameObject.SetActive(true);
        }
    }

    int StoneLineNum(int row, int column, out bool end, int option) {
        if (option < 0 || 3 < option) {
            end = false;
            return 0;
        }

        var num = 1;
        var endStone = false;
        var xy = new int[,,] {
            { { 1, 0 }, { -1, 0 } },
            { { -1, 1 }, { 1, -1 } },
            { { 0, 1 }, { 0, -1 } },
            { { 1, 1 }, { -1, -1 } }
        };

        for (var i = 0; i < 2; i++) {
            for (var j = 1; ; j++) {
                if (row + j * xy[option, i, 0] < 0 || 15 <= row + j * xy[option, i, 0]
                    || column + j * xy[option, i, 1] < 0 || 15 <= column + j * xy[option, i, 1]) {
                    endStone = true;
                    break;
                }

                if (places[row + j * xy[option, i, 0], column + j * xy[option, i, 1]]
                    == (isBlackTurn ? Place.Black : Place.White)) {
                    num++;
                } else if (places[row + j * xy[option, i, 0], column + j * xy[option, i, 1]]
                      == (isBlackTurn ? Place.White : Place.Black)) {
                    endStone = true;
                    break;
                } else {
                    break;
                }
            }
        }

        end = endStone;
        return num;
    }

    void ShowRestrictPlaces() {
        if (isGameOver) return;

        for (var i = 0; i < 15; i++) {
            for (var j = 0; j < 15; j++) {
                if (places[i, j] != Place.Null) {
                    if (places[i, j] == Place.Restrict) {
                        places[i, j] = Place.Null;
                    } else {
                        continue;
                    }
                }

                var count = 0;
                for (var k = 0; k < 4; k++) {
                    var stoneLineNum = StoneLineNum(i, j, out bool end, k);

                    if (stoneLineNum >= 6) {
                        places[i, j] = Place.Restrict;
                        break;
                    } else if (stoneLineNum >= 3 && !end) {
                        count++;
                    }
                }

                if (count >= 2) {
                    places[i, j] = Place.Restrict;
                }
            }
        }

        for (var i = 0; i < 15; i++) {
            for (var j = 0; j < 15; j++) {
                if (places[i, j] == Place.Restrict) {
                    var cross = Instantiate(
                        redCross, Vector3.zero, Quaternion.identity, middleCanvas.transform);

                    var crossRect = cross.GetComponent<RectTransform>();

                    if (crossRect != null) {
                        crossRect.anchoredPosition = points[i, j];
                    }

                    redCrosses.Add(cross);
                }
            }
        }
    }

    void DontShowRestrictPlaces() {
        foreach (var cross in redCrosses) {
            Destroy(cross);
        }

        redCrosses.Clear();
    }

    void GameRestart() =>
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    void GameOver() {
        if (isBlackTurn) {
            if (blackPlaceButton != null) {
                blackPlaceButton.gameObject.SetActive(false);
            }

            if (blackWinImage != null) {
                blackWinImage.gameObject.SetActive(true);
            }

            if (whiteDefeatImage != null) {
                whiteDefeatImage.gameObject.SetActive(true);
            }
        } else {
            if (whitePlaceButton != null) {
                whitePlaceButton.gameObject.SetActive(false);
            }

            if (blackDefeatImage != null) {
                blackDefeatImage.gameObject.SetActive(true);
            }

            if (whiteWinImage != null) {
                whiteWinImage.gameObject.SetActive(true);
            }
        }
    }
}
