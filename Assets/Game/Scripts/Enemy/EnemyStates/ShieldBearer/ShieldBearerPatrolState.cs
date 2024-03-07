public class ShieldBearerPatrolState : ShieldBearerState {
    public ShieldBearerPatrolState(ShieldBearerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter() {
    }

    public override void HandleLogic() {
        // move between points, check for player in detection range
        // If player detected, transition to AlertState
        if (PlayerDetected()) {
            stateMachine.ChangeState(stateMachine.alertState);
        }
    }

    public override void Exit() {
    }

    private bool PlayerDetected() {
        return false; 
    }
}