using KinematicCharacterController.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateQuest : MonoBehaviour
{
    [SerializeField] ExamplePlayer player;
    [SerializeField] string questline;
    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player"))
        {
            player.UpdateQuestText(questline);
        }
    }
}
