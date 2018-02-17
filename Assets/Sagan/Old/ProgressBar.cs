using DG.Tweening;
using UnityEngine.UI;

public class ProgressBar : SaganComponent
{
    private Image _image;
    private Text _text;

    protected override void OnCreate()
    {
        _image = transform.Find("Bar/Fill").GetComponent<Image>();
        _text = transform.Find("Bar/Text").GetComponent<Text>();
    }

    public void SetContent(string text, float duration)
    {
        _text.text = text;
        _image.DOFillAmount(1f, duration).SetEase(Ease.Linear);
    }
}