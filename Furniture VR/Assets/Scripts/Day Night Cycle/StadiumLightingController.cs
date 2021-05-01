using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StadiumLightingController : MonoBehaviour
{
    [SerializeField]
    GameObject sun;

    [SerializeField]
    float sunsetPosition = 30.1f; //while greater than this it is night time
    [SerializeField]
    float sunsetAngle = .751f;
    [SerializeField]
    float sunrisePos = -42f;
    [SerializeField]
    float sunriseAngle = -4.834f;

    [SerializeField]
    bool sunUp = true;
    bool nightTime = false;

    public  static UnityEvent SunDownEvent = new UnityEvent();
    public static UnityEvent SunUpEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (sunUp && sun.transform.position.y < sunsetPosition)
        {
            nightTime = true;
            SunDownEvent.Invoke();
            Invoke("SunDown", 3);
        }
        else if (!sunUp && sun.transform.position.y > sunrisePos)
        {
            nightTime = false;
            SunUpEvent.Invoke();
            Invoke("SunUp", 3);
        }
       
    }

    void SunDown()
    {
        sunUp = false;
    }

    void SunUp()
    {
        sunUp = true;
    }
}
