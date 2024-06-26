using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform objectToFollow;
    void Update()
    {
        if (objectToFollow.position.y> transform.position.y)
        {
            transform.position = new Vector3(transform.position.x,objectToFollow.position.y,transform.position.z);
        }
    }
}
