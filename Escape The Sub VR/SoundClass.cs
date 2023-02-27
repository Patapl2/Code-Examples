using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class SoundClass
{
    //Audio Name
    public string sName;

    //Audio Clip
    public AudioClip clip;

    //Volume of the Clip
    [Range(0f, 1f)]
    public float volume;

    //Pitch of the Clip
    [Range(0.1f, 3f)]
    public float pitch;

    //Does the sound lo
    public bool loop = false;

    [HideInInspector]
    public AudioSource source;
}
