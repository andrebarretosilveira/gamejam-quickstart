using Euchromata.Core.Sets;
using UnityEngine;
using UnityEngine.Serialization;

namespace Euchromata.Core.Variables
{
    [CreateAssetMenu]
    public class PoolObject : ScriptableObject
    {
        [FormerlySerializedAs("Set")]
		public PoolObjectsSet set;

        [FormerlySerializedAs("Prefab")]
        public GameObject prefab;
        [FormerlySerializedAs("Amount")]
		public int amount;
        [FormerlySerializedAs("CanExpand")]
        public bool canExpand;

        private void OnEnable()
        {
			set.Add(this);
        }

        private void OnDisable()
        {
            set.Remove(this);
        }

    }
}