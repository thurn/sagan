using System.Collections.Immutable;
using Specs.Core;
using Specs.Generated.Resources;
using Specs.Unity;
using UnityEngine;

namespace Sagan.Specs
{
  public class ControlWindowSpec : CompositeSpec
  {
    private const float WindowWidth = 600f;

    public ControlWindowSpec(
      string windowName,
      string windowTitle,
      IImmutableList<Spec> children) : base(
      windowName + "ControlWindow",
      Transform(),
      Children(windowTitle, children))
    {
    }

    private static RectTransformSpec Transform() =>
      new RectTransformSpec(
        new Vector2(x: WindowWidth, y: 0),
        pivot: TextAnchor.UpperRight,
        verticalAnchor: VerticalAnchor.Stretch,
        horizontalAnchor: HorizontalAnchor.Right);

    private static IImmutableList<Spec> Children(
      string windowTitle,
      IImmutableList<Spec> children) =>
      List(
        new ImageSpec(
          sourceImage: SpriteName.WindowBackground,
          imageType: new TiledImageType()
        ),
        new CanvasGroupSpec(),
        new LayoutGroupSpec(
          LayoutDirection.Vertical,
          childAlignment: TextAnchor.UpperCenter,
          childBehavior: new ChildBehavior(
            layoutControlsWidth: true,
            layoutControlsHeight: true,
            forceExpandWidth: true),
          spacing: 20,
          padding: new Padding(
            left: 30,
            right: 30,
            top: 30,
            bottom: 30)),
        new WindowHeaderSpec(windowTitle)
      ).AddRange(children);
  }
}