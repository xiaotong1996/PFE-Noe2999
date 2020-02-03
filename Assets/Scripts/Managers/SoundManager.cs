using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is a singleton to control the sound effect
/// </summary>
public class SoundManager : MonoBehaviour
{

    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

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
    /// To check if the sound is playing
    /// </summary>
    /// <returns> true if the sound is playing </returns>
    public bool IsAudioPlay()
    {
        return audioSource.isPlaying;

    }

    /// <summary>
    /// Play sound by audioclip
    /// </summary>
    /// <param name="ac"></param>
    public void PlayAudio(AudioClip ac)
    {
        //AudioSource.PlayClipAtPoint(ac, Camera.main.transform.position);

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        this.audioSource.clip = ac;
        audioSource.Play();
    }

    /// <summary>
    /// Play sound by sound name, the sound file must be put in the folder Resources/Sounds/
    /// </summary>
    /// <param name="name"></param>
    public void PlayAudioByName(string name)
    {
        //audioSource.volume = 0.05f;
        AudioClip ac = Resources.Load<AudioClip>("Sounds/" + name);
        PlayAudio(ac);
    }


}
