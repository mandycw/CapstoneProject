using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    void OnTriggerEnter(Collider other) { if (other.CompareTag("Enemy")) Destroy(gameObject);
    if (other.CompareTag("Terrain")) Destroy(gameObject);
     }
     
     
}
