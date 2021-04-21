using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMoonController : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, rotateSpeed * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }
}
