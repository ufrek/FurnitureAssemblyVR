using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//counts how many parts are assembled on the chair and ends the game if you build it correctly
public class AssemblyProgressCounter : MonoBehaviour
{
    [SerializeField]
    Camera cam;           //set in Inspector
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
    // Start is called before the first frame update
    public  void IncrementSnap()
    {
        snapCount += 1;
        if(snapCount == 5)
        {
            StartCoroutine(EndGame());
        }
    }

    public void DecrementSnap()
    {
        snapCount -= 1;
    }

     IEnumerator EndGame()
    {
        Vector3 newPos = cam.transform.position;
        newPos += (forwardOffset * cam.transform.forward) + camOffset;
        Instantiate(goodJobPrefab, newPos, cam.transform.rotation);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(2);
    }
}
