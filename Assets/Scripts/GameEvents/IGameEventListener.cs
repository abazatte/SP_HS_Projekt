namespace DinoGame.GameEvents
{
    public interface IGameEventListener
    {
        void OnEventRaised();
    }

    public interface IGameEventListener<in T>
    {
        void OnEventRaised(T obj);
    }
}