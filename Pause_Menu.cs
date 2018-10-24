using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour {

    public static bool IsPaused = false;
    public GameObject pauseUI;
    private GameObject pauseButton;
    private GameObject GUI;

    Audio_Manager audioManager;
    [SerializeField]
    string pressButtonSound = "ButtonPress";
    [SerializeField]
    string hoverOverSound = "ButtonHover";

    // Use this for initialization
    void Start () {
        pauseButton = GameObject.Find("PauseButton");
        pauseButton.SetActive(true);

        GUI = GameObject.Find("GUI");
        GUI.SetActive(true);

        audioManager = Audio_Manager.instance;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) || CrossPlatformInputManager.GetButtonDown("Pause"))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        audioManager.PlaySound(pressButtonSound);
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        pauseButton.SetActive(true);
        GUI.SetActive(true);
    }

    void Pause()
    {
        audioManager.PlaySound(pressButtonSound);
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        pauseButton.SetActive(false);
        GUI.SetActive(false);
    }

    public void LoadMenu()
    {
        audioManager.PlaySound(pressButtonSound);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        
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
