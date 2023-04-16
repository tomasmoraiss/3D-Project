using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public PlayerController playerController;
    public TimeController timeController;

    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        if(timeController.dayCounter == 7)
        {
            Endgame();
        }
    }

    private void ProcessInputs()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (pauseMenu.activeSelf == true)
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ContinueGame()
    {
        Debug.Log("Continue game");
    }

    public void Settings()
    {
        Debug.Log("Open settings");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Endgame()
    {
        Time.timeScale = 0;
        if(playerController.points < 10000)
        {
            scoreText.text = "You're fired!\n You scored: " + playerController.points;
        }else if(playerController.points > 10000 && playerController.points < 20000)
        {
            scoreText.text = "You did okay\n You scored: " + playerController.points;
        }else if(playerController.points > 20000)
        {
            scoreText.text = "Good job!\n You scored: " + playerController.points;
        }
    }
}
