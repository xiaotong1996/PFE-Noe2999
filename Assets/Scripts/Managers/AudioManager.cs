using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;
    public void SetMasterVolume(Slider s)
    {
        audioMixer.SetFloat("MasterVolume", s.value);
    }
    public void SetMusicVolume(Slider s)
    {

        audioMixer.SetFloat("MusicVolume", s.value);
    }
    public void SetSoundVolume(Slider s)
    {
        //SoundManager.Instance.PlayAudioByName("click");
        audioMixer.SetFloat("SoundEffectVolume", s.value);
    }

}
