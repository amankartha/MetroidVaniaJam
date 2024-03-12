public class BladeGhostSwordProjectileState : BladeGhostState {
    public BladeGhostSwordProjectileState(BladeGhostStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter() {
    }

    public override void HandleLogic() {
        // After launching, switch to reappearanceAttackState.
        stateMachine.ChangeState(stateMachine.reappearanceAttackState);
    }

    public override void Exit() {
    }
}