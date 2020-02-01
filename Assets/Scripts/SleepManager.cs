using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SleepManager : MonoBehaviour
{

    public Image sleepBtnImage;
    public Image sleepImage;
    bool isSleep = false;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.IsSleep)
        {
            sleepImage.gameObject.SetActive(true);
            //GameManager.Instance.IsSleep = true;
            sleepBtnImage.sprite = Resources.Load("Images/UI/sun", typeof(Sprite)) as Sprite;
            isSleep = true;
        }
        else
        {
            sleepImage.gameObject.SetActive(false);
            //GameManager.Instance.IsSleep = false;
            sleepBtnImage.sprite = Resources.Load("Images/UI/sleep", typeof(Sprite)) as Sprite;
            isSleep = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        if (!AnimalDataModel.isPause)
        {
            if (!isSleep)
            {
                sleepImage.gameObject.SetActive(true);
                GameManager.Instance.IsSleep = true;
                sleepBtnImage.sprite = Resources.Load("Images/UI/sun", typeof(Sprite)) as Sprite;
                isSleep = true;
            }
            else
            {
                sleepImage.gameObject.SetActive(false);
                GameManager.Instance.IsSleep = false;
                sleepBtnImage.sprite = Resources.Load("Images/UI/sleep", typeof(Sprite)) as Sprite;
                isSleep = false;
            }
        }
        
    }
}
