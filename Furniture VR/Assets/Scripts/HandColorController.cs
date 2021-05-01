using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandColorController : MonoBehaviour
{
    [SerializeField]
    GameObject leftHand;
    [SerializeField]
    GameObject rightHand;

    // Start is called before the first frame update
    public void RedHands()
    {
        Renderer[] leftR = leftHand.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in leftR)
        {
            r.material.color = Color.red;
        }

        Renderer[] rightR = rightHand.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rightR)
        {
            r.material.color = Color.red;
        }

    }

    public void WhiteHands()
    {
        Renderer[] leftR = leftHand.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in leftR)
        {
            r.material.color = Color.white;
        }

        Renderer[] rightR = rightHand.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rightR)
        {
            r.material.color = Color.white;
        }
    }

    public void BlueHands()
    {
        Renderer[] leftR = leftHand.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in leftR)
        {
            r.material.color = Color.blue;
        }

        Renderer[] rightR = rightHand.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rightR)
        {
            r.material.color = Color.blue;
        }
    }
}
