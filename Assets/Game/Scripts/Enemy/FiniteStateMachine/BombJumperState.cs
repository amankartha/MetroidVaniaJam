public abstract class BombJumperState {
    protected BombJumperStateMachine stateMachine;

    public BombJumperState(BombJumperStateMachine stateMachine) {
        this.stateMachine = stateMachine;
    }

    public abstract void Enter();
    public abstract void HandleLogic();
    public abstract void Exit();
}