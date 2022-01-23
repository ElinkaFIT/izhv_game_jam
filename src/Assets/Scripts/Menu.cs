using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool GameIsOn = false;
    public GameObject StartMenu;

    // Start is called before the first frame update
    void Start()
    {
        if(!GameIsOn)
            Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.Space) && (GameIsOn == false) )
        {
            ResumeGame();
        }
        if (Input.GetKeyDown(KeyCode.R) )
        {
            StartGame();
        }

        if (GameIsOn)
        {
            StartMenu.SetActive(false);
        }
    }

    public void PauseGame()
    {
        StartMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsOn = false;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StartMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsOn = true;
    }
    public void ResumeGame()
    {
        StartMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsOn = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
