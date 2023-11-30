using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int[] neededExp;

    public int currentExp;

    public int currentLevel;
    private const int maxLevel = 20;

    private void Awake()
    {
        SetAllPlayerPrefs();
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
