using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightGoal : MonoBehaviour
{
    public GameObject[] spotlights;

    private void Update()
    {
        for (int i = 0; i < spotlights.Length; i++)
        {
            if (spotlights[0].GetComponentInChildren<Light>().isActiveAndEnabled && spotlights[1].GetComponentInChildren<Light>().isActiveAndEnabled && spotlights[2].GetComponentInChildren<Light>().isActiveAndEnabled)
            {
                PlayerHandler.Instance.CompleteTask("Lights");
            }
        }
    }
}
