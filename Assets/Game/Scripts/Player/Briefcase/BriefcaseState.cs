using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BriefcaseState 
{
       protected Briefcase _briefcase;
       protected BriefcaseStateMachine _stateMachine;
       protected PlayerData _playerData;
       protected bool _isAnimationFinished;
       protected bool _isExitingState;
    
       protected float _startTime;
       
       private string _animBoolName;
    
       public BriefcaseState(Briefcase briefcase,BriefcaseStateMachine stateMachine, PlayerData playerData,string animBoolName)
       {
          this._briefcase = briefcase;
          this._stateMachine = stateMachine;
          this._playerData = playerData;
          this._animBoolName = animBoolName;
       }
    
       public virtual void Enter()
       {
          DoChecks();
          _briefcase.Anim.SetBool(_animBoolName,true);
          _startTime = Time.time;
          Debug.Log("Entered " + this.GetType().Name + "State");
          _isAnimationFinished = false;
          _isExitingState = false;
       }
    
       public virtual void Exit()
       {
          _briefcase.Anim.SetBool(_animBoolName,false);
          _isExitingState = true;
       }
    
       public virtual void LogicUpdate()
       {
          
       }
    
       public virtual void PhysicsUpdate()
       {
          DoChecks();
       }
    
       public virtual void DoChecks()
       {
          
       }
    
       public virtual void AnimationTrigger()
       {
          
       }
    
       public virtual void AnimationFinishTrigger() => _isAnimationFinished = true;

}
