using Assets.Scripts;
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
            s.Source.volume = s.GetVolume();
            s.Source.pitch = s.Getpitch();
            s.Source.loop = s.GetLoop();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
