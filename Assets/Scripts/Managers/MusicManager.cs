using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is a singleton to play the music
/// </summary>
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

    /// <summary>
    /// To check if the music is playing
    /// </summary>
    /// <returns> true if the music is playing</returns>
    public bool IsAudioPlay()
    {
        return audioSource.isPlaying;

    }

    /// <summary>
    /// Play music by AudioClip
    /// </summary>
    /// <param name="ac"></param>
    public void PlayMusic(AudioClip ac)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        this.audioSource.clip = ac;
        audioSource.Play();
    }

    /// <summary>
    /// Play music by music resources name, the music must put in the folder  Resources/Musics/
    /// </summary>
    /// <param name="ac">music name</param>
    public void PlayMusicByName(string name)
    {
        //audioSource.volume = 0.1f;
        AudioClip ac = Resources.Load<AudioClip>("Musics/" + name);
        
        PlayMusic(ac);
    }

    /// <summary>
    /// Stop play music
    /// </summary>
    public void MusicStop()
    {
        audioSource.Stop();
        
    }

   

}
