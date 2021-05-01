using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    // Start is called before the first frame update
    public void EarthGravity()
    {
        Physics.gravity = new Vector3(0, -9.81f, 0);
    }

    public void MoonGravity()
    {
        Physics.gravity = new Vector3(0, -1.62f, 0);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
