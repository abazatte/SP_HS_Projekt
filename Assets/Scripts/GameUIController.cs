using UnityEngine;

namespace DinoGame
{
    public class GameUIController : MonoBehaviour
    {
        // [SerializeField] private PlayerAttributeController playerAttributeController;
        // [SerializeField] private UIDocument uiDocument;
        //
        // private ProgressBar _foodBar;
        // private ProgressBar _healthBar;
        // private ProgressBar _waterBar;
        //
        // private void Awake()
        // {
        //     // Ensure that the required components are present on the GameObject
        //     playerAttributeController = gameObject.EnsureComponentExists(playerAttributeController);
        //     uiDocument = gameObject.EnsureComponentExists(uiDocument);
        //
        //     // Get the root element of the UI Document
        //     VisualElement root = uiDocument.rootVisualElement;
        //
        //     // Query the UI Document for the required elements
        //     _healthBar = root.Q<ProgressBar>("healthBar");
        //     _foodBar = root.Q<ProgressBar>("foodBar");
        //     _waterBar = root.Q<ProgressBar>("waterBar");
        // }
        //
        // private void Update()
        // {
        //     _healthBar.value = playerAttributeController.Health;
        //     _foodBar.value = playerAttributeController.Hunger;
        //     _waterBar.value = playerAttributeController.Thirst;
        // }
    }
}