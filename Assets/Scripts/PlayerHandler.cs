using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHandler : MonoBehaviour
{
    public static PlayerHandler Instance;

    public Slider HealthBar;

    public float HP = 100f;
    public int totalAmmo = 90;
    public int zombieKills = 0;

    public void AddKill()
    {
        zombieKills += 1;
    }

    public void UseAmmo(int amount)
    {
        totalAmmo -= amount;
    }

    public void AddAmmo(int amount)
    {
        totalAmmo += amount;
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
    }

    public void PlayerDie()
    {
        SceneManager.LoadScene("GameOver");
    }

    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        HealthBar.value = HP;

        if (HP <= 0)
        {
            PlayerDie();
        }
    }
}
