using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

//Respawns ball if it is not in its original position in opening scene
public class BallRespawner : MonoBehaviour
{
    Vector3 startPos;
    GameObject ball;
    XRInteractionManager mgr;

    [SerializeField]
    GameObject goodJobPrefab;       //set in inspector
    [SerializeField]
    Camera cam;           //set in Inspector
    [SerializeField]
    float forwardOffset = 2;
    [SerializeField]
    Vector3 camOffset = Vector3.zero;

    public bool isHeld = false;
    bool needsRespawn = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        ball = this.gameObject;
        mgr = GameObject.Find("XR Interaction Manager").GetComponent<XRInteractionManager>();

        InvokeRepeating("PositionChecker", 5, 5);
    }

    public void SetHolding(bool held)
    {
        isHeld = held;
    }
    void PositionChecker()
    {
        if (needsRespawn)
        {
            needsRespawn = false;
            ReplaceBallDebug();
        }
        else if (!isHeld && Vector3.Distance(this.transform.position, startPos) > 1)
        {
            needsRespawn = true;
        }
    }
    public void Respawn() //calls when thrown
    {
        DisplayGoodJob();
        StartCoroutine(ReplaceBall());
    }
    void DisplayGoodJob()
    {
      
        Vector3 newPos = cam.transform.position;
        newPos += (forwardOffset * cam.transform.forward)+camOffset;
        Instantiate(goodJobPrefab, newPos, cam.transform.rotation);
       

    }
    IEnumerator ReplaceBall()
    {
        yield return new WaitForSeconds(5);
        while (this.transform.parent != null)
        {
            yield return new WaitForSeconds(5);
        }
        this.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(.5f);
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        this.gameObject.transform.position = startPos;
        this.GetComponent<MeshRenderer>().enabled = true;
        ScoringMechanic.S.IncrementScore();
  
    }

    void ReplaceBallDebug()
    {
       
      
 
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        this.gameObject.transform.position = startPos;
    
       

    }
}
