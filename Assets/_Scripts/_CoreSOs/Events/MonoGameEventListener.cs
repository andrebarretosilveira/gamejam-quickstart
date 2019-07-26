using UnityEngine;
using UnityEngine.Events;

namespace Euchromata.Molukas.Core.Events
{
    public class MonoGameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public MonoGameEvent gameEvent;

        [Space]

        [Tooltip("Response to invoke when Event is raised.")]
        public SelectionUnityEvent response;

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(MonoBehaviour param)
        {
            //Debug.Log("Event '" + Event.name + "' listened by '" + this.gameObject.name + "'");

            response.Invoke(param);
        }

        [System.Serializable]
        public class SelectionUnityEvent : UnityEvent<MonoBehaviour> { }
    }
}