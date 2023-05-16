using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Create a new bullet instance
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody component of the bullet
        //Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Apply force to the bullet to shoot it forward
        //bulletRb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }
}

