using UnityEngine;

public class ShieldBearerStateMachine : MonoBehaviour {
    public ShieldBearerState currentState;
    public ShieldBearerPatrolState patrolState;
    public ShieldBearerAlertState alertState;
    public ShieldBearerChargeState chargeState;
    public ShieldBearerRecoveryState recoveryState;

    // Initialize states
    void Start() {
        patrolState = new ShieldBearerPatrolState(this);
        alertState = new ShieldBearerAlertState(this);
        chargeState = new ShieldBearerChargeState(this);
        recoveryState = new ShieldBearerRecoveryState(this);
        currentState = patrolState;
    }

    // Update is called once per frame
    void Update() {
        currentState.HandleLogic();
    }

    public void ChangeState(ShieldBearerState newState) {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}