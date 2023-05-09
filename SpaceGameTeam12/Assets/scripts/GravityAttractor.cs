using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public float gravity = -10f; // strength of gravity
    public Rigidbody2D player; // the object that will be attracted

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // get the direction from the object to this planet
        Vector2 gravityDirection = ( (Vector2)transform.position - player.position).normalized;


        // get the distance between the object and this planet
        float distance = Vector2.Distance(transform.position, player.position);

        // calculate the force of gravity using the mass of both objects
        float gravityForce = gravity * player.mass * GetComponent<Rigidbody2D>().mass / (distance * distance);

        // apply the force to the object
        player.AddForce(gravityDirection * gravityForce);
    }
}


