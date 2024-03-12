using UnityEngine;

public class BombJumperStateMachine : MonoBehaviour {
    public BombJumperState currentState;
    public BombJumperPatrollingState patrollingState;
    public BombJumperEvasiveJumpState evasiveJumpState;
    public BombJumperBombThrowState bombThrowState;

    void Start() {
        patrollingState = new BombJumperPatrollingState(this);
        evasiveJumpState = new BombJumperEvasiveJumpState(this);
        bombThrowState = new BombJumperBombThrowState(this);
        currentState = patrollingState;
    }

    void Update() {
        currentState.HandleLogic();
    }

    public void ChangeState(BombJumperState newState) {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}