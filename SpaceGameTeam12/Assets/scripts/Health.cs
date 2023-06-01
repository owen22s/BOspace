using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Health : MonoBehaviour
{
    public float health;
    public int numOfHearts;
    public Image[] heartImages;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public UnityEngine.Vector3 spawnpoint;
    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < health)
            {
                heartImages[i].sprite = fullHeart;
            }
            else
            {
                heartImages[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                heartImages[i].enabled = true;
            }
            else
            {
                heartImages[i].enabled = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("touched somethingaaaaa: " + collision.gameObject.tag.ToLower());

        switch(collision.gameObject.tag.ToLower().Trim())
        {
            case "spikes":
            case "enemy":
                health -= 1;
                Debug.Log("Health reduced! Current health: " + health);
                Debug.Log("Collision occurred!");
                if (health <= 0)
                {
                    Debug.Log("Health is zero or negative!");
                    transform.position = spawnpoint;
                    health = 6;
                }
                break;
            case "medkit":
                health += 2;
                Debug.Log("health up");
                break;
            case "strong enemy":
                health -= 2;
                if (health <= 0)
                {
                    Debug.Log("Health is zero or negative!");
                    transform.position = spawnpoint;
                    health = 6;
                }
                break;
            case "healflower":
                health += 6;
                if (health > 6)
                {
                    health = 6;
                }
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            health -= 1;
            Debug.Log("Health reduced! Current health: " + health);
            if (health <= 0)
            {
                Debug.Log("Health is zero or negative!");
                transform.position = spawnpoint;
                health = 6;
            }
        }
    }
}
