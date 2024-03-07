public abstract class BladeGhostState {
    protected BladeGhostStateMachine stateMachine;

    public BladeGhostState(BladeGhostStateMachine stateMachine) {
        this.stateMachine = stateMachine;
    }

    public abstract void Enter();
    public abstract void HandleLogic();
    public abstract void Exit();
}
