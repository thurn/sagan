using UnityEngine;
using UnityEngine.UI;

public class ProductionItem : MonoBehaviour {
    private Text _text;
    private Image _image;

    public void SetContent(string text)
    {
        if (!_text || !_image)
        {
            _text = GetComponentInChildren<Text>();
            _image = GetComponentInChildren<Image>();
        }
        _text.text = text;
    }
}
