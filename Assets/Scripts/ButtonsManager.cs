using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    public Button playButton;
    public Button menuButton;
    public Button resumeButton;
    public Toggle SFXToggle;
    public Toggle BGMToggle;
    public GameObject pauseScreen;
    public CameraController cameraController;
    private SoundsManager soundsManager;
    public bool isGamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            EventSystem.current.SetSelectedGameObject(playButton.gameObject);
        }
        else if(SceneManager.GetActiveScene().name == "Won")
        {
            EventSystem.current.SetSelectedGameObject(menuButton.gameObject);
        }

        soundsManager = FindObjectOfType<SoundsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Menu" && SceneManager.GetActiveScene().name != "Won")
        {
            if (!isGamePaused)
            {
                PauseGame();
            }
            else if (isGamePaused)
            {
                ResumeGame();
            }
        }

        if(SceneManager.GetActiveScene().name != "Won")
        {
            if (PlayerPrefs.GetString("SFXState") == "Off")
            {
                SFXToggle.isOn = true;
            }
            else if (PlayerPrefs.GetString("SFXState") == "On")
            {
                SFXToggle.isOn = false;
            }
            if (PlayerPrefs.GetString("BGMState") == "Off")
            {
                BGMToggle.isOn = true;
            }
            else if (PlayerPrefs.GetString("BGMState") == "On")
            {
                BGMToggle.isOn = false;
            }
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Scene");
    }
    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void PauseGame()
    {
        if (!pauseScreen.activeSelf)
        {
            pauseScreen.SetActive(true);
            EventSystem.current.SetSelectedGameObject(resumeButton.gameObject);
            isGamePaused = true;
            cameraController.canDetectCursor = false;
            Time.timeScale = 0f;
        }
    }
    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        isGamePaused = false;
        cameraController.canDetectCursor = true;
        Time.timeScale = 1f;
    }

    public void SFXToggleHandler(bool mute)
    {
        if (mute)
        {
            soundsManager.audioSource.mute = true;
            PlayerPrefs.SetString("SFXState", "Off");
        }
        else if (!mute)
        {
            soundsManager.audioSource.mute = false;
            PlayerPrefs.SetString("SFXState", "On");
        }
    }
    public void BGMToggleHandler(bool mute)
    {
        if (mute)
        {
            soundsManager.BGMAudioSource.mute = true;
            PlayerPrefs.SetString("BGMState", "Off");
        }
        else if (!mute)
        {
            soundsManager.BGMAudioSource.mute = false;
            PlayerPrefs.SetString("BGMState", "On");
        }
    }


}
