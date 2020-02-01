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
    public Text energy_Text;
    float textTimer = -1;

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
        energy_Text = GameObject.Find("Energy_Text").GetComponent<Text>();
    }


    private void Update()
    {
        if(textTimer >= 0)
        {
            textTimer += Time.deltaTime;
            if(textTimer >= 1)
            {
                energy_Text.text = "";
                textTimer = -1;
            }
        }
        
    }


    public void SetEnergyTextValue(int value)
    {
        textTimer = 0;
        energy_Text.text = "+ " + value.ToString();
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
