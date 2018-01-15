using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProductionItem : SaganComponent, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Text _text;
    private Image _image;
    private Image _backgroundImage;
    private ProductionService _productionService;
    private Item _item;

    protected override void OnCreate()
    {
        _backgroundImage = GetComponent<Image>();
        _backgroundImage.color = Colors.BackgroundColor;
        _productionService = Root.GetService<ProductionService>();
    }

    public void SetItem(Item item)
    {
        if (!_text || !_image)
        {
            _text = GetComponentInChildren<Text>();
            _image = GetComponentInChildren<Image>();
        }
        _text.text = item.GetName();
        _item = item;
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
        _productionService.StartProduction(_item);
    }
}