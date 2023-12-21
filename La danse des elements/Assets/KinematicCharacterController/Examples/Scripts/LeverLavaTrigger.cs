using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LeverLavaTrigger : MonoBehaviour
{
    
    private bool leverEnable = false;
    private bool herseDown = false;
    [SerializeField] Transform lavaTransform;
    [SerializeField] Transform herseTransform;
    [SerializeField] Transform lavaTarget;
    [SerializeField] Transform herseTarget;
    private Vector3 defaultPose;
    

    private float lavaSpeed = 5;
    private void Start()
    {
        defaultPose = lavaTransform.position;   
    }
    private void OnTriggerStay(Collider other)
    {
             
        if (Input.GetKey(KeyCode.X) && !leverEnable)
        {

            leverEnable = true;
            herseTransform.DOMoveY(herseTarget.position.y, 10f).OnComplete(() => { lavaTransform.DOMoveY(lavaTarget.position.y, 5f); });
                 

               
              
            
        }
    }
    


   
   
}
