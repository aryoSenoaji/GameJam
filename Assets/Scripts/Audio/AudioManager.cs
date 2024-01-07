using System;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            if (s.isBGM)
            {
                s.source.outputAudioMixerGroup = s.mixer; // Set the mixer for BGM
                PlayBGM(s.name); // Play BGM on Awake
            }
        }
    }

    public void Play(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s != null)
        {
            if (s.isBGM)
            {
                PlayBGM(sound);
            }
            else
            {
                s.source.Play();
            }
        }
    }
    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        s.source.Stop();
    }

    public void PlayBGM(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound && item.isBGM);
        if (s != null)
        {
            s.source.Play();
        }
    }
}
