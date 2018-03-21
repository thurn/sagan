using Specs.Core;
using Specs.Generated.Resources;
using Specs.Util;
using UnityEngine;
using UnityEngine.UI;

namespace Specs.Unity
{
  public enum LayoutDirection
  {
    Horizontal,
    Vertical
  }

  public struct Padding
  {
    public int Left { get; }
    public int Right { get; }
    public int Top { get; }
    public int Bottom { get; }

    public Padding(
      int left = 0,
      int right = 0,
      int top = 0,
      int bottom = 0)
    {
      Left = left;
      Right = right;
      Top = top;
      Bottom = bottom;
    }
  }

  public struct ChildBehavior
  {
    public bool LayoutControlsWidth { get; }
    public bool LayoutControlsHeight { get; }
    public bool ForceExpandWidth { get; }
    public bool ForceExpandHeight { get; }

    public ChildBehavior(
      bool layoutControlsWidth = false,
      bool layoutControlsHeight = false,
      bool forceExpandWidth = false,
      bool forceExpandHeight = false)
    {
      LayoutControlsWidth = layoutControlsWidth;
      LayoutControlsHeight = layoutControlsHeight;
      ForceExpandWidth = forceExpandWidth;
      ForceExpandHeight = forceExpandHeight;
    }
  }

  public class LayoutGroupSpec : BehaviourSpec<HorizontalOrVerticalLayoutGroup>
  {
    public LayoutDirection LayoutDirection { get; }
    public Padding Padding { get; }
    public float Spacing { get; }
    public TextAnchor ChildAlignment { get; }
    public ChildBehavior ChildBehavior { get; }

    public LayoutGroupSpec(
      LayoutDirection layoutDirection,
      Padding padding = new Padding(),
      float spacing = 0f,
      TextAnchor childAlignment = TextAnchor.UpperLeft,
      ChildBehavior childBehavior = new ChildBehavior())
    {
      LayoutDirection = layoutDirection;
      Padding = padding;
      Spacing = spacing;
      ChildAlignment = childAlignment;
      ChildBehavior = childBehavior;
    }

    protected override HorizontalOrVerticalLayoutGroup AddComponent(GameObject gameObject)
    {
      switch (LayoutDirection)
      {
        case LayoutDirection.Horizontal:
          return gameObject.AddComponent<HorizontalLayoutGroup>();

        case LayoutDirection.Vertical:
          return gameObject.AddComponent<VerticalLayoutGroup>();

        default:
          throw Errors.UnknownEnumValue(LayoutDirection);
      }
    }

    protected override void UpdateComponent(Res res, HorizontalOrVerticalLayoutGroup component)
    {
      component.padding = OffsetForPadding(Padding);
      component.spacing = Spacing;
      component.childAlignment = ChildAlignment;
      component.childForceExpandWidth = ChildBehavior.ForceExpandWidth;
      component.childForceExpandHeight = ChildBehavior.ForceExpandHeight;
      component.childControlWidth = ChildBehavior.LayoutControlsWidth;
      component.childControlHeight = ChildBehavior.LayoutControlsHeight;
    }

    private static RectOffset OffsetForPadding(Padding padding) =>
      new RectOffset(padding.Left, padding.Right, padding.Top, padding.Bottom);
  }
}