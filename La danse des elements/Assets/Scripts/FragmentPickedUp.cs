using KinematicCharacterController.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentPickedUp : MonoBehaviour
{
    public PlateformPathing platformPathing;
    public ExamplePlayer player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.hasFragmentKey = true;
            platformPathing.MovePlatformOnPath();
            Destroy(gameObject);
        }
        

    }
}
