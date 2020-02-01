using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;
    public static MusicManager Instance { get { return _instance; } }

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else if (_instance != null)
        {
            Destroy(gameObject);
        }

    }

    public bool IsAudioPlay()
    {
        return audioSource.isPlaying;

    }


    public void PlayMusic(AudioClip ac)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        this.audioSource.clip = ac;
        audioSource.Play();
    }

    public void PlayMusicByName(string name)
    {
        //audioSource.volume = 0.1f;
        AudioClip ac = Resources.Load<AudioClip>("Musics/" + name);
        
        PlayMusic(ac);
    }

    public void MusicStop()
    {
        audioSource.Stop();
        
    }

   

}
