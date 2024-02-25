using DinoGame.GameEvents.Types;
using UnityEngine;

namespace DinoGame.Collectables.Types
{
    [CreateAssetMenu(fileName = "New Water Collectable", menuName = "Collectable/Water")]
    public class WaterCollectable : Collectable
    {
        [SerializeField] private FloatGameEvent gameEvent;
        [SerializeField] private int value;

        public override void OnPickup()
        {
            gameEvent.Raise(value);
        }
    }
}