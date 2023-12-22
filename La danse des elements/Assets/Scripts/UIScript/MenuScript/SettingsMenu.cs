using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{
    public static bool F11 = false;

    public Toggle fullscreenToggle;

    public const string GlobalVolume = "GlobalVolume";
    [SerializeField]
    public Slider globalSliderVolume;  // R�f�rence au premier slider dans l'�diteur Unity
    [SerializeField]
    public AudioMixerGroup globalAudioMixer;

    public const string MusicVolume = "MusicVolume";
    [SerializeField]
    public Slider musicSliderVolume;  // R�f�rence au premier slider dans l'�diteur Unity
    [SerializeField]
    public AudioMixerGroup musicAudioMixer;

    public const string SFXVolume = "SFXVolume";
    [SerializeField]
    public Slider soundSliderVolume;  // R�f�rence au deuxi�me slider dans l'�diteur Unity
    [SerializeField]
    public AudioMixerGroup soundAudioMixer;

    [SerializeField]
    private Vector2 minMaxMusicAudio;

    private void Start()
    {
        // Assurez-vous que le Toggle est initialis� correctement
        if (fullscreenToggle != null)
        {
            // Ajoutez un auditeur d'�v�nements pour d�tecter les changements d'�tat du Toggle
            fullscreenToggle.onValueChanged.AddListener(OnToggleValueChanged);
        }
        else
        {
            Debug.LogError("Toggle not assigned in the inspector!");
        }

        // Assurez-vous que les sliders et les audio sources sont valides
        if (musicSliderVolume != null && soundSliderVolume != null && musicAudioMixer != null && soundAudioMixer != null)
        {
            // Associez les fonctions de mise � jour du volume aux �v�nements de changement de valeur des sliders
            globalSliderVolume.onValueChanged.AddListener(SetGlobalVolume);
            musicSliderVolume.onValueChanged.AddListener(SetMusicVolume);
            soundSliderVolume.onValueChanged.AddListener(SetSFXVolume);
        }
        else
        {
            Debug.Log("Des Pistes audios n'ont pas �t� attribu�s dans l'�diteur Unity.");
        }
    }
    void OnToggleValueChanged(bool isFullscreen)
    {
        // Changez le mode plein �cran en fonction de l'�tat du Toggle
        Screen.fullScreen = isFullscreen;
    }

    private void OnEnable()
    {
        if (globalAudioMixer.audioMixer.GetFloat(GlobalVolume, out float volume))
        {
            globalSliderVolume.value = Mathf.InverseLerp(minMaxMusicAudio.x, minMaxMusicAudio.y, volume);
        }
        if (musicAudioMixer.audioMixer.GetFloat(MusicVolume, out volume))
        {
            musicSliderVolume.value = Mathf.InverseLerp(minMaxMusicAudio.x, minMaxMusicAudio.y, volume);
        }
        if (soundAudioMixer.audioMixer.GetFloat(SFXVolume, out volume))
        {
            soundSliderVolume.value = Mathf.InverseLerp(minMaxMusicAudio.x, minMaxMusicAudio.y, volume);
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

    private void SetGlobalVolume(float nouveauVolume)
    {
        // Assurez-vous que la premi�re audio source existe
        if (globalAudioMixer != null)
        {
            float volume = Mathf.Lerp(minMaxMusicAudio.x, minMaxMusicAudio.y, nouveauVolume);
            // Mettez � jour le volume de la premi�re audio source avec la valeur actuelle du premier slider
            globalAudioMixer.audioMixer.SetFloat(GlobalVolume, volume);
            Debug.Log(volume);
        }
    }

    private void SetMusicVolume(float nouveauVolume)
    {
        // Assurez-vous que la premi�re audio source existe
        if (musicAudioMixer != null)
        {
            float volume = Mathf.Lerp(minMaxMusicAudio.x, minMaxMusicAudio.y, nouveauVolume);
            // Mettez � jour le volume de la premi�re audio source avec la valeur actuelle du premier slider
            musicAudioMixer.audioMixer.SetFloat(MusicVolume, volume);
            Debug.Log(volume);
        }
    }
    private void SetSFXVolume(float nouveauVolume)
    {
        // Assurez-vous que la deuxi�me audio source existe
        if (soundAudioMixer != null)
        {
            float volume = Mathf.Lerp(minMaxMusicAudio.x, minMaxMusicAudio.y, nouveauVolume);
            // Mettez � jour le volume de la deuxi�me audio source avec la valeur actuelle du deuxi�me slider
            soundAudioMixer.audioMixer.SetFloat(SFXVolume, volume);
            Debug.Log(volume);
        }
    }
}
