using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField]
    private Image itemImage;
    public Image ItemImage { get => itemImage; set => ItemImage = value; }

    [SerializeField]
    private Text number;
    public Text Number { get => number; set => Number = value; }


    public void UpdateText(int s)
    {
        Number.text = s.ToString();
    }
    public void UpdateImage(string path)
    {
        Sprite sprite;
        sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
        ItemImage.sprite = sprite;
    }
    
}
