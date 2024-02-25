using DinoGame.GameEvents.Types;
using UnityEngine;

namespace DinoGame.Collectables.Types
{
    [CreateAssetMenu(fileName = "New Food Collectable", menuName = "Collectable/Food")]
    public class FoodCollectable : Collectable
    {
        [SerializeField] private FloatGameEvent gameEvent;
        [SerializeField] private int value;

        public override void OnPickup()
        {
            gameEvent.Raise(value);
        }
    }
}