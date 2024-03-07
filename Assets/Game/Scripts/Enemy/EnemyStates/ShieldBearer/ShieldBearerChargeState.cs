public class ShieldBearerChargeState : ShieldBearerState {
    public ShieldBearerChargeState(ShieldBearerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter() {
    }

    public override void HandleLogic() {
        // Move towards the player at ChargeSpeed
        // After charge, transition to RecoveryState
        if (ChargeComplete()) {
            stateMachine.ChangeState(stateMachine.recoveryState);
        }
    }

    public override void Exit() {
    }

    private bool ChargeComplete() {
        return true;
    }
}