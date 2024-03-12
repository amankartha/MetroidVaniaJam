using UnityEngine;

public class BladeGhostStateMachine : MonoBehaviour {
    public BladeGhostState currentState;
    public BladeGhostPatrollingState patrollingState;
    public BladeGhostSwordProjectileState swordProjectileState;
    public BladeGhostReappearanceAttackState reappearanceAttackState;
    public BladeGhostRecoveryState recoveryState;
    public BladeGhostTeleportBackState teleportBackState;

    void Start() {
        patrollingState = new BladeGhostPatrollingState(this);
        swordProjectileState = new BladeGhostSwordProjectileState(this);
        reappearanceAttackState = new BladeGhostReappearanceAttackState(this);
        recoveryState = new BladeGhostRecoveryState(this);
        teleportBackState = new BladeGhostTeleportBackState(this);
        currentState = patrollingState;
    }

    void Update() {
        currentState.HandleLogic();
    }

    public void ChangeState(BladeGhostState newState) {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}