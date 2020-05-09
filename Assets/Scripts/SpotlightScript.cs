using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightScript : MonoBehaviour
{
    Light spotLight;

    AudioSource source;

    public bool charged = false;

    private void Start()
    {
        source = GetComponent<AudioSource>();

        spotLight = GetComponentInChildren<Light>();
        spotLight.enabled = false;
    }

    public void Battery()
    {
        PlayerHandler.Instance.RemoveBattery();
        PlayerHandler.Instance.RemoveBattery();
        source.Play();
        charged = true;
        spotLight.enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5) && hit.collider.tag == "Spotlight")
            {
                if (PlayerHandler.Instance.batterys > 0 && charged == false)
                {
                    spotLight = hit.collider.GetComponentInChildren<Light>();
                    Battery();
                    Debug.Log("-1 Battery");
                }
            }
        }
    }
}
