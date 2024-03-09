using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Scene.Interactables
{
    [CreateAssetMenu(fileName = "InteractableData", menuName = "Data/Interactables/baseInteractablesData", order = 0)]
    public class InteractablesData : ScriptableObject
    {
         [Header("Spikes")] 
        public int SpikesDamage = 1;
        public float SpikesKnockBackPower = 1f;
        [Header("Saw")]
        public int SawDamage = 1;
    }
}