using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    public Player _player;



    public void AnimationEventTrigger()
    {
        _player.StateMachine.CurrentState.AnimationTrigger();
    }

    public void AnimationEventFinish()
    {
        _player.StateMachine.CurrentState.AnimationFinishTrigger();
    }
}
