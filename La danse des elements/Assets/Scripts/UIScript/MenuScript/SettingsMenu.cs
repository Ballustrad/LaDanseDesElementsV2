using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{
    public static bool F11 = false;

    public Slider musicSliderVolume;  // R�f�rence au premier slider dans l'�diteur Unity
    public AudioSource musicAudioSource;  // R�f�rence � la premi�re AudioSource

    public Slider soundSliderVolume;  // R�f�rence au deuxi�me slider dans l'�diteur Unity
    public AudioSource soundAudioSource;  // R�f�rence � la deuxi�me AudioSource

    private void Start()
    {
        // Assurez-vous que les sliders et les audio sources sont valides
        if (musicSliderVolume != null && soundSliderVolume != null && musicAudioSource != null && soundAudioSource != null)
        {
            // Associez les fonctions de mise � jour du volume aux �v�nements de changement de valeur des sliders
            musicSliderVolume.onValueChanged.AddListener(MusicVolume);
            soundSliderVolume.onValueChanged.AddListener(SoundVolume);
        }
        else
        {
            Debug.Log("Des Pistes audios n'ont pas �t� attribu�s dans l'�diteur Unity.");
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
        // Assurez-vous que la premi�re audio source existe
        if (musicAudioSource != null)
        {
            // Mettez � jour le volume de la premi�re audio source avec la valeur actuelle du premier slider
            musicAudioSource.volume = nouveauVolume;
        }
    }
    private void SoundVolume(float nouveauVolume)
    {
        // Assurez-vous que la deuxi�me audio source existe
        if (soundAudioSource != null)
        {
            // Mettez � jour le volume de la deuxi�me audio source avec la valeur actuelle du deuxi�me slider
            soundAudioSource.volume = nouveauVolume;
        }
    }
}
