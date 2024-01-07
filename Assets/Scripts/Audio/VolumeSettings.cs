using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;


    private void Start()
    {
        if (PlayerPrefs.HasKey("bgmVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetBgmVolume();
            SetSfxVolume();
        }
    }
    public void SetBgmVolume()
    {
        float volume = bgmSlider.value;
        myMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("bgmVolume", volume);
    }
    public void SetSfxVolume()
    {
        float volume = sfxSlider.value;
        myMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    private void LoadVolume()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("bgmVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");

        SetBgmVolume();
        SetSfxVolume();
    }
}
