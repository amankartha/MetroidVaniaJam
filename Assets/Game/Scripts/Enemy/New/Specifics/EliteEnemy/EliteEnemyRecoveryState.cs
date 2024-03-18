using UnityEngine;


public class EliteEnemyRecoveryState : EnemyRecoveryState
{
    private EliteEnemy _enemy;
    
    public EliteEnemyRecoveryState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_RecoveryState data,EliteEnemy enemy) : base(entity, stateMachine, animBoolName, data)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time > _startTime + _stateData.RecoveryDuration)
        {
            _stateMachine.ChangeState(_enemy.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }
}
