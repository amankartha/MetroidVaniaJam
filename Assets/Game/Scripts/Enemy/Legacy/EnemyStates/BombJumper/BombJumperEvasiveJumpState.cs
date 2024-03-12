public class BombJumperEvasiveJumpState : BombJumperState {
    public BombJumperEvasiveJumpState(BombJumperStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter() {
    }

    public override void HandleLogic() {
        // Evasive jumping behavior
        if (AtApexOfJump()) {
            stateMachine.ChangeState(stateMachine.bombThrowState);
        }
    }

    public override void Exit() {
    }

    private bool AtApexOfJump() {
        return false;
    }
}