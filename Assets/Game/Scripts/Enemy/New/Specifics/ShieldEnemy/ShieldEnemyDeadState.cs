using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemyDeadState : EnemyDeadState
{
    private ShieldEnemy Enemy;
    public ShieldEnemyDeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData,ShieldEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.Enemy = enemy;
    }
    
    
}
