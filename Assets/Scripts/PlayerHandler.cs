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
    //public int zombieKills = 0;

    public int sticks = 0;
    public int batterys = 0;

    public Dictionary<string, bool> Tasks;

    void Start()
    {
        Instance = this;
        Tasks = new Dictionary<string, bool>();
        Tasks.Add("Fire", false);
        Tasks.Add("Lights", false);
    }

    public void CompleteTask(string task)
    {
        Tasks[task] = true;
        Debug.Log("Task Completed: " + task);
    }

    public void AddStick()
    {
        sticks += 1;
    }

    public void RemoveStick()
    {
        sticks -= 1;
    }

    public void AddBattery()
    {
        batterys += 1;
    }

    public void RemoveBattery()
    {
        batterys -= 1;
    }

    public void AddKill()
    {
        //zombieKills += 1;
        PlayerPrefs.SetInt("ZombieKills", PlayerPrefs.GetInt("ZombieKills") + 1);
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

    public void AddHealth(float heal)
    {
        if (HP + heal > 100)
        {
            AddHealth(heal - 1);
        }
        else
        {
            HP += heal;
        }
    }

    public void PlayerDie()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("GameOver");
    }

    void Update()
    {
        HealthBar.value = HP;
        //PlayerPrefs.SetInt("ZombieKills", zombieKills);

        if (HP <= 0)
        {
            PlayerDie();
        }

        if (Tasks["Fire"] == true)
        {
            SceneManager.LoadScene("Level2");
        }

        if (Tasks["Lights"] == true)
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
