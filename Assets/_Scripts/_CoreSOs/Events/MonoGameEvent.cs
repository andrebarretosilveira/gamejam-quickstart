using System.Collections.Generic;
using UnityEngine;

namespace Euchromata.Molukas.Core.Events
{
    [CreateAssetMenu(menuName = "Events/Game Event (Monobehavior)")]
    public class MonoGameEvent : ScriptableObject
    {
        private readonly List<MonoGameEventListener> eventListeners =
            new List<MonoGameEventListener>();

        public void Raise(MonoBehaviour param)
        {
            //Debug.Log("Event '" + this.name + "' raised");

            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised(param);
        }

        public void RegisterListener(MonoGameEventListener listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(MonoGameEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }

}