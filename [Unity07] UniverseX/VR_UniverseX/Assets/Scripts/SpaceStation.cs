using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SpaceStation : MonoBehaviour
{
    [SerializeField] GameObject rotatingPart;
    [SerializeField, Range(0f, 0.1f)] float rps = 0.1f;

    [field: SerializeField, Range(0, 1000)] public int HP { get; private set; } = 0;

    void Start() => StartCoroutine(RotatePart());

    IEnumerator RotatePart() {
        if (rotatingPart == null) yield break;

        while (true) {
            rotatingPart.transform.Rotate(Vector3.forward * rps * 360f * Time.deltaTime);
            yield return null;
        }
    }

    public void OnDamage(int damage) {
        if (HP <= 0 || damage <= 0) return;
        var temp = HP - damage;
        if (temp <= 0) HP = 0;
        else HP = temp;
    }
}
