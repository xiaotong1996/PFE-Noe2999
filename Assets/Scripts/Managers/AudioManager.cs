using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

/// <summary>
/// This class is to Manager the audioMixer
/// </summary>
public class AudioManager : MonoBehaviour
{
    
    public AudioMixer audioMixer;
    /// <summary>
    /// Change the master volume
    /// </summary>
    /// <param name="s"> the UI which control the volume of all the music and sound</param>
    public void SetMasterVolume(Slider s)
    {
        audioMixer.SetFloat("MasterVolume", s.value);
    }
    /// <summary>
    /// Change the music volume
    /// </summary>
    /// <param name="s"> the UI which control juste the volume of music</param>
    public void SetMusicVolume(Slider s)
    {

        audioMixer.SetFloat("MusicVolume", s.value);
    }
    /// <summary>
    /// change the sound effect volume
    /// </summary>
    /// <param name="s"> the UI which control juste the volume of sound effect</param>
    public void SetSoundVolume(Slider s)
    {
        //SoundManager.Instance.PlayAudioByName("click");
        audioMixer.SetFloat("SoundEffectVolume", s.value);
    }

}
