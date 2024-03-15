using UnityEngine;

namespace Game.Scripts.System
{
    public class PlayerHealth : Health
    {
        public override void Damage(int value)
        {
            if (!GameManager.Instance.PlayerScript.isInvincible)
            {
                HealthValue -= value;
                if (HealthValue <= 0)
                {
                    GameManager.Instance.OnPlayerDeath?.Invoke();
                }
                else
                {
                    GameManager.Instance.OnPlayerHealthChanged?.Invoke();
                    GameManager.Instance.OnPlayerDamaged?.Invoke();
                    GameManager.Instance.PlayerScript.StateMachine.ChangeState(GameManager.Instance.PlayerScript
                        .DamagedState);
                }
            }
        }

        public void DamageWithKnockBack(int value, float velocity, Vector2 angle, int direction)
        {
            if (!GameManager.Instance.PlayerScript.isInvincible)
            {
                GameManager.Instance.PlayerScript.SetVelocity(velocity,angle,direction);
                
                HealthValue -= value;
                if (HealthValue <= 0)
                {
                    GameManager.Instance.OnPlayerDeath?.Invoke();
                }
                else
                {
                    GameManager.Instance.OnPlayerHealthChanged?.Invoke();
                    GameManager.Instance.OnPlayerDamaged?.Invoke();
                    GameManager.Instance.PlayerScript.StateMachine.ChangeState(GameManager.Instance.PlayerScript
                        .DamagedState);
                }
            }
        }

        public override void Heal(int value)
        {
            base.Heal(value);
            GameManager.Instance.OnPlayerHealthChanged?.Invoke();
        }
        
    }
}