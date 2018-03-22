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
      IImmutableList<Spec> children = null) : base(
      name: "OverlayCanvas",
      transform: new RectTransformSpec(),
      children: Children(children))
    {
    }

    private static IImmutableList<Spec> Children(IImmutableList<Spec> children) =>
      List(
        new CanvasSpec(
          renderMode: new ScreenSpaceOverlayRenderMode()),
        new CanvasScalerSpec(
          scaleMode: CanvasScaler.ScaleMode.ScaleWithScreenSize,
          referenceResolution: new Vector2(x: 1920, y: 1080)),
        new GraphicRaycasterSpec()
      ).AddRange(children);
  }
}