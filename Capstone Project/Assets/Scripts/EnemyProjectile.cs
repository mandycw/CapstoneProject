using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {   {if (other.CompareTag ("Player")) 
        Destroy(gameObject);}
     }
}
