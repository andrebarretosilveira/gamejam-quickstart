using Euchromata.Core.Sets;
using UnityEngine;

namespace Euchromata.Core.Variables
{
    [CreateAssetMenu]
    public class PoolObject : ScriptableObject
    {
		public PoolObjectsSet Set;

        public GameObject Prefab;
		public int Amount;
        public bool CanExpand;

        private void OnEnable()
        {
			Set.Add(this);
        }

        private void OnDisable()
        {
            Set.Remove(this);
        }

    }
}