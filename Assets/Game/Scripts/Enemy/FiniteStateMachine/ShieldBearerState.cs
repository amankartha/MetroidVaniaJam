public abstract class ShieldBearerState {
    protected ShieldBearerStateMachine stateMachine;

    public ShieldBearerState(ShieldBearerStateMachine stateMachine) {
        this.stateMachine = stateMachine;
    }

    public abstract void Enter();
    public abstract void HandleLogic();
    public abstract void Exit();
}