using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemyMoveState : EnemyMoveState
{
    private EliteEnemy _enemy;

    public EliteEnemyMoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData,EliteEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        _enemy = enemy;
    }
}
