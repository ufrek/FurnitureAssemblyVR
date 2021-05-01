using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCollision : MonoBehaviour
{
    [SerializeField]
    AudioClip sPop;
    [SerializeField]
    AudioSource soundMgr;


    // Start is called before the first frame update
    void Start()
    {
        soundMgr = GameObject.FindGameObjectWithTag("SoundMgr").GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball")
        {
           
            soundMgr.PlayOneShot(sPop);
  
            Destroy(this.gameObject);


        }

    }



}
