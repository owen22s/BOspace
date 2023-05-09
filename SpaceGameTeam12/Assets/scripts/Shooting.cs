using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private Sprite bulletSprite;
    [SerializeField]
    private float bulletSpeed = 20;
    [SerializeField]
    private float bulletLife = 3;
    [SerializeField]
    private Sprite targetSprite;
    private GameObject target;
    private LineRenderer lr;
    private Camera camera;

    void Start()
    {
        camera = Camera.main;
        target = new GameObject("Target");
        SpriteRenderer _sr = target.AddComponent<SpriteRenderer>();
        _sr.sprite = targetSprite;

        lr = gameObject.AddComponent<LineRenderer>();
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
    }


    void Update()
    {
        UpdateTargetPosition();
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    private void Fire()
    {
        CreateBullet();
    }
    private GameObject CreateBullet()
    {
        Vector3 dir = (target.transform.position - transform.position).normalized;

        GameObject bullet = new GameObject("Bullet");
        bullet.transform.position = this.transform.position + dir;
        bullet.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        bullet.AddComponent<SpriteRenderer>().sprite = bulletSprite;
        Bullet bs = bullet.AddComponent<Bullet>();
        bs.Init(dir, bulletSpeed);
        Destroy(bullet, bulletLife);
        return bullet;
    }
    private void UpdateTargetPosition()
    {
        Vector3 targetPos = camera.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0;
        target.transform.position = targetPos;
        Vector3[] linePosition = { transform.position, target.transform.position };
        lr.SetPositions(linePosition);
    }
}
