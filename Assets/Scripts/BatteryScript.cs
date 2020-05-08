using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScript : MonoBehaviour
{
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5) && hit.collider.tag == "Battery")
            {
                PlayerHandler.Instance.AddBattery();
                source.Play();
                hit.collider.enabled = false;
                hit.collider.GetComponent<MeshRenderer>().enabled = false;
            }
        }

    }
}
