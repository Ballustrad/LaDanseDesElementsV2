using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("MENU")]
    public GameObject menuContenu;
    [Space(10)]
    public Button primaryMainMenuButton;
    [Space(20)]

    [Header("Load MENU")]
    public GameObject loadMENU;
    [Space(10)]
    public Button primaryLoadMenuButton;
    [Space(20)]

    [Header("Options MENU")]
    public GameObject optionsMENU;
    [Space(10)]
    public GameObject controlsBoard;
    public GameObject audiosBoard;
    public GameObject graphicsBoard;
    [Space(20)]
    public Button primaryOptionsMenuButton;
    [Space(10)]
    public Button primaryControlsButton;
    public Button primaryAudiosButton;
    public Button primaryGraphicsButton;
    [Space(20)]

    [Header("Extras MENU")]
    public GameObject extrasMENU;
    [Space(10)]
    public GameObject creditsMENU;
    public GameObject creditsButton;

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
    public void ExtrasMENU()
    {
        extrasMENU.SetActive(true);
        creditsButton.SetActive(true);


        menuContenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }



    //LoadMENU
    public void TrainingRoomPlay()
    {
        SceneManager.LoadScene("Training-Room");
    }
    public void MiniBiomePlay()
    {
        SceneManager.LoadScene("MiniBiome-Galaan");
    }
    public void CloseLoadMENU()
    {
        loadMENU.SetActive(false);


        menuContenu.SetActive(true);
        primaryMainMenuButton.Select();
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



    //ExtrasMENU
    public void Credits()
    {
        creditsMENU.SetActive(true);
        creditsButton.SetActive(false);
    }
    public void CloseExtra()
    {
        extrasMENU.SetActive(false);
        creditsButton.SetActive(false);


        menuContenu.SetActive(true);
    }

    //CreditsMENU
    public void CloseCredits()
    {
        creditsMENU.SetActive(false);
        creditsButton.SetActive(true);
    }
}
