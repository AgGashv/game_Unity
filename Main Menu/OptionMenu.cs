using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Dropdown dropdown;

    [SerializeField] private Slider slider;

    [SerializeField] private Toggle toggleSound;
    [SerializeField] private Toggle toggleScreen;


    private void Start()
    {
        if (PlayerPrefs.HasKey("Quality"))
        {
            dropdown.value = PlayerPrefs.GetInt("Quality");
            QualitySettings.SetQualityLevel(dropdown.value);
        }
        else
        {
            dropdown.value = QualitySettings.GetQualityLevel();
        }

        if (PlayerPrefs.HasKey("Volume"))
        {
            slider.value = PlayerPrefs.GetFloat("Volume");
        }


        if (PlayerPrefs.HasKey("Sound"))
        {

            if (PlayerPrefs.GetInt("Sound") == 0)
            {
                AudioListener.pause = false;
                toggleSound.isOn = !AudioListener.pause;
            }
            else if (PlayerPrefs.GetInt("Sound") == 1)
            {
                AudioListener.pause = true;
                toggleSound.isOn = !AudioListener.pause;
            }
        }

        if (PlayerPrefs.HasKey("FullScreen"))
        {

            if (PlayerPrefs.GetInt("FullScreen") == 0)
            {
                Screen.fullScreen = true;
                toggleScreen.isOn = true;
            }
            else if (PlayerPrefs.GetInt("FullScreen") == 1)
            {
                Screen.fullScreen = false;
                toggleScreen.isOn = false;
            }
        }


    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("Volume", volume);

    }

    public void SetQuality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
        PlayerPrefs.SetInt("Quality", qualityindex);
    }

    public void Sound()
    {
        AudioListener.pause = !toggleSound.isOn;


        if (AudioListener.pause)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
        }
    }

    public void FullScreen()
    {
        Screen.fullScreen = toggleScreen.isOn;

        if (Screen.fullScreen)
        {
            PlayerPrefs.SetInt("FullScreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("FullScreen", 0);
        }
    }
}
