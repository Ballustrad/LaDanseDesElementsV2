using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public static bool menuContenuCheck = false;
    public static bool loadMenuCheck = false;

    [Header("Scene Management")]
    public string sceneActuelle;
    public string sceneAChargerSiIdentique;
    public string sceneAChargerSiDifferent;

    [Header("MENU")]
    public GameObject pauseMenu;
    public GameObject menuContenu;
    [Space(10)]
    public Button primaryPauseMenuButton;
    [Space(20)]

    [Header("Load MENU")]
    public GameObject loadMENU;
    [Space(10)]
    public Button primaryLoadMenuButton;
    [Space(20)]

    [Header("Options MENU")]
    public GameObject optionsMENU;
    [Space(10)]
    public GameObject audiosBoard;
    public GameObject graphicsBoard;
    public GameObject controlsBoard;
    [Space(20)]
    public Button primaryOptionsMenuButton;
    [Space(10)]
    public Button primaryControlsButton;
    public Button primaryAudiosButton;
    public Button primaryGraphicsButton;

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
                primaryPauseMenuButton.Select();
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
        primaryLoadMenuButton.Select();
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
        Resume();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu-Galaan");
    }
    public void TrainingRoomPlay()
    {
        Resume();
        SceneManager.LoadScene("Training-Room");
    }
    public void MiniBiomePlay()
    {
        Resume();
        SceneManager.LoadScene("MiniBiome-Galaan");
    }
    public void CloseLoadMENU()
    {
        loadMENU.SetActive(false);


        menuContenu.SetActive(true);
        primaryPauseMenuButton.Select();
    }

    //OptionsMENU
    public void ControlsBoard()
    {
        controlsBoard.SetActive(true);
        primaryControlsButton.Select();

        audiosBoard.SetActive(false);
        graphicsBoard.SetActive(false);
    }
    public void AudiosBoard()
    {
        audiosBoard.SetActive(true);
        primaryAudiosButton.Select();

        graphicsBoard.SetActive(false);
        controlsBoard.SetActive(false);
    }
    public void GraphicsBoard()
    {
        graphicsBoard.SetActive(true);
        primaryGraphicsButton.Select();

        audiosBoard.SetActive(false);
        controlsBoard.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsMENU.SetActive(false);

        audiosBoard.SetActive(false);
        graphicsBoard.SetActive(false);


        menuContenu.SetActive(true);
        primaryPauseMenuButton.Select();
    }
}
