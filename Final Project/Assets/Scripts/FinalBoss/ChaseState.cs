using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public MeleeState meleeState;
    public bool isInAttackRange;
    public override State RunCurrentState()
    {
        if(isInAttackRange)
        {
            return meleeState;
        }
        else
        {
            return this;
        }
    }
}
