using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("MENU")]
    public GameObject mainMENU;
    [Space(10)]
    public Button primaryMainMenuButton;
    [Space(10)]
    public Button optionsButton;
    public Button creditsButton;
    [Space(20)]

    [Header("Options MENU")]
    public GameObject optionsMENU;
    [Space(10)]
    public Button primaryOptionsMenuButton;
    [Space(20)]

    [Header("Credits MENU")]
    public GameObject creditsMENU;
    public Button primaryCreditsMenuButton;

    //MENU
    private void Start()
    {
        primaryMainMenuButton.Select();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("TrainingRoom");
    }

    public void OptionsMENU()
    {
        optionsMENU.SetActive(true);
        primaryOptionsMenuButton.Select();

        mainMENU.SetActive(false);
    }
    public void CreditsMENU()
    {
        creditsMENU.SetActive(true);
        primaryCreditsMenuButton.Select();

        mainMENU.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //OptionsMENU
    public void CloseOptions()
    {
        optionsMENU.SetActive(false);

        optionsButton.Select();
        mainMENU.SetActive(true);
    }

    //CreditsMENU
    public void CloseCredits()
    {
        creditsMENU.SetActive(false);

        creditsButton.Select();
        mainMENU.SetActive(true);
    }
}
