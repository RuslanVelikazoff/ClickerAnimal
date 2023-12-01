using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField]
    private AnimalButton animalButton;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private BonusManager bonusManager;

    [SerializeField]
    private LevelPanel levelPanel;
    [SerializeField]
    private SettingsPanel settingsPanel;

    private AnimationsUI animationsUI = new AnimationsUI();

    private void Start()
    {
        animalButton.Initialize(gameManager, animationsUI);
        levelPanel.Initialize(gameManager);
        bonusManager.Initialize(gameManager, animalButton);
        settingsPanel.Initialize(animationsUI);
    }
}
