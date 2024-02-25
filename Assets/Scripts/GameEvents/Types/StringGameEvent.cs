using UnityEngine;

namespace DinoGame.GameEvents.Types
{
    [CreateAssetMenu(fileName = "New String Game Event", menuName = "Events/String Game Event")]
    public class StringGameEvent : GameEvent<string>
    {
    }
}