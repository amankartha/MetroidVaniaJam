using UnityEngine;

namespace Game.Scripts.System
{
    public class PlayerHealth : Health
    {
        public override void Damage(int value)
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
                GameManager.Instance.PlayerScript.StateMachine.ChangeState(GameManager.Instance.PlayerScript.DamagedState);
            }
        }

        public override void Heal(int value)
        {
            base.Heal(value);
            GameManager.Instance.OnPlayerHealthChanged?.Invoke();
        }
        
    }
}