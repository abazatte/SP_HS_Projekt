using UnityEngine;

namespace DinoGame.Utility
{
    /// <summary>
    ///     Provides helper methods for working with <see cref="GameObject" />s.
    /// </summary>
    public static class GameObjectHelper
    {
        /// <summary>
        ///     Gets the component of the specified type from the given GameObject.
        /// </summary>
        /// <param name="obj">The GameObject to get the component from.</param>
        /// <typeparam name="T">The type of the component to get.</typeparam>
        /// <returns>The component of the specified type.</returns>
        /// <exception cref="MissingComponentException">
        ///     Thrown when the specified component type is not found on the GameObject.
        /// </exception>
        public static T FetchComponentOrFail<T>(this GameObject obj) where T : Component
        {
            T component = obj.GetComponent<T>();
            if (component == null)
            {
                throw new MissingComponentException($"Component of type {typeof(T)} not found on {obj.name}.");
            }

            return component;
        }

        /// <summary>
        ///     Ensures the component of the specified type is present on the given GameObject.
        ///     If the provided component is null, it attempts to fetch the component from the GameObject.
        /// </summary>
        /// <param name="obj">The GameObject to check for the component.</param>
        /// <param name="component">The component to check.</param>
        /// <typeparam name="T">The type of the component to ensure.</typeparam>
        /// <returns>The component of the specified type, fetched from the GameObject if it was initially null.</returns>
        public static T EnsureComponentExists<T>(this GameObject obj, T component) where T : Component
        {
            if (component != null)
            {
                return component;
            }

            Debug.Log(
                $"Component of type {typeof(T)} is null. Attempting to get component from {obj.name}.");
            T fetchedComponent = obj.FetchComponentOrFail<T>();

            return fetchedComponent;
        }

        /// <summary>
        ///     Checks if the GameObject or any of its parents have the specified tag.
        /// </summary>
        /// <param name="obj">The GameObject to start the search from.</param>
        /// <param name="tag">The tag to search for.</param>
        /// <returns>True if the GameObject itself or any of its parents have the specified tag, false otherwise.</returns>
        public static bool FindTag(this GameObject obj, string tag)
        {
            Transform current = obj.transform;
            while (current != null)
            {
                if (current.gameObject.CompareTag(tag))
                {
                    return true;
                }

                current = current.parent;
            }

            return false;
        }

        /// <summary>
        ///     Finds the first parent of the GameObject that has the specified tag.
        /// </summary>
        /// <param name="obj">The GameObject to start the search from.</param>
        /// <param name="tag">The tag to search for.</param>
        /// <returns>The first parent GameObject that has the specified tag, or null if no such parent exists.</returns>
        public static GameObject FindTagParent(this GameObject obj, string tag)
        {
            Transform current = obj.transform;
            while (current != null)
            {
                if (current.gameObject.CompareTag(tag))
                {
                    return current.gameObject;
                }

                current = current.parent;
            }

            return null;
        }
    }
}