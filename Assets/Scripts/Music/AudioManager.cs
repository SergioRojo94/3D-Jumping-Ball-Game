using UnityEngine.Audio;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public string songName;
    public static AudioManager instance;

    private AudioSource aSource;
    public bool musicIsActive = true;
    private float originalVolume;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
            
    }

    void Start() {
        int random = Random.Range(0, 5);
        songName = sounds[random].name;
        Play(songName);
        aSource = FindObjectOfType<AudioSource>();
    }
    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
           
        s.source.Play();
    }

    public void StopSong(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Stopping Sound: " + name + " not found");
            return;
        }

        s.source.Stop();
    }

    public void StopAllSound() //stop all songs and sfx
    {
        musicIsActive = false;
        foreach (Sound sfx in sounds)
        {
            sfx.volume = 0;
            sfx.source.volume = 0;
        }
    }

    public void ReanudeAllSound()
    {
        musicIsActive = true;
        foreach (Sound sfx in sounds)
        {
            sfx.volume = sfx.originalVolume;
            sfx.source.volume = sfx.originalVolume;
        }
        aSource.enabled = true;
    }
}
