public class BombJumperPatrollingState : BombJumperState {
    public BombJumperPatrollingState(BombJumperStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter() {
    }

    public override void HandleLogic() {
        // Patrolling behavior
        if (PlayerWithinDetectionRange()) {
            stateMachine.ChangeState(stateMachine.evasiveJumpState);
        }
    }

    public override void Exit() {
    }

    private bool PlayerWithinDetectionRange() {
        return false;
    }
}