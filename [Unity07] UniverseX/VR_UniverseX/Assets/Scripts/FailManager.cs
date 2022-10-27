using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class FailManager : MonoBehaviour {
    [SerializeField] GameObject[] modules;
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject text;
    bool ani = true;

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

        StartCoroutine(Animation());
    }

    void Update() {
        if (!ani) {
            targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
            if (triggerValue > 0.1f && !click) {
                audioSource.Play();
                StartCoroutine(Delay());

                click = true;
            }
        }
    }

    IEnumerator Animation() {
        if (modules == null || explosion == null) { ani = false; yield break; }

        yield return new WaitForSeconds(1f);

        foreach (var module in modules) {
            var obj = Instantiate(explosion, module.transform.position, Quaternion.identity);
            obj.transform.localScale = Vector3.one * 5f;
            Destroy(obj, 6f);
            Destroy(module);
        }

        yield return new WaitForSeconds(6f);
        if (text != null) text.SetActive(true);
        ani = false;
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Start");
    }
}
