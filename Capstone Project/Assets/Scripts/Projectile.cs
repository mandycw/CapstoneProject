using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    void OnTriggerEnter(Collider other) { Destroy(gameObject);
     }
}
