using KinematicCharacterController.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropulsionSkill : MonoBehaviour
{
   
    public ExampleCharacterController exampleCharacterController;
    public Vector3 propelForce;
    public float slowFall;
    public float airMoveSpeed;
    public float airAccelerationSpeed;

    private void Start()
    {
        // Récupère le composant Rigidbody attaché au joueur
        
        // Désactive la gravité initialement
       
    }

    public void PropelInAir()
    {

        StartCoroutine(SlowFall());
        
    }
    
    public IEnumerator SlowFall()
    {
        exampleCharacterController.AddVelocity(propelForce);
        yield return new WaitForSeconds(1f);
        exampleCharacterController.Drag = slowFall;
        exampleCharacterController.MaxAirMoveSpeed = airMoveSpeed;
        exampleCharacterController.AirAccelerationSpeed = airAccelerationSpeed;
    }
}
