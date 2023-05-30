using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    public Image[] heartImages;
    public Sprite fullHeart;
    public Sprite emptyHeart;
     void Update()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if(i < health) 
            {
                heartImages[i].sprite = fullHeart;
            }else 
            {
                heartImages[i].sprite = emptyHeart; 
            }
        if (i < numOfHearts) 
            {
                heartImages[i].enabled = true;
            } else 
            {
                heartImages[i].enabled = false ;
            }
        }
    }
}