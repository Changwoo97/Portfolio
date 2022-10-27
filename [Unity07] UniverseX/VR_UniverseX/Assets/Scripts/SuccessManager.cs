using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public sealed class SuccessManager : MonoBehaviour
{
    AudioSource audioSource;
    InputDevice targetDevice;

    bool click = false;

    void Start() {
        audioSource = GetComponent<AudioSource>();

        var devices = new List<InputDevice>();
        var rightControllerCharacteristics =
            InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        if (devices.Count > 0) targetDevice = devices[0];
    }

    void Update() {
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if (triggerValue > 0.1f && !click) {
            audioSource.Play();
            StartCoroutine(Delay());

            click = true;
        }
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Start");
    }
}
