﻿using System.Collections.Immutable;
using Specs.Core;
using Specs.Generated;
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
      ImmutableList<ControlBoxSpec> children) : base(
      windowName,
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
 
    private static ImmutableList<ISpec> Children(
      string windowTitle,
      ImmutableList<ControlBoxSpec> children) =>
      SpecList(
        new CanvasRendererSpec(),
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
            forceExpandWidth: true),
          spacing: 20,
          padding: new Padding(
            left: 30,
            right: 30,
            top: 30,
            bottom: 30)),
        new WindowHeaderSpec(windowTitle, WindowWidth)
      ).AddRange(children);
  }
}