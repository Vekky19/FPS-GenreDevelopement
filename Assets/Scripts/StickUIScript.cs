using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StickUIScript : MonoBehaviour
{
    TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();

        text.enabled = false;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5) && hit.collider.tag == "Stick")
        {
            text.enabled = true;
        }
        else
        {
            text.enabled = false;
        }

        if (text.enabled == true)
        {
            text.rectTransform.LookAt(Camera.main.GetComponent<Transform>().position);
        }
    }
}
