using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoovingState : State
{
    public override void OnEnterState()
    {
        print("J'entre dans l'�tat mooving");
    }

    public override void OnExitState()
    {
        print("je quitte mon �tat d'attaque");
    }

    public override void UpdateState()
    {
        //Se d�place et suis le joueur

        //if(playerinrange === true){
        GetComponent<StateManager>().SwitchState(GetComponent<StateManager>().attacking);

    }
}
