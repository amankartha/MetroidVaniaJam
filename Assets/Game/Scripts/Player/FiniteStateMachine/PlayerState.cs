using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
   protected Player _player;
   protected PlayerStateMachine _stateMachine;
   protected PlayerData _playerData;

   protected float _startTime;
   
   private string _animBoolName;

   public PlayerState(Player player,PlayerStateMachine stateMachine, PlayerData playerData,string animBoolName)
   {
      this._player = player;
      this._stateMachine = stateMachine;
      this._playerData = playerData;
      this._animBoolName = animBoolName;
   }

   public virtual void Enter()
   {
      DoChecks();
      _player.Anim.SetBool(_animBoolName,true);
      _startTime = Time.time;
      Debug.Log("Entered " + _animBoolName + "State");
   }

   public virtual void Exit()
   {
      _player.Anim.SetBool(_animBoolName,false);
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
   
   
}
