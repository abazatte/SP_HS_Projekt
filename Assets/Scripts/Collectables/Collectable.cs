using NaughtyAttributes;
using UnityEngine;

namespace DinoGame.Collectables
{
    /// <summary>
    ///     Base class for all collectable items in the game.
    /// </summary>
    public abstract class Collectable : ScriptableObject
    {
        [SerializeField] private string title;
        [SerializeField] private string description;
        [SerializeField] [ShowAssetPreview] private Sprite icon;

        public virtual string Title
        {
            get => title;
            set => title = value;
        }

        public virtual string Description
        {
            get => description;
            set => description = value;
        }

        public virtual Sprite Icon
        {
            get => icon;
            set => icon = value;
        }

        public abstract void OnPickup();
    }
}