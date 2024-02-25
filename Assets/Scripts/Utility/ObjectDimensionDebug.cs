using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DinoGame.Utility
{
    /// <summary>
    ///     This class is used to calculate and log the dimensions of a GameObject.
    ///     The dimensions are calculated based on the bounds of all Renderer components attached to the GameObject and its
    ///     children.
    /// </summary>
    public class ObjectDimensionDebug : MonoBehaviour
    {
        private Renderer[] _renderers;

        public Vector3 Dimensions { get; private set; }

        private void Awake()
        {
            _renderers = GetComponentsInChildren<Renderer>();
        }

        private void Start()
        {
            Dimensions = CalculateDimensions();
            Debug.Log($"{gameObject.name} Dimensions: {Dimensions}");
        }

        private Vector3 CalculateDimensions()
        {
            List<Bounds> boundsList = _renderers.Select(rend => rend.bounds).ToList();

            float minX = boundsList.Min(b => b.min.x);
            float minY = boundsList.Min(b => b.min.y);
            float minZ = boundsList.Min(b => b.min.z);

            float maxX = boundsList.Max(b => b.max.x);
            float maxY = boundsList.Max(b => b.max.y);
            float maxZ = boundsList.Max(b => b.max.z);

            float width = maxX - minX;
            float height = maxY - minY;
            float depth = maxZ - minZ;

            return new Vector3(width, height, depth);
        }
    }
}