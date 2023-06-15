using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spacepart_collect : MonoBehaviour
{
    public int coins;
    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag.ToLower().Trim())
        {
            case "space_part":
                coins++;
                Debug.Log("coin");
                break;
            case "door":
                if (coins >= 1)
                {
                    SceneManager.LoadScene("MainGame");
                }
                break;
            case "door2":
                if (coins >= 2)
                {
                    SceneManager.LoadScene("Level_3");
                }
                break;
        }


    } }
