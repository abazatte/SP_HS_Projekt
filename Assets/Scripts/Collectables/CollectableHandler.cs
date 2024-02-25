using DinoGame.Utility;
using NaughtyAttributes;
using UnityEngine;

namespace DinoGame.Collectables
{
    /// <summary>
    ///     Attach this script to a GameObject to treat it as a collectable item.
    /// </summary>
    public class CollectableHandler : MonoBehaviour
    {
        [SerializeField] [Required] private Collectable collectable;
        [SerializeField] [Tag] private string collectableBy = "Player";
        [SerializeField] private bool destroyOnPickup = true;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.FindTag(collectableBy))
            {
                return;
            }

            // Handle pickup if the object has specified tag
            collectable.OnPickup();

            // Destroy self after pickup
            if (destroyOnPickup)
            {
                Destroy(gameObject);
            }
        }
    }
}