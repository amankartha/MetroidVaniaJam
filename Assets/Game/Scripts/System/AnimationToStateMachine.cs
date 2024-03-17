using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStateMachine : MonoBehaviour
{
    public AttackState AttackStateScript;

    private void TriggerAttack()
    {
        AttackStateScript.TriggerAttack();
    }

    private void FinishAttack()
    {
        AttackStateScript.FinishAttack();
    }
}
