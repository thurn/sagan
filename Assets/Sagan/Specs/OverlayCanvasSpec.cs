using System.Collections.Immutable;
using Specs.Core;
using Specs.Unity;
using UnityEngine;
using UnityEngine.UI;

namespace Sagan.Specs
{
  public class OverlayCanvasSpec : CompositeSpec
  {
    public OverlayCanvasSpec(
      ImmutableList<ISpec> children = null) : base(
      name: "Canvas",
      transform: new RectTransformSpec(),
      children: Children(children))
    {
    }

    private static ImmutableList<ISpec> Children(ImmutableList<ISpec> children) =>
      SpecList(
        new CanvasSpec(
          renderMode: new ScreenSpaceOverlayRenderMode(
            pixelPerfect: true)),
        new CanvasScalerSpec(
          scaleMode: CanvasScaler.ScaleMode.ScaleWithScreenSize,
          referenceResolution: new Vector2(x: 1920, y: 1080)),
        new GraphicRaycasterSpec()
      ).AddRange(children);
  }
}