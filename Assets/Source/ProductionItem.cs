using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ProductionItem : SaganComponent, IPointerEnterHandler, IPointerExitHandler {
    private Text _text;
    private Image _image;
    private Image _backgroundImage;

    private void Start()
    {
        _backgroundImage = GetComponent<Image>();
        _backgroundImage.color = Colors.BackgroundColor;
    }

    public void SetContent(string text)
    {
        if (!_text || !_image)
        {
            _text = GetComponentInChildren<Text>();
            _image = GetComponentInChildren<Image>();
        }
        _text.text = text;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _backgroundImage.color = Colors.BackgroundColorHighlighted;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _backgroundImage.color = Colors.BackgroundColor;
    }
}
