using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }
    public Slider seaLevelSlider;
    public Slider energySlider;


    private void Awake()
    {
        if (instance == null)
        {
            //DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        seaLevelSlider = GameObject.Find("Sealevel_Slider").GetComponent<Slider>();
        energySlider = GameObject.Find("Energy_Slider").GetComponent<Slider>();
    }


    private void Update()
    {
        
        
    }

    public void SetSeaLevelMax(float value)
    {
        seaLevelSlider.maxValue = value;
    }

    public void SetEnergyMax(float value)
    {
        energySlider.maxValue = value;
    }

    public void UpdateSeaLevel(float value)
    {


        seaLevelSlider.value = value;
        //Debug.Log("seaLevelSlider.value" + seaLevelSlider.value);
    }

    public void UpdateEnergyslider(float value)
    {
        energySlider.value = value;
    }
}
