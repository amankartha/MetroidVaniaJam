using UnityEngine;

public class ShieldBearerAlertState : ShieldBearerState {
    private float chargeUpTime = 0.5f; // Time before charging

    public ShieldBearerAlertState(ShieldBearerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter() {
        // Begin charge-up timer
    }

    public override void HandleLogic() {
        // If charge-up time elapses and player is still within range, transition to ChargeState
        chargeUpTime -= Time.deltaTime;
        if (chargeUpTime <= 0 && PlayerWithinAttackRange()) {
            stateMachine.ChangeState(stateMachine.chargeState);
        } else if (!PlayerWithinDetectionRange()) {
            // If player exits detection range, return to PatrolState
            stateMachine.ChangeState(stateMachine.patrolState);
        }
    }

    public override void Exit() {
        // Reset charge-up time for the next alert
        chargeUpTime = 0.5f;
    }

    private bool PlayerWithinAttackRange() {
        return true;
    }

    private bool PlayerWithinDetectionRange() {
        return false;
    }
}