using DinoGame.GameEvents.Types;
using UnityEngine;

namespace DinoGame.Collectables.Types
{
    [CreateAssetMenu(fileName = "New Health Collectable", menuName = "Collectable/Health")]
    public class HealthCollectable : Collectable
    {
        [SerializeField] private FloatGameEvent gameEvent;
        [SerializeField] private int value;

        public override void OnPickup()
        {
            gameEvent.Raise(value);
        }
    }
}