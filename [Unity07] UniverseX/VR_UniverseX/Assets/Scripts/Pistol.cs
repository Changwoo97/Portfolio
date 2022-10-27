using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public sealed class Pistol : MonoBehaviour {
    [SerializeField] LineRenderer laser;
    [SerializeField] Transform laserTransform;

    InputDevice targetDevice;
    float time;

    void Start() {
        var devices = new List<InputDevice>();
        var rightControllerCharacteristics =
            InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        if (devices.Count > 0) targetDevice = devices[0];
    }

    void Update() {
        if (laser == null || laserTransform == null) return;

        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if (triggerValue > 0.1f && Time.time > time + 0.5f) {
            var ray = new Ray(laserTransform.position, transform.forward);
            var distance = 150f;
            if (Physics.Raycast(ray, out RaycastHit hit, 150f)) {
                distance = Vector3.Distance(laserTransform.position, hit.point);

                var asteroid = hit.collider.GetComponent<Asteroid>();
                if (asteroid != null) {
                    asteroid.Erase();
                }
            }

            StartCoroutine(Laser(distance));

            time = Time.time;
        }
    }

    IEnumerator Laser(float distance) {
        var start = laserTransform.position;

        laser.SetPosition(0, start);
        laser.SetPosition(1, start + transform.forward * distance);

        laser.enabled = true;

        yield return new WaitForSeconds(0.1f);

        laser.enabled = false;
    }
}
