using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void Game_Start()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Game_Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Game_Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void Game_Return2Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Game_Quit()
    {
        Application.Quit();
    }
}
