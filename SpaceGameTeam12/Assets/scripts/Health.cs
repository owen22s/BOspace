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
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Spikes"))
            {
                health -= 1;
                Debug.Log(health);
            }
            if (collision.gameObject.CompareTag("Enemy"))
            {
                health -= 1;
                Debug.Log("Health reduced! Current health: " + health);
                Debug.Log("Collision occurred!");
            }
            if (collision.gameObject.CompareTag("Medkit"))
            {
                health += 2;
                Debug.Log("Health increased! Current health: " + health);
            }
            if (collision.gameObject.CompareTag("Healflower"))
            {
                health += 6;
                Debug.Log("Health increased! Current health: " + health);
            }
            if (health > 6)
            {
                health = 6;
            }
            if (collision.gameObject.CompareTag("Strong Enemy"))
            {
                health -= 2;
                Debug.Log("Health reduced! Current health: " + health);
            }
            if (collision.gameObject.CompareTag("Enemy"))
            {
                health -= 2;
                Debug.Log("Health reduced! Current health: " + health);
            }
            void OnTriggerEnter(Collider other)
            {
                if (collision.gameObject.CompareTag("Spikes"))
                {
                    health -= 1;
                    Debug.Log(health);
                }
            }



            if (health <= 0)
            {
                // Do something when health is zero or negative
                Debug.Log("Health is zero or negative!");
                transform.position = Vector2.zero; // Reset the object's position to (0, 0, 0)
                health = 3; // Reset the health to 3
            }
        }

        if (health > numOfHearts) 
        {
        health= numOfHearts;
        }
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