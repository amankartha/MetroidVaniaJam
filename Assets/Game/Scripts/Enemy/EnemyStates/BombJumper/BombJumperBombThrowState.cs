public class BombJumperBombThrowState : BombJumperState {
    public BombJumperBombThrowState(BombJumperStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter() {
    }

    public override void HandleLogic() {
        // Bomb throwing behavior
        if (BombThrown()) {
            stateMachine.ChangeState(stateMachine.patrollingState);
        }
    }

    public override void Exit() {
    }

    private bool BombThrown() {
        // Check if bomb has been thrown
        return true;
    }
}