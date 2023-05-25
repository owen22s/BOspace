using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemiePatrol : MonoBehaviour
{
    public float speed;
    public Transform[] patrolPoints;
    public float waitTime;
    int currentPointIndex;

    bool once;

    private void Update()
    {
        if (transform.position != patrolPoints[currentPointIndex].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
        }
        else
        {
            if (once == false)
            {
                once = true;
                StartCoroutine(Wait());
            }
        }
    }
    IEnumerator Wait()
    {
     yield return new WaitForSeconds(waitTime);
        if(currentPointIndex + 1 < patrolPoints.Length) 
        { 
            currentPointIndex++;
        }
        else 
        {
            currentPointIndex= 0;
        }
        once = false;
    }
}
