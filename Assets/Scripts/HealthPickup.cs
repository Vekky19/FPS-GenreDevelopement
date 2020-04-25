using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public ParticleSystem pickupEffect;

    Transform health;
    Vector3 ogPOS;
    float healthSpeed = 1f;

    public float rotateSpeed = 3f;

    float moveSpeed = 0.05f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            pickupEffect.Play();
            PlayerHandler.Instance.AddHealth(10);
            collision.GetComponent<PlayerShooting>().UpdateAmmoText();
            Destroy(this.gameObject, 2);
        }
    }

    void MoveHealth()
    {
        health.transform.position = new Vector3(health.transform.position.x, health.transform.position.y + healthSpeed * Time.deltaTime, health.transform.position.z);
        if (health.transform.position.y > ogPOS.y + 1)
        {
            healthSpeed = -healthSpeed;
        }
        if (health.transform.position.y < ogPOS.y)
        {
            healthSpeed = -healthSpeed;
        }

        health.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y + rotateSpeed, this.transform.rotation.z, 0);
    }

    private void Start()
    {
        pickupEffect = GetComponent<ParticleSystem>();
        health = GetComponent<Transform>();
        ogPOS = health.position;
        Destroy(this.gameObject, 30);
    }

    private void Update()
    {
        MoveHealth();
    }
}
