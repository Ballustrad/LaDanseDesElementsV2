using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBreak : MonoBehaviour
{
    private bool bridgeBroke = false;
    [SerializeField] GameObject brdige1;
    [SerializeField] GameObject brdige2;
    [SerializeField] GameObject brdige3;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !bridgeBroke)
        {
            bridgeBroke = true;
            Destroy(brdige1);
            Destroy(brdige2);
            Destroy(brdige3);
        }
    }
}
