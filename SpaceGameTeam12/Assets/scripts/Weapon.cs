using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;
    public AudioSource lasereffect;

    private bool canShoot = true;
    private float shootDelay = 2.5f;
    private float time = 0f;
    public bool haveweapon;

    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && time >= shootDelay && haveweapon)
        {
            Shoot();
            time = 0f;
            Debug.Log("test");
        }
    }

    void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - firePoint.position;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(direction.normalized * bulletForce, ForceMode2D.Impulse);
        lasereffect.Play();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag.ToLower().Trim())
        {
            case "weapon":
                haveweapon = true;
                Destroy(collision.gameObject);
                break;
        }
    }
}
