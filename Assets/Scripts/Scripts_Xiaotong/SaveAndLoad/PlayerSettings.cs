using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider soundSlider;


    private void Awake()
    {
        if (!PlayerPrefs.HasKey("music")||!PlayerPrefs.HasKey("sound"))
        {
            PlayerPrefs.SetFloat("music", musicSlider.value);
            PlayerPrefs.SetFloat("sound", soundSlider.value);
            PlayerPrefs.Save();
        }
        else
        {
            musicSlider.value = PlayerPrefs.GetFloat("music");
            soundSlider.value = PlayerPrefs.GetFloat("sound");
        }
    }

    public void ValueChanged ()
    {
        PlayerPrefs.SetFloat("music", musicSlider.value);
        PlayerPrefs.SetFloat("sound", soundSlider.value);
        PlayerPrefs.Save();
    }
}
