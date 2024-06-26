using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour
{
    [SerializeField] private float speedRotation;
    // Start is called before the first frame update
    void Update()
    {
        transform.Rotate(new Vector3(0f,0f,speedRotation*Time.deltaTime));
    }
}
