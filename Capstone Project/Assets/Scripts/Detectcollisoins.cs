using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectcollisoins : MonoBehaviour
{
    void OnTriggerEnter(Collider other) { Destroy(gameObject); }
    
}