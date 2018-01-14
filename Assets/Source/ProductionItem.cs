using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ProductionItem : SaganComponent, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler  {
    private Text _text;
    private Image _image;
    private Image _backgroundImage;

    private void Start()
    {
        _backgroundImage = GetComponent<Image>();
        _backgroundImage.color = Colors.BackgroundColor;
    }

    public void SetContent(Item item)
    {
        if (!_text || !_image)
        {
            _text = GetComponentInChildren<Text>();
            _image = GetComponentInChildren<Image>();
        }
        _text.text = item.GetName();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _backgroundImage.color = Colors.BackgroundColorHighlighted;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _backgroundImage.color = Colors.BackgroundColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
