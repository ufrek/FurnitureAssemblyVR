using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//counts how many parts are assembled on the chair and ends the game if you build it correctly
public class AssemblyProgressCounter : MonoBehaviour
{
    [SerializeField]
    Camera cam;           //////////set in Inspector
    [SerializeField]
    GameObject goodJobPrefab;
    [SerializeField]
    float forwardOffset = 20;
    [SerializeField]
    Vector3 camOffset = new Vector3(-4, 0, 0);
    public static AssemblyProgressCounter S;
    static int snapCount;

    
     void Start()
    {
        S = this;
        snapCount = 0;
    }
    // Event System Calls When Any Piece of Furniture is Snapped via SnapObject() in Trigger Scripts
    public  void IncrementSnap()
    {
        snapCount += 1;
        if(snapCount == 5)
        {
            StartCoroutine(EndGame());
        }
    }

    // Event System Calls When Any Piece of Furniture is Snapped via UnsnapObject() in Trigger Scripts
    public void DecrementSnap()
    {
        snapCount -= 1;
    }

    //Displays "good job" and goes to final scene
     IEnumerator EndGame()
    {
        Vector3 newPos = cam.transform.position;
        newPos += (forwardOffset * cam.transform.forward) + camOffset;
        Instantiate(goodJobPrefab, newPos, cam.transform.rotation);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(2);
    }
}
