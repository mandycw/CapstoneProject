using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProj : MonoBehaviour
{
    public GameObject gameObj;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObj, 3);
    }

}
