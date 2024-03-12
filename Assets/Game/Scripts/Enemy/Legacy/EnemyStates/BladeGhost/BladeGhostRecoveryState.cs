public class BladeGhostRecoveryState : BladeGhostState {
    public BladeGhostRecoveryState(BladeGhostStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter() {
    }

    public override void HandleLogic() {
        // After recovering, decide next state based on player's location.
        if (IsPlayerFar()) {
            stateMachine.ChangeState(stateMachine.patrollingState);
        } else {
            stateMachine.ChangeState(stateMachine.teleportBackState);
        }
    }

    public override void Exit() {
    }

    private bool IsPlayerFar() {
        // Check player's distance to decide on the next state.
        return true;
    }
}