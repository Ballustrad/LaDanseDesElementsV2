using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public static bool menuContenuCheck = false;
    public static bool F11 = false;

    [Header("MENU")]
    public GameObject menus;
    public GameObject pauseMenu;
    [Space(10)]
    public Button primaryPauseMenuButton;
    [Space(20)]

    [Header("Options MENU")]
    public GameObject optionsMENU;
    [Space(10)]
    public Button primaryOptionsMenuButton;

    //Pause - Resume
    private void Start()
    {
        primaryPauseMenuButton.Select();
    }

    void LateUpdate()                                                                                 // Updates Every Frame After All Other Updates Have Been Completed.
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused == true)
            {
                Resume();
                gameIsPaused = false;
            }
            else if (gameIsPaused == false)
            {
                Paused();
                gameIsPaused = true;
                primaryPauseMenuButton.Select();
            }
        }     
        if (Input.GetKeyDown(KeyCode.F11))
        {
            if (F11 == false)
            {
                Screen.fullScreen = false;
                F11 = true;
            }
            else if (F11 == true)
            {
                Screen.fullScreen = true;
                F11 = false;
            }
        }
    }
    void Paused()
    {
        menus.SetActive(true);

        Time.timeScale = 0;
        gameIsPaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;


        Debug.Log("Pause");
    }
    public void Resume()
    {
        menus.SetActive(false);

        Time.timeScale = 1;
        gameIsPaused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Debug.Log("Resume");

        CloseOptions();
    }


    //MENU
    public void OptionsMENU()
    {
        optionsMENU.SetActive(true);
        primaryOptionsMenuButton.Select();

        pauseMenu.SetActive(false);
    }
    
    public void MainMenuPlay()
    {
        Resume();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Options
    public void CloseOptions()
    {
        optionsMENU.SetActive(false);

        pauseMenu.SetActive(true);
        primaryPauseMenuButton.Select();
    }
}
