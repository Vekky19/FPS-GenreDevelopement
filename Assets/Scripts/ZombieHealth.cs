using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public float HP = 5f;

    public GameObject AmmoPrefab;

    int temp1 = 1;

    public AudioClip[] zombieSounds;
    AudioSource source;

    float growlCooldown = 300f;
    float timer = 0;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
    }

    void ZombieDie()
    {
        int temp2 = Random.Range(0, 3);
        if (temp2 == temp1)
        {
            Instantiate(AmmoPrefab, this.transform.position, Quaternion.identity);
        }

        PlayerHandler.Instance.AddKill();

        Destroy(this.gameObject);
    }

    void PlaySoundEffect()
    {
        source.clip = zombieSounds[Random.Range(0, zombieSounds.Length)];
        source.Play();
    }

    private void Update()
    {
        timer++;

        if (timer > growlCooldown)
        {
            timer = 0;
            PlaySoundEffect();
        }

        if (HP <= 0)
        {
            ZombieDie();
        }
    }
}
