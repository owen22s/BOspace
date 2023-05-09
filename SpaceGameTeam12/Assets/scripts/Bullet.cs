using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 dir = Vector3.zero;
    private float speed = 0;
    void Update()
    {

        transform.position += dir * speed * Time.deltaTime;
    }

    public void Init(Vector3 dir, float speed)
    {
        this.dir = dir;
        this.speed = speed;
        transform.right = dir;
    }
}
