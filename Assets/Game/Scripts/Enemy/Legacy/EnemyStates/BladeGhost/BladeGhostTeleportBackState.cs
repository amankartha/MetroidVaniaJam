public class BladeGhostTeleportBackState : BladeGhostState {
    public BladeGhostTeleportBackState(BladeGhostStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter() {
    }

    public override void HandleLogic() {
        // After teleporting, switch to patrollingState.
        stateMachine.ChangeState(stateMachine.patrollingState);
    }

    public override void Exit() {
    }
}