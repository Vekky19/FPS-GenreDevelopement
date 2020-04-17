using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public float HP = 5f;

    public GameObject AmmoPrefab;

    int temp1 = 1;

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

        Destroy(this.gameObject);
    }

    private void Update()
    {
        if (HP <= 0)
        {
            ZombieDie();
        }
    }
}
