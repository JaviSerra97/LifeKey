using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour {

    [SerializeField]
    string hoverOverSound = "ButtonHover";
    [SerializeField]
    string pressButtonSound = "ButtonPress";

    Audio_Manager audioManager;

    void Start()
    {
        audioManager = Audio_Manager.instance;          
    }

    public void PlayGame()
    {
        audioManager.PlaySound(pressButtonSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartGame()
    {
        audioManager.PlaySound(pressButtonSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        audioManager.PlaySound(pressButtonSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        audioManager.PlaySound(pressButtonSound);
        Application.Quit();
    }

    public void OnMouseOver()
    {
        audioManager.PlaySound(hoverOverSound);
    }
    public void OnMousePress()
    {
        audioManager.PlaySound(pressButtonSound);
    }
}
