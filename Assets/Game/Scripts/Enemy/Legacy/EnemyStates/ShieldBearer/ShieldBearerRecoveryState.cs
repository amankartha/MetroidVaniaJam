using UnityEngine;

public class ShieldBearerRecoveryState : ShieldBearerState {
    private float recoveryTime = 1.0f; // Recovery time after a charge

    public ShieldBearerRecoveryState(ShieldBearerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter() {
        // Begin recovery countdown
    }

    public override void HandleLogic() {
        // If recovery time elapses, return to PatrolState or AlertState depending on player position
        recoveryTime -= Time.deltaTime;
        if (recoveryTime <= 0) {
            if (PlayerWithinDetectionRange()) {
                stateMachine.ChangeState(stateMachine.alertState);
            } else {
                stateMachine.ChangeState(stateMachine.patrolState);
            }
        }
    }

    public override void Exit() {
        // Reset recovery time for the next cycle
        recoveryTime = 1.0f;
    }

    private bool PlayerWithinDetectionRange() {
        return false;
    }
}