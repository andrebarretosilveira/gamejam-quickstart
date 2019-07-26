using UnityEngine;

namespace Euchromata.Core.Variables
{
    [CreateAssetMenu(menuName = "Variables/Int Variable")]
    public class IntVariable : Variable<int>
    {
        public void SetValue(IntVariable value)
        {
            Value = value.Value;
        }

        public void ApplyChange(int amount)
        {
            Value += amount;
        }

        public void ApplyChange(IntVariable amount)
        {
            Value += amount.Value;
        }
    }
}