using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Attack")]
public class AttackAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        if (fsm.gameObject.name == "Crocodile") fsm.GetNavMeshAgent().CrocodileAttack();
        else if (fsm.gameObject.name == "Butterfly") fsm.GetNavMeshAgent().ButterflyAttack();

    }
}
