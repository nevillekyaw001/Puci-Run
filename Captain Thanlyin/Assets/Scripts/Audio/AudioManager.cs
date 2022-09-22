using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public bool muted;
    AudioSource[] AS;
    void Awake()
    {
        if (instance == null)
        
            instance = this;
        
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
            
        }
    }

    private void Start()
    {
        Play("BGM Menu");
        AS = GetComponents<AudioSource>();
    }

    private void Update()
    {
        if (muted)
        {
            for (int i = 0; i < AS.Length; i++)
            {
                AudioSource ASE = AS[i];
                ASE.mute = true;
            }
        }
        else
        {
            for (int i = 0; i < AS.Length; i++)
            {
                AudioSource ASE = AS[i];
                ASE.mute = false;
            }
        }
    }

    public void Play (string name)
    {   
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play(); 
    }

    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);       
        s.source.Stop();  
    }

    public void Mute (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.mute = true;
    }

    public void Unmute (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.mute = false;
    }
}
