using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using KinematicCharacterController.Examples;

namespace KinematicCharacterController.Examples
{
    public class Teleporter : MonoBehaviour
    {
        public Teleporter TeleportTo;
        public ExamplePlayer player;
        public UnityAction<ExampleCharacterController> OnCharacterTeleport;

        public bool isBeingTeleportedTo { get; set; }

        private void OnTriggerStay(Collider other)
        {
            
            
                if (!isBeingTeleportedTo && player.tpAuthorized == true)
                {
                    ExampleCharacterController cc = other.GetComponent<ExampleCharacterController>();
                    if (cc)
                    {
                        cc.Motor.SetPositionAndRotation(TeleportTo.transform.position, TeleportTo.transform.rotation);

                        if (OnCharacterTeleport != null)
                        {
                            OnCharacterTeleport(cc);
                        }
                        TeleportTo.isBeingTeleportedTo = true;
                        player.tpAuthorized = false;
                    }
                }

                isBeingTeleportedTo = false;
            
                
        }
    }
}