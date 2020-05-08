using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCrate : MonoBehaviour
{
    public GameObject healthPickUp;
    ParticleSystem effect;
    int hp = 3;

    bool hasSpawned = false;

    private void Start()
    {
        effect = GetComponent<ParticleSystem>();
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
    }

    public void DestroyCrate()
    {
        if (hasSpawned == false)
        {
            Instantiate(healthPickUp, this.transform.position, Quaternion.identity);
            hasSpawned = true;
        }
        effect.Play();
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<MeshCollider>().enabled = false;
        Destroy(this.gameObject, 2);
    }

    private void Update()
    {
        if (hp <= 0)
        {
            DestroyCrate();
        }
    }
}
