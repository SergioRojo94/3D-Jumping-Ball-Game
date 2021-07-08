using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {

    public string name;
    public AudioClip clip;

    [Range(0f, 1f)] public float volume;
    [Range(.1f, 3f)] public float pitch;
    public float originalVolume; //used in SFXManager for enable / disable sounds
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
