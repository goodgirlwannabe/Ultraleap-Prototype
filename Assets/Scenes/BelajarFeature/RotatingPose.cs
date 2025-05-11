using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPose : MonoBehaviour
{
    // public GameObject textGameobject;
    public Vector3 rotationSpeed = new Vector3(0f, 100f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
        
    }
}
