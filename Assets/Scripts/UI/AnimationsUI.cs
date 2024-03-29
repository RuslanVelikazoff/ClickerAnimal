using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class AnimationsUI
{
    private Vector3 allAnimalsPanelPosition = new Vector3(-7f, 0f, 90f);
    private Vector3 settingsPanelPosition = new Vector3(0f, 16f, 90f);
    private Vector3 mainPanelPosition = new Vector3(0f, 0f, 90f);

    public void ButtonClick(Button button)
    {
        Sequence sequence = DOTween.Sequence();

        AudioManager.Instance.PlaySounds("Click");

        sequence.Append(button.transform.DOScale(new Vector3(.8f, .8f, 1f), .3f))
            .Append(button.transform.DOScale(new Vector3(1f, 1f, 1f), .3f))
            .SetUpdate(UpdateType.Normal, true);
    }

    #region SETTINGS_PANEL

    public void OpenSettingsPanelAnimation(GameObject panel, GameObject image)
    {
        Sequence sequence = DOTween.Sequence();

        panel.SetActive(true);

        sequence.Append(image.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), .5f))
            .Append(image.transform.DOScale(new Vector3(1f, 1f, 1f), .5f));

    }

    public IEnumerator CloseSettingsPanelAnimation(GameObject panel, GameObject image)
    {
        Sequence sequence = DOTween.Sequence();

        image.transform.DOScale(new Vector3(0f, 0f, 0f), .5f);

        yield return new WaitForSeconds(.6f);

        panel.SetActive(false);
    }

    #endregion

    #region ALL_ANIMALS_PANEL

    public void OpenAllAnimalsPanelAnimation(GameObject panel, GameObject image)
    { 
        panel.SetActive(true);

        image.transform.DOMove(mainPanelPosition, .6f);
    }

    public IEnumerator CloseAllAnimalsPanelAnimation(GameObject panel, GameObject image)
    {
        image.transform.DOMove(allAnimalsPanelPosition, .6f);

        yield return new WaitForSeconds(.7f);

        panel.SetActive(false);
    }

    #endregion
}
