using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/EnergyIsLow")]
public class EnergyIsLowCondition : Condition
{
    [SerializeField] private bool hasEnergy;

    public override bool Test(FiniteStateMachine fsm)
    {
        if (fsm.GetNavMeshAgent().energy <= 30)
        {
            return !hasEnergy;
        }
        else if (fsm.GetNavMeshAgent().timeController.currentTime.TimeOfDay > TimeSpan.FromHours(20) && fsm.GetNavMeshAgent().timeController.currentTime.TimeOfDay < TimeSpan.FromHours(6))
        {
            return hasEnergy;
        }
        else return !hasEnergy;
    }
}