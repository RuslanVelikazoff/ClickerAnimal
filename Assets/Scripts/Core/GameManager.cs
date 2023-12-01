using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int[] neededExp;

    public int currentExp;

    public int currentLevel;
    public int maxLevel = 20;

    private void Awake()
    {
        SetAllPlayerPrefs();
    }

    public void Click()
    {
        AddExp(1);
    }

    public void AddExp(int expAdded)
    {
        if (currentLevel < maxLevel)
        {
            currentExp += expAdded;
            if (currentExp >= neededExp[currentLevel - 1])
            {
                currentExp = 0;
                currentLevel += 1;
            }
        }
        else if (currentLevel == maxLevel)
        {
            currentExp += expAdded;
            currentLevel = maxLevel;
        }

        UpdateAllPlayerPrefs();
    }

    private void SetAllPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
            currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        }
        else
        {
            currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        }

        currentExp = PlayerPrefs.GetInt("CurrentExp");
    }

    public void UpdateAllPlayerPrefs()
    {
        PlayerPrefs.SetInt("CurrentExp", currentExp);
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
    }
}
