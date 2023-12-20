using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{
    public static bool F11 = false;

    public Slider musicSliderVolume;  // Référence au premier slider dans l'éditeur Unity
    public AudioSource musicAudioSource;  // Référence à la première AudioSource

    public Slider soundSliderVolume;  // Référence au deuxième slider dans l'éditeur Unity
    public AudioSource soundAudioSource;  // Référence à la deuxième AudioSource

    private void Start()
    {
        // Assurez-vous que les sliders et les audio sources sont valides
        if (musicSliderVolume != null && soundSliderVolume != null && musicAudioSource != null && soundAudioSource != null)
        {
            // Associez les fonctions de mise à jour du volume aux événements de changement de valeur des sliders
            musicSliderVolume.onValueChanged.AddListener(MusicVolume);
            soundSliderVolume.onValueChanged.AddListener(SoundVolume);
        }
        else
        {
            Debug.Log("Des Pistes audios n'ont pas été attribués dans l'éditeur Unity.");
        }
    }

    private void LateUpdate()
    {
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
    public void SetFullScreen(bool isFullScreen)
    {
        isFullScreen = true;
        Screen.fullScreen = isFullScreen;
    }

    private void MusicVolume(float nouveauVolume)
    {
        // Assurez-vous que la première audio source existe
        if (musicAudioSource != null)
        {
            // Mettez à jour le volume de la première audio source avec la valeur actuelle du premier slider
            musicAudioSource.volume = nouveauVolume;
        }
    }
    private void SoundVolume(float nouveauVolume)
    {
        // Assurez-vous que la deuxième audio source existe
        if (soundAudioSource != null)
        {
            // Mettez à jour le volume de la deuxième audio source avec la valeur actuelle du deuxième slider
            soundAudioSource.volume = nouveauVolume;
        }
    }
}
