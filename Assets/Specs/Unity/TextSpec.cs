using Specs.Core;
using Specs.Generated.Resources;
using UnityEngine;
using UnityEngine.UI;

namespace Specs.Unity
{
  public class TextSpec : BehaviourSpec<Text>
  {
    public string Text { get; }
    public FontName? Font { get; }
    public FontStyle FontStyle { get; }
    public int FontSize { get; }
    public int LineSpacing { get; }
    public bool ShouldSupportRichText { get; }
    public TextAnchor Alignment { get; }
    public bool AlignByGeometry { get; }
    public HorizontalWrapMode HorizontalOverflow { get; }
    public VerticalWrapMode VerticalOverflow { get; }
    public bool ResizeTextForBestFit { get; }
    public Color Color { get; }
    public MaterialName? Material { get; }
    public bool IsRaycastTarget { get; }

    public TextSpec(
      string text = "",
      FontName? font = null,
      FontStyle fontStyle = FontStyle.Normal,
      int fontSize = 14,
      int lineSpacing = 1,
      bool shouldSupportRichText = false,
      TextAnchor alignment = TextAnchor.UpperLeft,
      bool alignByGeometry = false,
      HorizontalWrapMode horizontalOverflow = HorizontalWrapMode.Wrap,
      VerticalWrapMode verticalOverflow = VerticalWrapMode.Truncate,
      bool resizeTextForBestFit = false,
      Color? color = null,
      MaterialName? material = null,
      bool isRaycastTarget = true)
    {
      Text = text;
      Font = font;
      FontStyle = fontStyle;
      FontSize = fontSize;
      LineSpacing = lineSpacing;
      ShouldSupportRichText = shouldSupportRichText;
      Alignment = alignment;
      AlignByGeometry = alignByGeometry;
      HorizontalOverflow = horizontalOverflow;
      VerticalOverflow = verticalOverflow;
      ResizeTextForBestFit = resizeTextForBestFit;
      Color = color.GetValueOrDefault(Color.white);
      Material = material;
      IsRaycastTarget = isRaycastTarget;
    }

    protected override void UpdateComponent(Res res, Text component)
    {
      component.text = Text;

      if (Font.HasValue)
      {
        component.font = res.GetFont(Font.Value);
      }

      component.fontStyle = FontStyle;
      component.fontSize = FontSize;
      component.lineSpacing = LineSpacing;
      component.supportRichText = ShouldSupportRichText;
      component.alignment = Alignment;
      component.alignByGeometry = AlignByGeometry;
      component.horizontalOverflow = HorizontalOverflow;
      component.verticalOverflow = VerticalOverflow;
      component.resizeTextForBestFit = ResizeTextForBestFit;
      component.color = Color;

      if (Material.HasValue)
      {
        component.material = res.GetMaterial(Material.Value);
      }

      component.raycastTarget = IsRaycastTarget;
    }
  }
}