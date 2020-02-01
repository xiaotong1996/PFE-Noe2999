using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject Image_1;
    public GameObject Image_2;
    public GameObject Image_3;
    public GameObject Image_4;
    public GameObject Image_5;
    public GameObject Image_6;
    private int IsActive = 1;

    public void Start()
    {
        if ((Image_1 != null) && (Image_2 != null) && (Image_3 != null) && (Image_4 != null) && (Image_5 != null) && (Image_6 != null))
        {
            Image_2.SetActive(false);
            Image_3.SetActive(false);
            Image_4.SetActive(false);
            Image_5.SetActive(false);
            Image_6.SetActive(false);
        }
    }

    public void SwitchImage()
    {
        if ((Image_1 != null)&& (Image_2 != null)&& (Image_3 != null)&& (Image_4 != null)&& (Image_5 != null)&& (Image_6 != null))
        {
            if (IsActive == 1)
            {
                Image_1.SetActive(false);
                Image_2.SetActive(true);
                IsActive += 1;
            }

            else if (IsActive == 2)
            {
                Image_2.SetActive(false);
                Image_3.SetActive(true);
                IsActive += 1;
            }

            else if (IsActive == 3)
            {
                Image_3.SetActive(false);
                Image_4.SetActive(true);
                IsActive += 1;
            }

            else if (IsActive == 4)
            {
                Image_4.SetActive(false);
                Image_5.SetActive(true);
                IsActive += 1;
            }

            else if (IsActive == 5)
            {
                Image_5.SetActive(false);
                Image_6.SetActive(true);
                IsActive += 1;
            }

            else 
            {
                Image_6.SetActive(false);
                IsActive = 1;
                //if(SceneDataModel.lastScene)
                if(SceneDataModel.flagForIntroduction == "menu")
                    SceneManager.LoadScene("Start");
                else if(SceneDataModel.flagForIntroduction == "play")
                    SceneManager.LoadScene("Map3D");
                //TODO : appeler la scène qui convient (soit le menu soit la nouvelle partie)
            }
        }
    }
}
