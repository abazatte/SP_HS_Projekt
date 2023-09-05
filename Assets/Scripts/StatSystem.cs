using NaughtyAttributes;
using UnityEngine;

public class StatSystem : MonoBehaviour
{
    [ProgressBar("Health", 100f, EColor.Red)]
    public float currentHealth;
    [ProgressBar("Food", 100f, EColor.Green)]
    public float currentFood;
    [ProgressBar("Water", 100f)] public float currentWater;

    [Header("Stat Parameters")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float maxFood = 100f;
    [SerializeField] private float maxWater = 100f;

    private void Awake()
    {
        currentHealth = maxHealth;
        currentFood = 20f;
        currentWater = 20f;
    }

    public void ConsumeFood(float amount)
    {
        currentFood += amount;
        currentFood = Mathf.Clamp(currentFood, 0, maxFood);
    }

    public void ConsumeWater(float amount)
    {
        currentWater += amount;
        currentWater = Mathf.Clamp(currentWater, 0, maxWater);
    }
}
