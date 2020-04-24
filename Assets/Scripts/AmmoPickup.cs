using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public ParticleSystem pickupEffect;

    Transform ammo;
    Vector3 ogPOS;
    float ammoSpeed = 1f;

    public float rotateSpeed = 3f;

    float moveSpeed = 0.05f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            pickupEffect.Play();
            PlayerHandler.Instance.AddAmmo(30);
            collision.GetComponent<PlayerShooting>().UpdateAmmoText();
            Destroy(this.gameObject, 2);
        }
    }

    void MoveAmmo()
    {
        ammo.transform.position = new Vector3(ammo.transform.position.x, ammo.transform.position.y + ammoSpeed * Time.deltaTime, ammo.transform.position.z);
        if (ammo.transform.position.y > ogPOS.y + 1)
        {
            ammoSpeed = -ammoSpeed;
        }
        if (ammo.transform.position.y < ogPOS.y)
        {
            ammoSpeed = -ammoSpeed;
        }
    }

    private void Start()
    {
        pickupEffect = GetComponent<ParticleSystem>();
        ammo = GetComponent<Transform>();
        ogPOS = ammo.position;
        Destroy(this.gameObject, 30);
    }

    private void Update()
    {
        MoveAmmo();
    }
}
