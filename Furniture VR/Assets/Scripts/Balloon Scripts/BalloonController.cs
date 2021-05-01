using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class BalloonController : MonoBehaviour
{
  
    public GameObject balloonPrefab;
    public GameObject hand;
    private GameObject balloon;
    


  
    [SerializeField]
    private float floatStrength = 20;
    [SerializeField]
    private float scaleFactor = .1f;
    InputDevice device;

    //public XRRayInteractor rightInteractor;

    // Start is called before the first frame update
    void Start()
    {
        //Make a button controller gameobject and use these if you want to make these methods run on an event
        //buttonController.ButtonDownEvent.AddListener(CreateBalloon);
        //buttonController.ButtonUpEvent.AddListener(ReleaseBalloon);
    }

    
    // Update is called once per frame
    void Update()
    {
        if (balloon != null)
        {
            ScaleBalloon();
        }

    }

    public void CreateBalloon(GameObject parentHand)
    {
            balloon = Instantiate(balloonPrefab, parentHand.transform);
            balloon.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            balloon.transform.position = hand.transform.position;
        
       
    }

    public void ScaleBalloon()
    {
        float growThisFrame = scaleFactor * Time.deltaTime;
        Vector3 changeScale = balloon.transform.localScale *
        growThisFrame;
        balloon.transform.localScale += changeScale;
        
        //balloon.transform.position = hand.transform.position;
    }

    public void ReleaseBalloon()
    {
        if (balloon != null)
        {
            SphereCollider[] cols = balloon.GetComponents<SphereCollider>();
            foreach (SphereCollider s in cols)
            {
                s.enabled = true;
            }
            balloon.transform.parent = null;
            Rigidbody rb = balloon.GetComponent<Rigidbody>();
            Vector3 force = Vector3.up * floatStrength;
            rb.AddForce(force);
            GameObject.Destroy(balloon, 10f);
            balloon = null;
        }
        
    
    }
}
