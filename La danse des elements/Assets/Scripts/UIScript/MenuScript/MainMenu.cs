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

    public AudioSource uiAudioSource; // Drag your AudioSource here in the Inspector
    public AudioClip uiSound; // Drag your AudioClip here in the Inspector

    public AudioSource musicAudioSource; // Drag your AudioSource here in the Inspector
    public AudioClip musicSound; // Drag your AudioClip here in the Inspector

    [Header("Credits MENU")]
    public GameObject creditsMENU;
    public Button primaryCreditsMenuButton;

    //MENU
    private void Start()
    {
        musicAudioSource.clip = musicSound;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
        primaryMainMenuButton.Select();
    }

    public void PlayGame()
    {
        uiAudioSource.PlayOneShot(uiSound);
        SceneManager.LoadScene("MainGameplay");
    }

    public void OptionsMENU()
    {
        optionsMENU.SetActive(true);
        primaryOptionsMenuButton.Select();

        uiAudioSource.PlayOneShot(uiSound);

        mainMENU.SetActive(false);
    }
    public void CreditsMENU()
    {
        creditsMENU.SetActive(true);
        primaryCreditsMenuButton.Select();

        uiAudioSource.PlayOneShot(uiSound);

        mainMENU.SetActive(false);
    }

    public void QuitGame()
    {
        uiAudioSource.PlayOneShot(uiSound);
        Application.Quit();
    }

    //OptionsMENU
    public void CloseOptions()
    {
        optionsMENU.SetActive(false);

        uiAudioSource.PlayOneShot(uiSound);

        optionsButton.Select();
        mainMENU.SetActive(true);
    }

    //CreditsMENU
    public void CloseCredits()
    {
        creditsMENU.SetActive(false);

        uiAudioSource.PlayOneShot(uiSound);

        creditsButton.Select();
        mainMENU.SetActive(true);
    }
}