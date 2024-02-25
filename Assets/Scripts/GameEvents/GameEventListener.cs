using UnityEngine;
using UnityEngine.Events;

namespace DinoGame.GameEvents
{
    public abstract class GameEventListener : MonoBehaviour, IGameEventListener
    {
        [SerializeField] private GameEvent gameEvent;
        [SerializeField] private UnityEvent unityEvent;

        public GameEvent GameEvent
        {
            get => gameEvent;
            set
            {
                UnregisterListener();
                gameEvent = value;
                RegisterListener();
            }
        }

        public UnityEvent UnityEvent
        {
            get => unityEvent;
            set => unityEvent = value;
        }

        private void Awake()
        {
            UnityEvent ??= new UnityEvent();
        }

        private void OnEnable()
        {
            RegisterListener();
        }

        private void OnDisable()
        {
            UnregisterListener();
        }

        public void OnEventRaised()
        {
            UnityEvent?.Invoke();
        }

        private void UnregisterListener()
        {
            if (GameEvent != null)
            {
                GameEvent.UnregisterListener(this);
            }
        }

        private void RegisterListener()
        {
            if (GameEvent != null)
            {
                GameEvent.RegisterListener(this);
            }
        }
    }

    public abstract class GameEventListener<T> : MonoBehaviour, IGameEventListener<T>
    {
        [SerializeField] private GameEvent<T> gameEvent;
        [SerializeField] private UnityEvent<T> unityEvent;

        public GameEvent<T> GameEvent
        {
            get => gameEvent;
            set
            {
                UnregisterListener();
                gameEvent = value;
                RegisterListener();
            }
        }

        public UnityEvent<T> UnityEvent
        {
            get => unityEvent;
            set => unityEvent = value;
        }

        private void Awake()
        {
            UnityEvent ??= new UnityEvent<T>();
        }

        private void OnEnable()
        {
            RegisterListener();
        }

        private void OnDisable()
        {
            UnregisterListener();
        }

        public void OnEventRaised(T obj)
        {
            UnityEvent?.Invoke(obj);
        }

        private void UnregisterListener()
        {
            if (GameEvent != null)
            {
                GameEvent.UnregisterListener(this);
            }
        }

        private void RegisterListener()
        {
            if (GameEvent != null)
            {
                GameEvent.RegisterListener(this);
            }
        }
    }
}