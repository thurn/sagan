using Specs.Core;
using Specs.Generated.Resources;
using Specs.Unity;
using UnityEngine;

namespace Sagan.Specs
{
  public class ImageBoxSpec : CompositeSpec
  {
    public ImageBoxSpec(
      string name,
      Vector2 size,
      SpriteName image) : base(
      name: name + "ImageBoxBackground",
      transform: new RectTransformSpec(
        size: size),
      children: List(
        new ImageSpec(
          sourceImage: SpriteName.ImageBoxBackground),
        new LayoutElementSpec(
          preferredWidth: size.x,
          preferredHeight: size.y),
        new CompositeSpec(
          name: name + "ImageBox",
          transform: new RectTransformSpec(
            size: new Vector2(x: -10f, y: -10f),
            horizontalAnchor: HorizontalAnchor.Stretch,
            verticalAnchor: VerticalAnchor.Stretch),
            children: List(
              new ImageSpec(
                sourceImage: image)))))
    {
    }
  }
}