using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

   public Vector2 RawMovementInput { get; private set; }
   public int NormInputX { get; private set; }
   public int NormInputY { get; private set; }
   public bool JumpInput { get; private set; }
   public bool JumpInputStop { get; private set; }
   
   public bool DodgeInput { get; private set; } 
   public bool DodgeInputStop { get; private set; }
   
   public bool ThrowInput { get; private set; }
   public bool ThrowInputStop { get; private set; }
   
   public bool InteractInput { get; private set; }
   public bool InteractInputStop { get; private set; }

    public bool MapInput { get; private set; }
    public bool MapInputStop { get; private set; }

    public bool MapZoomInput { get; private set; }
    public bool MapZoomInputStop { get; private set; }
    public bool MenuTabUpInput { get; private set; }
    public bool MenuTabUpInputStop { get; private set; }
    public bool MenuTabDownInput { get; private set; }
    public bool MenuTabDownInputStop { get; private set; }
    public bool ExitPopupInput { get; private set; }
    public bool ExitPopupInputStop { get; private set; }


    public bool AttackInput { get; private set; }
    public bool AttackInputStop { get; private set; }

    
    public bool DrinkInput { get; private set; }
    public bool DrinkInputStop { get; private set; }


    [SerializeField] private float _inputHoldTime = 0.2f;
   private float jumpInputStartTime;
   private float _dodgeInputStartTime;
   private float _throwInputStartTime;
   private float _interactInputStartTime;
   private float _attackInputStartTime;
    private float _mapInputStartTime;
    private float _mapZoomInputStartTime;
    private float _menuTabUpInputStartTime;
    private float _menuTabDownInputStartTime;
    private float _exitPopupInputStartTime;
    private float _drinkInputStartTime;


    private void Update()
   {
       CheckJumpInputHoldTime();
   }


   public void OnMoveInput(InputAction.CallbackContext context)
   {
      RawMovementInput = context.ReadValue<Vector2>();
      NormInputX = Mathf.RoundToInt(RawMovementInput.x);
      NormInputY = Mathf.RoundToInt(RawMovementInput.y); 
      
   }

   public void OnJumpInput(InputAction.CallbackContext context)
   {
       if (context.started)
       {
           JumpInput = true;
           JumpInputStop = false;
           jumpInputStartTime = Time.time;
       }

       if (context.canceled)
       {
           JumpInputStop = true;
       }
   }

   public void OnDrinkInput(InputAction.CallbackContext context)
   {
       if (context.started)
       {
           DrinkInput = true;
           DodgeInputStop = false;
           _drinkInputStartTime = Time.time;
       }

       if (context.canceled)
       {
           DrinkInput = false;
           DrinkInputStop = true;
       }
   }

   public void OnDodgeInput(InputAction.CallbackContext context)
   {
       if (context.started)
       {
           DodgeInput = true;
           DodgeInputStop = false;
           _dodgeInputStartTime = Time.time;
       }

       if (context.canceled)
       {
           DodgeInputStop = true;
           DodgeInput = false;
       }
       
   }

   public void OnThrowInput(InputAction.CallbackContext context)
   {
       if (context.started)
       {
           ThrowInput = true;
           ThrowInputStop = false;
           _throwInputStartTime = Time.time;
       }

       if (context.canceled)
       {
           ThrowInput = false;
           ThrowInputStop = true;
       }
   }

   public void OnAttackInput(InputAction.CallbackContext context)
   {
       if (context.started)
       {
           AttackInput = true;
           AttackInputStop = false;
           _attackInputStartTime = Time.time;
       }

       if (context.canceled)
       {
           AttackInput = false;
           AttackInputStop = true;
       }
   }

   public void OnInteractInput(InputAction.CallbackContext context)
   {
       if (context.started)
       {
           InteractInput = true;
           InteractInputStop = false;
           _interactInputStartTime = Time.time;
       }

       if (context.canceled)
       {
           InteractInput = false;
           InteractInputStop = true;
       }
   }

    public void OnMapInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            MapInput = true;
            MapInputStop = false;
            _mapInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            MapInput = false;
            MapInputStop = true;
        }
    }
    public void OnMapZoomInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            MapZoomInput = true;
            MapZoomInputStop = false;
            _mapZoomInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            MapZoomInput = false;
            MapZoomInputStop = true;
        }
    }

    public void OnMenuTabUpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            MenuTabUpInput = true;
            MenuTabUpInputStop = false;
            _menuTabUpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            MenuTabUpInput = false;
            MenuTabUpInputStop = true;
        }
    }

    public void OnMenuTabDownInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            MenuTabDownInput = true;
            MenuTabDownInputStop = false;
            _menuTabDownInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            MenuTabDownInput = false;
            MenuTabDownInputStop = true;
        }
    }

    public void OnExitPopupInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ExitPopupInput = true;
            ExitPopupInputStop = false;
            _exitPopupInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            ExitPopupInput = false;
            ExitPopupInputStop = true;
        }
    }

    public void UseJumpInput() => JumpInput = false;

   public void UseDodgeInput() => DodgeInput = false;

   public void UseThrowInput() => ThrowInput = false;

   public void UseAttackInput() => AttackInput = false;

   public void UseInteractInput() => InteractInput = false;

    public void UseMapInput() => MapInput = false;

    public void UseMapZoomInput() => MapZoomInput = false;

    public void UseMenuTabUpInput() => MenuTabUpInput = false;
    public void UseMenuTabDownInput() => MenuTabDownInput = false;
    public void UseExitPopupInput() => ExitPopupInput = false;



    private void CheckJumpInputHoldTime()
   {
       if (Time.time >= jumpInputStartTime + _inputHoldTime)
       {
           JumpInput = false;
       }
       
   }
   
   
}
