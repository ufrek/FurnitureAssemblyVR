using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodJob : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndMe());
    }

    IEnumerator EndMe()
    {
        yield return new WaitForSecondsRealtime(4);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
