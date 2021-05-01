using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class BallController : MonoBehaviour
{

    public GameObject[] ballPrefab;
    public GameObject hand;
    private GameObject ball;
    private Rigidbody rb;
    private Transform startPosition;
    private GameObject currentBall;



    [SerializeField]
    private float floatStrength = 20;
    [SerializeField]
    private float scaleFactor = .1f;
    InputDevice device;

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
        if (ball != null)
        {
            ScaleBall();
        }

    }

    public void CreateBall(GameObject parentHand)
    {
        int rndIndex = Random.Range(0, ballPrefab.Length);
        ball = Instantiate(ballPrefab[rndIndex], parentHand.transform);
        ball.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        ball.transform.position = hand.transform.position;
        rb = ball.GetComponent<Rigidbody>();
        
        rb.isKinematic = true;

    }

    public void ScaleBall()
    {
        float growThisFrame = scaleFactor * Time.deltaTime;
        Vector3 changeScale = ball.transform.localScale *
        growThisFrame;
        ball.transform.localScale += changeScale;

        //balloon.transform.position = hand.transform.position;
    }
    public void SetBall(GameObject pickedBall)
    {
        print("working");
        ball = pickedBall;
    }
    public void ReleaseBall()
    {
        /*ball.transform.parent = null;
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        Vector3 force = Vector3.up * floatStrength;
        rb.AddForce(force);*/
        rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        //GameObject.Destroy(ball, 5f);
        ball = null;
    }

    
}
