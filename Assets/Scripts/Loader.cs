using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private BonusManager bonusManager;

    [SerializeField]
    private SettingsPanel settingsPanel;
    [SerializeField]
    private AllAnimalsPanel allAnimalsPanel;

    private AnimationsUI animationsUI = new AnimationsUI();

    private void Start()
    {
        bonusManager.Initialize(gameManager);
        settingsPanel.Initialize(animationsUI);
        allAnimalsPanel.Initialize(gameManager, animationsUI);
    }
}
