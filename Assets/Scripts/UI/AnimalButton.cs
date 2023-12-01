using UnityEngine;
using UnityEngine.UI;

public class AnimalButton : MonoBehaviour
{
    [SerializeField]
    private Button animalButton;
    [SerializeField]
    private Sprite[] animalsSprite;

    private GameManager gameManager;
    private AnimationsUI animations;

    public void Initialize(GameManager manager, AnimationsUI animationsUI)
    {
        gameManager = manager;
        animations = animationsUI;

        SetAnimalSprite();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (animalButton != null)
        {
            animalButton.onClick.RemoveAllListeners();
            animalButton.onClick.AddListener(() =>
            {
                gameManager.Click();
                animations.ButtonClick(animalButton);
                SetAnimalSprite();
            });
        }
    }

    public void SetAnimalSprite()
    {
        animalButton.GetComponent<Image>().sprite = animalsSprite[gameManager.currentLevel - 1];
    }


}
