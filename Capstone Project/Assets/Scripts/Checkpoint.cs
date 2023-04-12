using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] List<GameObject> checkPoints;
    [SerializeField] GameObject player;
    [SerializeField] Vector3 vectorPoint;
    [SerializeField] float dead;
    // Update is called once per frame
    void Start()
    {
        
    }

    void Update()
    {
        if(gameObject.transform.position.y < -dead)
        {
            gameObject.transform.position = vectorPoint;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
            if(other.gameObject.CompareTag("CheckPoint"))
            {
                vectorPoint = player.transform.position;
                Destroy(other.gameObject);
            }
            
    }
}

