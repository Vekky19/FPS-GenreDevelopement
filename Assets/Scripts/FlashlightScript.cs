using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    public Light flashlight;
    public AudioSource soundFX;

    private void Start()
    {
        flashlight.enabled = false;
    }

    public void ToggleFlashlight()
    {
        flashlight.enabled = !flashlight.enabled;
        soundFX.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashlight();
        }
    }
}
