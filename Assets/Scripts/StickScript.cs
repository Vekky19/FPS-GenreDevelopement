using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickScript : MonoBehaviour
{
    

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5) && hit.collider.tag == "Stick")
            {
                PlayerHandler.Instance.AddStick();
                hit.collider.enabled = false;
                hit.collider.GetComponent<MeshRenderer>().enabled = false;
            }
        }

    }
}
