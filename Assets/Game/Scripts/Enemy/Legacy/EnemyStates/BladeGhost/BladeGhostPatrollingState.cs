public class BladeGhostPatrollingState : BladeGhostState {
    public BladeGhostPatrollingState(BladeGhostStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter() {
    }

    public override void HandleLogic() {
        // switch to swordProjectileState if player detected.
        if (IsPlayerDetected()) {
            stateMachine.ChangeState(stateMachine.swordProjectileState);
        }
    }

    public override void Exit() {
    }

    private bool IsPlayerDetected() {
        return false;
    }
}