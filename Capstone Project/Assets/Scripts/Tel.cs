using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tel : MonoBehaviour
{
    public GameObject player;
    public Transform teleporterEndpoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.position = teleporterEndpoint.position;
        }
    }
}