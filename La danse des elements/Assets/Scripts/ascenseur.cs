using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ascenseur : MonoBehaviour
{
    private bool liftStarted;
   
    [SerializeField] Transform objectif;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")  && !liftStarted)
        {
            liftStarted = true;
            gameObject.transform.DOMoveY(objectif.position.y, 30f);
        }
    }
}
