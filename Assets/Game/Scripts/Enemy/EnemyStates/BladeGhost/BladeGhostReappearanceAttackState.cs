public class BladeGhostReappearanceAttackState : BladeGhostState {
    public BladeGhostReappearanceAttackState(BladeGhostStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter() {
    }

    public override void HandleLogic() {
        // Perform the attack then switch to recoveryState.
        stateMachine.ChangeState(stateMachine.recoveryState);
    }

    public override void Exit() {
    }
}