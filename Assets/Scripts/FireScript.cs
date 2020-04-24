using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public ParticleSystem fire;
    public Light firelight;

    public GameObject[] sticksOnFire;
    public int index;

    private void Start()
    {
        index = 0;
    }

    public void AddStick(int i)
    {
        if (i < sticksOnFire.Length)
        {
            sticksOnFire[i].GetComponent<MeshRenderer>().enabled = true;
        }
        if ( i >= sticksOnFire.Length - 1)
        {
            fire.Play();
            firelight.enabled = true;
            PlayerHandler.Instance.CompleteTask("Fire");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5) && hit.collider.tag == "Fire")
            {
                if (PlayerHandler.Instance.sticks > 0)
                {
                    PlayerHandler.Instance.RemoveStick();
                    AddStick(index);
                    index += 1;
                    Debug.Log("-1 Stick");
                }
            }
        }
    }
}
