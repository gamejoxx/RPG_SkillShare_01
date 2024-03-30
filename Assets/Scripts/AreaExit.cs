using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

private void OnTriggerEnter2D(Collider2D nextarea)
    {
    if(nextarea.tag == "Player")
        {
        Debug.Log("Player entered the exit zone");
         }
    }
}
