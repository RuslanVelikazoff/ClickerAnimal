using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField]
    private Button settingsButton;
    [SerializeField]
    private Button acceptButton;

    [Space(7)]

    [Header("Panel")]
    [SerializeField]
    private GameObject settingsPanel;
    [SerializeField]
    private GameObject settingsImage;

    [Space(7)]

    [Header("Settings Buttons")]
    [SerializeField]
    private Button musicButton;
    [SerializeField]
    private Sprite musicOnSprite;
    [SerializeField]
    private Sprite musicOffSprite;

    [Space(3)]

    [SerializeField]
    private Button soundButton;
    [SerializeField]
    private Sprite soundOnSprite;
    [SerializeField]
    private Sprite soundOffSprite;

    private AnimationsUI animations;

    public void Initialize(AnimationsUI animationsUI)
    {
        animations = animationsUI;

        SetButtonSprites();
        ButtonClickAction();

        Debug.Log("SettingsPanel initialized");
    }

    private void ButtonClickAction()
    {
        if (settingsButton != null)
        {
            settingsButton.onClick.RemoveAllListeners();
            settingsButton.onClick.AddListener(() =>
            {
                animations.OpenSettingsPanelAnimation(settingsPanel, settingsImage);
            });
        }
        if (acceptButton != null)
        {
            acceptButton.onClick.RemoveAllListeners();
            acceptButton.onClick.AddListener(() =>
            {
                StartCoroutine(animations.CloseSettingsPanelAnimation(settingsPanel, settingsImage));
            });
        }

        if (musicButton != null)
        {
            musicButton.onClick.RemoveAllListeners();
            musicButton.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetFloat("MusicVolume") == 1f)
                {
                    AudioManager.Instance.OffMusic();
                }
                else
                {
                    AudioManager.Instance.OnMusic();
                }

                SetButtonSprites();
            });
        }
        if (soundButton != null)
        {
            soundButton.onClick.RemoveAllListeners();
            soundButton.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetFloat("SoundVolume") == 1f)
                {
                    AudioManager.Instance.OffSounds();
                }
                else
                {
                    AudioManager.Instance.OnSounds();
                }

                SetButtonSprites();
            });
        }
    }

    private void SetButtonSprites()
    {
        if (PlayerPrefs.GetFloat("MusicVolume") == 1f)
        {
            musicButton.GetComponent<Image>().sprite = musicOnSprite;
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = musicOffSprite;
        }

        if (PlayerPrefs.GetFloat("SoundVolume") == 1f)
        {
            soundButton.GetComponent<Image>().sprite = soundOnSprite;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = soundOffSprite;
        }
    }
}
