using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public bool IsAudioPlay()
    {
        return audioSource.isPlaying;

    }

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

    public void PlayAudioByName(string name)
    {
        //audioSource.volume = 0.05f;
        AudioClip ac = Resources.Load<AudioClip>("Sounds/" + name);
        PlayAudio(ac);
    }


}
