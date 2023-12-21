using KinematicCharacterController.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPerso : MonoBehaviour
{
    public ExamplePlayer player;
    public LayerMask lavaLayer;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == lavaLayer)
        {
            player.Death();
        }
    }
}
