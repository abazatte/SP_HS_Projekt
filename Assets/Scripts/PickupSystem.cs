using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    public FoodItem foodItem; // Reference to the food item associated with this pickup.
    public StatSystem statSystem; // Reference to the StatSystem script.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Increase the player's food stat.
            statSystem.ConsumeFood(foodItem.foodValue);

            // Optionally, play a consumption animation or sound.
            Debug.Log("Food item collected: +" + foodItem.foodValue);
            Destroy(gameObject); // Destroy the food pickup object.
        }
    }
}