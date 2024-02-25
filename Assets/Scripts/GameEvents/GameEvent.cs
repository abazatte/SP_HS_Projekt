using System.Collections.Generic;
using UnityEngine;

namespace DinoGame.GameEvents
{
    public abstract class GameEvent : ScriptableObject
    {
        private readonly List<IGameEventListener> _listeners = new();

        public void Raise()
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(IGameEventListener listener)
        {
            _listeners.Add(listener);
        }

        public void UnregisterListener(IGameEventListener listener)
        {
            _listeners.Remove(listener);
        }
    }

    public abstract class GameEvent<T> : ScriptableObject
    {
        private readonly List<IGameEventListener<T>> _listeners = new();

        public void Raise(T value)
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised(value);
            }
        }

        public void RegisterListener(IGameEventListener<T> listener)
        {
            _listeners.Add(listener);
        }

        public void UnregisterListener(IGameEventListener<T> listener)
        {
            _listeners.Remove(listener);
        }
    }
}