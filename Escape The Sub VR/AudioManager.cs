//This script is a custom audio manager system, making it easier to trigger specific audio clips in other scripts.
using UnityEngine;
using UnityEngine.Audio;
using System;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    public SoundClass[] sounds;
    public static AudioManager Instance;

    void Awake()
    {
        //Allows for each audio clip elements be edited, such as the volume and the pitch.
        foreach (SoundClass s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            this.enabled = false;
        }
    }

    //Play/Pause functions to controll the audio clip
    public void Play (string name)
    {
        SoundClass s = Array.Find(sounds, sound => sound.sName == name);
        s.source.Play();
    }
    public void Pause (string name)
    {
        SoundClass s = Array.Find(sounds, sound => sound.sName == name);
        s.source.Stop();
    }

    public AudioClip GetClip(string name)
    {
        foreach (SoundClass s in sounds)
        {
            if (s.sName == name)
            {
                return s.clip;
            }
        }
        return null;
    }
}
