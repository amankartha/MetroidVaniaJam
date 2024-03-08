using UnityEngine;

public class BombJumperHazardCreationState : BombJumperState {
    private float hazardDuration;

    public BombJumperHazardCreationState(BombJumperStateMachine stateMachine, float duration) : base(stateMachine) {
        this.hazardDuration = duration;
    }

    public override void Enter() {
        // Create the hazardous area effect
        CreateHazard();
    }

    public override void HandleLogic() {
        // Wait for the hazard duration to elapse
        hazardDuration -= Time.deltaTime;
        if (hazardDuration <= 0) {
            stateMachine.ChangeState(stateMachine.patrollingState);
        }
    }

    public override void Exit() {
    }

    private void CreateHazard() {
        // Instantiate the hazard effect at the bomb's explosion location.
    }
}