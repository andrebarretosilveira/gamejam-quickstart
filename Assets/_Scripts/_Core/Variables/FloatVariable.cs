using UnityEngine;

namespace Euchromata.Core.Variables
{
    [CreateAssetMenu]
    public class FloatVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public float Value;

        [Space]

        public bool ResetOnStart = true;
        [ConditionalHide("ResetOnStart")]
        public float StartingValue;

        private void OnEnable()
        {
            if(ResetOnStart) Value = StartingValue;
        }

        public void SetValue(float value)
        {
            Value = value;
        }

        public void SetValue(FloatVariable value)
        {
            Value = value.Value;
        }

        public void ApplyChange(float amount)
        {
            Value += amount;
        }

        public void ApplyChange(FloatVariable amount)
        {
            Value += amount.Value;
        }
    }
}