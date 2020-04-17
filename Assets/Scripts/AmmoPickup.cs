using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public ParticleSystem pickupEffect;

    Vector3 start;
    Vector3 pos1;
    Vector3 pos2;

    public float rotateSpeed = 3f;

    float moveSpeed = 0.05f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            pickupEffect.Play();
            PlayerHandler.Instance.AddAmmo(30);
            collision.GetComponent<PlayerShooting>().UpdateAmmoText();
            Destroy(this.gameObject, 2);
        }
    }

    private void Start()
    {
        pickupEffect = GetComponent<ParticleSystem>();
        start = this.transform.position;
        pos1 = new Vector3(start.x, 1, start.z);
        pos2 = new Vector3(start.x, 1.5f, start.z);
        Destroy(this.gameObject, 30);
    }

    private void Update()
    {
        this.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y + rotateSpeed, this.transform.rotation.z, 0);

        if (this.transform.position.y < pos1.y && this.transform.position.y < pos2.y)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + moveSpeed, this.transform.position.z);
        }
        else if (this.transform.position.y >= pos2.y && this.transform.position.y >= pos1.y)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - moveSpeed, this.transform.position.z);
        }
    }
}
