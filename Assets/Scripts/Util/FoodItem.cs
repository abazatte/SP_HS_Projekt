using NaughtyAttributes;
using UnityEngine;

namespace Util
{
    [CreateAssetMenu(fileName = "New Food Item", menuName = "Food Item")]
    public class FoodItem : ScriptableObject
    {
        public string itemName;
        public string itemDescription;
        [ShowAssetPreview] public Sprite itemIcon;
        public int foodValue;
    }
}
