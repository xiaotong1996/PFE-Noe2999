using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is as singleton to manage the UI information
/// </summary>
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
        try
        {
            seaLevelSlider = GameObject.Find("Sealevel_Slider").GetComponent<Slider>();
        }
        catch { }

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

    /// <summary>
    /// To show the number of energy that will be added
    /// </summary>
    /// <param name="value">the value of the energy</param>
    public void SetEnergyTextValue(int value)
    {
        textTimer = 0;
        energy_Text.text = "+ " + value.ToString();
    }

    /// <summary>
    /// Set the maximum of the sea level
    /// </summary>
    /// <param name="value"></param>

    public void SetSeaLevelMax(float value)
    {
        if (seaLevelSlider != null) seaLevelSlider.maxValue = value;
    }

    /// <summary>
    /// set the maximum of the energy 
    /// </summary>
    /// <param name="value"></param>
    public void SetEnergyMax(float value)
    {
         energySlider.maxValue = value;
    }

    /// <summary>
    /// Update the sea level value
    /// </summary>
    /// <param name="value"></param>
    public void UpdateSeaLevel(float value)
    {


        if (seaLevelSlider != null) seaLevelSlider.value = value;
        //Debug.Log("seaLevelSlider.value" + seaLevelSlider.value);
    }


    /// <summary>
    /// Update the energy value
    /// </summary>
    /// <param name="value"></param>
    public void UpdateEnergyslider(float value)
    {
        energySlider.value = value;
    }
}
