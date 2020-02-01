using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Image icon;
    public Text description;
    
    int idx = 0;

    List<string> des = new List<string>();
    List<string> icons = new List<string>();

    

    // Start is called before the first frame update
    void Start()
    {
        InitResources();
      
        icon.sprite = Resources.Load(icons[0], typeof(Sprite)) as Sprite;
        description.text = des[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftBtnClick()
    {
        SoundManager.Instance.PlayAudioByName("click");
        if(idx - 1 >= 0)
        {
            idx--;
            icon.sprite = Resources.Load(icons[idx], typeof(Sprite)) as Sprite;
            description.text = des[idx];
        }
    }

    public void RightBtnClick()
    {
        SoundManager.Instance.PlayAudioByName("click");
        if (idx + 1 <= des.Count-1)
        {
            idx++;
            icon.sprite = Resources.Load(icons[idx], typeof(Sprite)) as Sprite;
            description.text = des[idx];
        }
    }
    void InitResources()
    {
        des.Add("Ne s'entend pas avec les chiens ! [Vous ne pouvez pas le placer dans la même salle qu'un chien]");
        des.Add("Ne s'entend pas avec les chats ! [Vous ne pouvez pas le placer dans la même salle qu'un chat]");
        des.Add("Mange les poules!![Vous ne pouvez pas le placer dans la même salle qu'une poule]");
        des.Add("Se fait bouffer par les lions ! [Vous ne pouvez pas le placer dans la même salle qu'un lion]");
        des.Add("Se fait bouffer par les lions ! [Vous ne pouvez pas le placer dans la même salle qu'un lion");

        icons.Add("Images/Animals/cat");
        icons.Add("Images/Animals/dog");
        icons.Add("Images/Animals/lion");
        icons.Add("Images/Animals/hen");
        icons.Add("Images/Animals/zebra");


    }


    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);

    }

    public void Exit()
    {
       

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
