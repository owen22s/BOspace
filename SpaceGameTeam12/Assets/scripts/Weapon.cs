using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;
    public AudioSource lasereffect;

    private bool canShoot = true;
    private float shootDelay = 2.5f;
    public float time = 0f;
    public bool haveweapon = false;

    // Update is called once per frame
    void Update()
    {
        void OnCollisionEnter2D(Collision2D collision) 
        {
            switch (collision.gameObject.tag.ToLower().Trim())
            {
                case "weapon":
                    haveweapon = true; 
                    break;
            }
            }
        time += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && time >= shootDelay && haveweapon == true)
        {
            Shoot();
            time = 0f;
            Debug.Log("test");
        }


    }

    void Shoot()
    {
        // Create a new bullet instance
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        lasereffect.Play();
    }

}
