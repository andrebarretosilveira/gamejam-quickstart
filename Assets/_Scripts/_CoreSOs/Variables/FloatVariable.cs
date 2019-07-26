using UnityEngine;

namespace Euchromata.Core.Variables
{
    [CreateAssetMenu(menuName = "Variables/Float Variable")]
    public class FloatVariable : Variable<float>
    {
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