using UnityEngine;

namespace Euchromata.Core.Variables
{
    [CreateAssetMenu(menuName = "Variables/Bool Variable")]
    public class BoolVariable : Variable<bool>
    {

        public void SetValue(BoolVariable value)
        {
            Value = value.Value;
        }

    }
}