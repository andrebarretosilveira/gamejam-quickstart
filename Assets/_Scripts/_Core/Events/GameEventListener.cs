using UnityEngine;
using UnityEngine.Events;

namespace Euchromata.Core.Events
{
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent Event;

        [Space]

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Debug.Log("Event '" + Event.name + "' listened by '" + this.gameObject.name + "'");

            Response.Invoke();
        }
    }
}