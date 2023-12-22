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
    public GameObject windcollumn;
    private GameObject windColumnInstance;




    public void PropelInAir()
    {
        
        StartCoroutine(SlowFall());
        windColumnInstance = Instantiate(windcollumn, transform.position, Quaternion.identity);
        if (audioSource != null && floatingSound != null)
        {
            // Joue le son depuis l'AudioSource du soundManager
            audioSource.PlayOneShot(floatingSound);
        }
    }
    
    public IEnumerator SlowFall()
    {
        exampleCharacterController.AddVelocity(propelForce);
        yield return new WaitForSeconds(1f);
        exampleCharacterController.Drag = slowFall;
        exampleCharacterController.MaxAirMoveSpeed = airMoveSpeed;
        exampleCharacterController.AirAccelerationSpeed = airAccelerationSpeed;
        yield return new WaitForSeconds(4f);
        Destroy(windColumnInstance, 5.0f);

    }
}
