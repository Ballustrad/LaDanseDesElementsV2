using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{
    public static bool F11 = false;

    public AudioMixer audioMixer;

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

    public void SetGlobalSoundVolume(float volume)
    {
        audioMixer.SetFloat("GlobalSound", volume);
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", volume);
    }
    public void SetSoundEffectsVolume(float volume)
    {
        audioMixer.SetFloat("SoundEffects", volume);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        isFullScreen = true;
        Screen.fullScreen = isFullScreen;
    }


}
