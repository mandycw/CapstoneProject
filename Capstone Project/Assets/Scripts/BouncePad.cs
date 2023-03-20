using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounceForce = 500f; // The amount of force to apply to objects that hit the bounce pad

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>(); // Get the rigidbody component of the object that hit the bounce pad

        if (rb != null) // If the object has a rigidbody component
        {
            Vector3 bounceDirection = transform.up; // Get the direction to bounce in (in this case, the direction of the bounce pad's up vector)
            rb.AddForce(bounceDirection * bounceForce); // Add force to the object in the bounce direction
        }
    }
}



