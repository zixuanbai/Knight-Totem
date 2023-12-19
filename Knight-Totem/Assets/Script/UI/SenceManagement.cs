using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SenceManagement : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    void Start()
    {
        
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    void StartGame()
    {
        
        SceneManager.LoadScene("Level1");
    }

    void ExitGame()
    {
        
        Application.Quit();
    }
}
