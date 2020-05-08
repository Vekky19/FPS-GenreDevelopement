using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryKillCounter : MonoBehaviour
{
    public Text counter;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        counter.text = PlayerPrefs.GetInt("ZombieKills").ToString();
    }
}
