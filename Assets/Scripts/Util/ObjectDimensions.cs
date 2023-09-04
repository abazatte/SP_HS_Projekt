using UnityEngine;

namespace Util
{
    /// <summary>
    ///     This script is used to calculate the dimensions of an object in the scene.
    /// </summary>
    public class ObjectDimensions : MonoBehaviour
    {
        private void Start()
        {
            var minX = float.MaxValue;
            var minY = float.MaxValue;
            var minZ = float.MaxValue;

            var maxX = float.MinValue;
            var maxY = float.MinValue;
            var maxZ = float.MinValue;

            foreach (var renderer in GetComponentsInChildren<Renderer>())
            {
                var bounds = renderer.bounds;
                minX = Mathf.Min(minX, bounds.min.x);
                minY = Mathf.Min(minY, bounds.min.y);
                minZ = Mathf.Min(minZ, bounds.min.z);

                maxX = Mathf.Max(maxX, bounds.max.x);
                maxY = Mathf.Max(maxY, bounds.max.y);
                maxZ = Mathf.Max(maxZ, bounds.max.z);
            }

            var width = maxX - minX;
            var height = maxY - minY;
            var depth = maxZ - minZ;

            Debug.Log("Object X: " + width + " Y: " + height + " Z: " +
                      depth);
        }
    }
}
