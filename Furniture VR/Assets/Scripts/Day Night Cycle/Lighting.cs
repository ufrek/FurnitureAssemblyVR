using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Light>().enabled = false;
        StadiumLightingController.SunDownEvent.AddListener(LightsOn);
        StadiumLightingController.SunUpEvent.AddListener(LightsOff);

    }

    public void LightsOn()
    {
        this.GetComponent<Light>().enabled = true;
    }

    public void LightsOff()
    {
        this.GetComponent<Light>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
