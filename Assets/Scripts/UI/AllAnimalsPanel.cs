using UnityEngine;
using UnityEngine.UI;

public class AllAnimalsPanel : MonoBehaviour
{
    [SerializeField]
    private Button allAnimalsButton;
    [SerializeField]
    private Button closeButton;

    [SerializeField]
    private GameObject allAnimalsPanel;
    [SerializeField]
    private GameObject allAnimalsImage;

    private GameManager gameManager;
    private AnimationsUI animations;

    public void Initialize(GameManager manager, AnimationsUI animationsUI)
    {
        gameManager = manager;
        animations = animationsUI;

        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (allAnimalsButton != null)
        {
            allAnimalsButton.onClick.RemoveAllListeners();
            allAnimalsButton.onClick.AddListener(() =>
            {
                animations.OpenAllAnimalsPanelAnimation(allAnimalsPanel, allAnimalsImage);
            });
        }
        if (closeButton != null)
        {
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(() =>
            {
                StartCoroutine(animations.CloseAllAnimalsPanelAnimation(allAnimalsPanel, allAnimalsImage));
            });
        }
    }

    //TODO: настроить все тут!
}
