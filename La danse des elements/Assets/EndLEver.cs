using DG.Tweening;
using KinematicCharacterController.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLEver : MonoBehaviour
{
    private bool liftStarted = false;
    [SerializeField] Transform objectif;
    [SerializeField] Transform plateform;
    [SerializeField] ExamplePlayer player;
    private void OnTriggerStay(Collider other)
    {
        player.interactText.SetActive(true);
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.X) && !liftStarted)
        {
            liftStarted = true;
            plateform.transform.DOMoveY(objectif.position.y, 30f);
            player.Endgame();

        }
    }
}
