﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
//trigger for back fo chair, checks for "Back" tag and handles checking of furniture parts for snapping
public class BackTrigger : MonoBehaviour
{
    [SerializeField]
    BoxCollider chairBottom;
    [SerializeField]
    BoxCollider floor;
    GameObject[] gos;
    Color originalColor = Color.white;
    bool isValid = false;
    bool isSnapped = false;
    GameObject[] curObject = new GameObject[2];
    GameObject[] snappedObject = new GameObject[2];

    private void OnTriggerEnter(Collider other)
    {
        if (!isSnapped)
        {

            if (other.gameObject.tag.Equals("Back"))
            {


                curObject[0] = other.gameObject;
                curObject[1] = other.transform.parent.gameObject;

                isValid = true;
                GameObject[] objs = other.gameObject.GetComponent<MatGrabber>().getObjsToChange();
                gos = objs;
                foreach (GameObject go in objs)
                {
                    go.GetComponent<Renderer>().material.color = Color.green;
                }
                //originalColor = objs[0].gameObject.GetComponent<Renderer>().material.color;

                this.GetComponent<XRSocketInteractor>().socketActive = true;
            }
            else if (other.gameObject.tag.Equals("Floor"))
            { }
            else
            {
                if (other.gameObject.GetComponent<MatGrabber>() != null && !isValid)
                {
                    GameObject[] objs = other.gameObject.GetComponent<MatGrabber>().getObjsToChange();
                    foreach (GameObject go in objs)
                    {
                        go.GetComponent<Renderer>().material.color = Color.red;
                    }
                }
            }
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (!isSnapped)
        {

            if (!other.gameObject.tag.Equals("Floor"))
            {
                if (other.gameObject.GetComponent<MatGrabber>() != null)
                {
                    GameObject[] objs = other.gameObject.GetComponent<MatGrabber>().getObjsToChange();
                    foreach (GameObject go in objs)
                    {
                        go.GetComponent<Renderer>().material.color = originalColor;
                    }
                }

            }
            if (other.gameObject.tag.Equals("Back"))
            {
                this.GetComponent<XRSocketInteractor>().socketActive = false;
                for (int i = 0; i < curObject.Length; i++)
                {
                    curObject[i] = null;
                }
            }
            //originalColor = Color.clear;
            gos = null;
            isValid = false;
        }


    }

    public void SnapObject()
    {
        isSnapped = true;
        //playSound here
        if (gos != null)
        {
            GameObject[] objs = gos;
            foreach (GameObject go in objs)
            {
                go.GetComponent<Renderer>().material.color = originalColor;
            }
        }
        if (curObject[0] != null)
        {
            for (int i = 0; i < curObject.Length; i++)
            {

                Physics.IgnoreCollision(chairBottom, curObject[i].GetComponent<BoxCollider>(), true);
                Physics.IgnoreCollision(curObject[i].GetComponent<BoxCollider>(), this.GetComponentInChildren<BoxCollider>(), true);
            }

            snappedObject = curObject;
        }

        this.GetComponentInChildren<BoxCollider>().enabled = true;
        AssemblyProgressCounter.S.IncrementSnap();
    }


    public void UnsnapObject()
    {
        isSnapped = false;
        if (snappedObject[0] != null)
        {
            for (int i = 0; i < snappedObject.Length; i++)
            {

                Physics.IgnoreCollision(chairBottom, snappedObject[i].GetComponent<BoxCollider>(), false);
                snappedObject[i] = null;
            }
        }
        this.GetComponentInChildren<BoxCollider>().enabled = false;
        AssemblyProgressCounter.S.DecrementSnap();
    }

}