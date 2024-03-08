using UnityEngine;

namespace Game.Scripts.System
{
    public class PlayerHealth : Health
    {


        public void SetPlayerHealth(int value)
        {
            HealthValue = value;
        }

        public void PlayerTakeDamage(int value)
        {
            GameManager.Instance.PlayerHealthChanged?.Invoke();
            HealthValue -= value;
        }

        public void PlayerHealDamage(int value)
        {
            GameManager.Instance.PlayerHealthChanged?.Invoke();
            HealthValue += value;
        }
        
}
}