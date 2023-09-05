using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    [SerializeField] [Required] private StatSystem playerStats;

    private ProgressBar healthBar;
    private ProgressBar foodBar;
    private ProgressBar waterBar;

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        healthBar = root.Q<ProgressBar>("healthBar");
        foodBar = root.Q<ProgressBar>("foodBar");
        waterBar = root.Q<ProgressBar>("waterBar");
    }

    private void Update()
    {
        healthBar.value = playerStats.currentHealth;
        foodBar.value = playerStats.currentFood;
        waterBar.value = playerStats.currentWater;
    }
}
