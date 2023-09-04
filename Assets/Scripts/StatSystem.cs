using NaughtyAttributes;
using UnityEngine;

public class StatSystem : MonoBehaviour
{
    [ProgressBar("Health", 100, EColor.Red)]
    public float currentHealth;
    [ProgressBar("Food", 100, EColor.Green)]
    public float currentFood;
    [ProgressBar("Water", 100, EColor.Blue)]
    public float currentWater;

    [Header("Stat Parameters")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float maxFood = 100f;
    [SerializeField] private float maxWater = 100f;
    [SerializeField] private float attackPower = 10f;


    private void Awake()
    {
        currentHealth = maxHealth;
        currentFood = maxFood;
        currentWater = maxWater;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
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
