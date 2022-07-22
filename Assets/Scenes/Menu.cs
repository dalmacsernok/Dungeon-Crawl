using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void PlayerData()
    {
        SceneManager.LoadScene("PlayerData");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
