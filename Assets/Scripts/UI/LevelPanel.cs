using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    [SerializeField]
    private Text levelText;
    [SerializeField]
    private Text expText;

    private GameManager gameManager;

    public void Initialize(GameManager manager)
    {
        gameManager = manager;
    }

    private void Update()
    {
        levelText.text = gameManager.currentLevel.ToString();
        if (gameManager.currentLevel != gameManager.maxLevel)
        {
            expText.text = gameManager.currentExp + " / " + gameManager.neededExp[gameManager.currentLevel - 1];
        }
        else
        {
            expText.text = gameManager.currentExp + " / " + "∞";
        }
    }
}
