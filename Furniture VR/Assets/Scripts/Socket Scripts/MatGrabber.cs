using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Reference of all materials of object to change after checked for snap validity
public class MatGrabber : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] changeableObjs;
    public BoxCollider[] cols;
    public GameObject[] getObjsToChange()
    {
        return changeableObjs;
    }

    public void ResetLayer()
    {
        foreach (GameObject g in changeableObjs)
        {
            g.layer = 0;
        }
    }
}
