using UnityEngine;

namespace Euchromata.Core.Variables
{
    public abstract class Variable<T> : ScriptableObject
    {

#if UNITY_EDITOR
        [Multiline]
        public string developerDescription = "";
#endif


        [SerializeField]
        protected T value = default;

        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }

        [Space]
        public bool resetOnStart = true;

        [ConditionalHide("ResetOnStart")]
        public T startingValue;


        private void OnEnable()
        {
            if (resetOnStart) Value = startingValue;
        }

        public void SetValue(T value)
        {
            Value = value;
        }

    }
}