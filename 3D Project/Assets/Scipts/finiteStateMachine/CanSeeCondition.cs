using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/CanSeeCondition")]
public class CanSeeCondition : Condition
{
    [SerializeField] private bool negation;
    [SerializeField] private float viewAngle;
    [SerializeField] private float viewDistance;
    public override bool Test(FiniteStateMachine fsm)
    {
        if (fsm.name == "Snake")
        {
            return true;
        }
        else
        {
            Vector3 direction = fsm.GetNavMeshAgent().target.position - fsm.GetNavMeshAgent().transform.position;
            if (direction.magnitude < viewDistance)
            {
                float angle = Vector3.Angle(direction.normalized, fsm.GetNavMeshAgent().transform.forward);
                if (angle < viewAngle)
                {
                    return !negation;
                }
            }

            return negation;
        }

    }
}