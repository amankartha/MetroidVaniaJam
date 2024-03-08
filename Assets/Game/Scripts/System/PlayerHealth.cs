using UnityEngine;

namespace Game.Scripts.System
{
    public class PlayerHealth : Health
    {
        public override void Damage(int value)
        {
            base.Damage(value);
            GameManager.Instance.PlayerHealthChanged?.Invoke();
        }

        public override void Heal(int value)
        {
            base.Heal(value);
            GameManager.Instance.PlayerHealthChanged?.Invoke();
        }
    }
}