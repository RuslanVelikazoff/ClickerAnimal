using UnityEngine;
using UnityEngine.UI;
using YG;

public class BonusManager : MonoBehaviour
{
    [SerializeField]
    private Button adButton;
    [SerializeField]
    private GameObject adGameObject;
    private bool adClick = false;
    private float adTimer = 0f;

    [SerializeField]
    private YandexGame sdk;
    private GameManager gameManager;
    private AnimalButton animalButton;

    public void Initialize(GameManager manager, AnimalButton animal)
    {
        gameManager = manager;
        animalButton = animal;

        ButtonClickAction();

        Debug.Log("Bonus initialized");
    }

    private void Update()
    {
        if (adClick)
        {
            adTimer -= Time.deltaTime;
            if (adTimer <= 0)
            {
                adTimer = 120f;
                adClick = false;
                adGameObject.SetActive(true);
            }
        }
    }

    private void ButtonClickAction()
    {
        if (adButton != null)
        {
            adButton.onClick.RemoveAllListeners();
            adButton.onClick.AddListener(() =>
            {
                ActivateAdExpBonus();
            });
        }
    }

    private void ActivateAdExpBonus()
    {
        adGameObject.SetActive(false);
        sdk._RewardedShow(1);
        adClick = true;
        adTimer = 120f;
    }

    public void ActivateAdExpBonusCul()
    {
        gameManager.AddExp(10);
        animalButton.SetAnimalSprite();
    }
}
