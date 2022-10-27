using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    [SerializeField] SpaceStation spaceStation;
    [SerializeField] Transform attackPositions;
    [SerializeField] Transform spawnPositions;
    [SerializeField] GameObject[] asteroids;
    [Space]
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI stationText;

    public List<Vector3> M_AttackPositions { get; private set; } = new List<Vector3>();

    List<Vector3> m_SpawnPositions = new List<Vector3>();
    float playTime, spawnTime, interval;
    int initHP;

    void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (attackPositions != null) {
            var count = attackPositions.childCount;
            for (var i = 0; i < count; i++) {
                M_AttackPositions.Add(attackPositions.GetChild(i).position);
            }
        }

        if (spawnPositions != null) {
            var count = spawnPositions.childCount;
            for (var i = 0; i < count; i++) {
                m_SpawnPositions.Add(spawnPositions.GetChild(i).position);
            }
        }
        playTime = 0f;
        interval = 10f;
        initHP = spaceStation != null ? spaceStation.HP : 0;
    }

    void Update() {
        if (m_SpawnPositions == null || asteroids == null) return;

        if (playTime >= 300f) SceneManager.LoadScene("Success");
        if (spaceStation != null && spaceStation.HP <= 0) SceneManager.LoadScene("Fail");

        playTime += Time.deltaTime;

        if (playTime >= spawnTime + interval) {
            foreach (var position in m_SpawnPositions) {
                var asteroid = asteroids[Random.Range(0, asteroids.Length)];
                if (asteroid != null && Random.Range(0, 100) < 50) {
                    Instantiate(asteroid, position, Quaternion.identity);
                }
            }

            spawnTime = playTime;
            interval = Random.Range(5f, 15f);
        }

        if (timeText != null) {
            var remainTime = (300 - (int)playTime);
            timeText.text = $"{(remainTime / 60):00} : {(remainTime % 60):00}";
        }

        if (spaceStation != null && stationText != null && initHP != 0) {
            stationText.text = (int)((float)spaceStation.HP / initHP * 100) + " %";
        }
    }
}
