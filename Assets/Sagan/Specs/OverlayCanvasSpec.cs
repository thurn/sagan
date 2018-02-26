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
      IImmutableList<ISpec> children = null) : base(
      name: "OverlayCanvas",
      transform: new RectTransformSpec(),
      children: Children(children))
    {
    }

    private static IImmutableList<ISpec> Children(IImmutableList<ISpec> children) =>
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