using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    [Header("MENU")]
    public GameObject pauseMenu;
    public GameObject menuContenu;

    [Header("Load MENU")]
    public GameObject loadMENU;

    [Header("Options MENU")]
    public GameObject optionsMENU;
    [Space(10)]
    public GameObject audiosBoard;
    public GameObject graphicsBoard;
    public GameObject controlsBoard;

    //Pause - Resume
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
            }
        }
    }
    void Paused()
    {
        pauseMenu.SetActive(true);

        Time.timeScale = 0;
        gameIsPaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;


        Debug.Log("Pause");
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);

        Time.timeScale = 1;
        gameIsPaused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Debug.Log("Resume");

        CloseLoadMENU();
        CloseOptions();
    }

    //MENU
    public void LoadMENU()
    {
        loadMENU.SetActive(true);
        menuContenu.SetActive(false);
    }


    public void OptionsMENU()
    {
        optionsMENU.SetActive(true);

        controlsBoard.SetActive(true);

        audiosBoard.SetActive(false);
        graphicsBoard.SetActive(false);


        menuContenu.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    //LoadMENU
    public void MainMenuPlay()
    {
        SceneManager.LoadScene("Menu-Galaan");
    }
    public void TrainingRoomPlay()
    {
        SceneManager.LoadScene("Collection-Galaan");
    }
    public void MiniBiomePlay()
    {
        SceneManager.LoadScene("MiniBiome-Galaan");
    }
    public void CloseLoadMENU()
    {
        loadMENU.SetActive(false);


        menuContenu.SetActive(true);
    }

    //OptionsMENU
    public void ControlsBoard()
    {
        controlsBoard.SetActive(true);

        audiosBoard.SetActive(false);
        graphicsBoard.SetActive(false);
    }
    public void AudiosBoard()
    {
        audiosBoard.SetActive(true);

        graphicsBoard.SetActive(false);
        controlsBoard.SetActive(false);
    }
    public void GraphicsBoard()
    {
        graphicsBoard.SetActive(true);

        audiosBoard.SetActive(false);
        controlsBoard.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsMENU.SetActive(false);

        audiosBoard.SetActive(false);
        graphicsBoard.SetActive(false);


        menuContenu.SetActive(true);
    }
}
