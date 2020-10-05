using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private Sound[] sounds;
    public static AudioManager Instance { get; set; }
    private void Awake()
    {
        //Begin: Singleton
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        //end
        foreach (var s in sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.GetClip();
            s.Source.volume = 1;// s.GetVolume();
            s.Source.pitch = s.Getpitch();
            s.Source.loop = s.GetLoop();
        }
    }

    private Sound Find(string name)
    {
        return Array.Find(sounds, sound => sound.GetName() == name);
    }

    /// <summary>
    /// Play sound
    /// </summary>
    /// <param name="name">Name of sound</param>
    public Sound Play(string name)
    {
        Sound s = Find(name);
        if (s != null && !s.Source.isPlaying)
        {
            s.Source.Play();
            return s;
        }
        return null;
    }
    /// <summary>
    /// Play sound
    /// </summary>
    /// <param name="name">Name of sound</param>
    public Sound Stop(string name)
    {
        Sound s = Find(name);
        if (s != null)
        {
            s.Source.Stop();
            return s;
        }
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        Play("MainTheme");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
