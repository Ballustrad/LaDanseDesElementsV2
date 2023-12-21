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
    public AudioClip floatingSound;
    public AudioSource audioSource;
    private void Start()
    {
        // R�cup�re le composant Rigidbody attach� au joueur
        
        // D�sactive la gravit� initialement
       
    }

    public void PropelInAir()
    {

        StartCoroutine(SlowFall());
        
    }
    
    public IEnumerator SlowFall()
    {
        exampleCharacterController.AddVelocity(propelForce);
        yield return new WaitForSeconds(1f);
        if (audioSource != null && floatingSound != null)
        {
            // Joue le son depuis l'AudioSource du soundManager
            audioSource.PlayOneShot(floatingSound);
        }
        exampleCharacterController.Drag = slowFall;
        exampleCharacterController.MaxAirMoveSpeed = airMoveSpeed;
        exampleCharacterController.AirAccelerationSpeed = airAccelerationSpeed;
    }
}
