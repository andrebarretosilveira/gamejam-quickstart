using UnityEngine;
using UnityEngine.Events;

namespace Euchromata.Core.Events
{
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("In-game event to register with.")]
        public GameEvent gameEvent;

        [Space]

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent response;

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Debug.Log("Event '" + gameEvent.name + "' listened by '" + this.gameObject.name + "'");

            response.Invoke();
        }
    }
}