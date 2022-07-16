using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    public bool updatesValues;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        updatesValues = false;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip =   s.clip;
            s.source.volume = s.volume;
            s.source.pitch =  s.pitch;
            s.source.loop =   s.loop;
        }

        SetVolume(1);
    }

    private void Start()
    {
        Play("Music");
    }

    private void Update()
    {
        if (updatesValues)
        {
            updateValues();
            updatesValues = false;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Play();
    }

    public void updateValues()
    {
        foreach (Sound s in sounds)
        {
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void SetVolume(float volume)
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = s.volume * volume;
        }
    }

    public void SetVolume(float volume, string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }

        s.source.volume = s.volume * volume;

        
    }
}
