using System.Collections.Immutable;
using Specs.Core;
using Specs.Generated;
using Specs.Unity;
using UnityEngine;

namespace Sagan.Specs
{
  public class ControlBoxSpec : CompositeSpec
  {
    public ControlBoxSpec(
      string boxName,
      string boxTitle,
      float height,
      ImmutableList<ISpec> children = null) : base(
        name: boxName,
        transform: Transform(height),
        children: Children(
          boxName, 
          boxTitle,
          children ?? SpecList())
      )
    {

    }
 
    private static ITransformSpec Transform(float height) =>
      new RectTransformSpec(
        size: new Vector2(x: 0f, y: height),
        pivot: TextAnchor.UpperCenter);
 
    private static ImmutableList<ISpec> Children(
      string boxName,
      string boxTitle,
      ImmutableList<ISpec> children) =>
      SpecList(
        new ImageSpec(
          sourceImage: SpriteName.TextFieldNormal,
          imageType: new TiledImageType()),
        new LayoutGroupSpec(
          layoutDirection: LayoutDirection.Vertical,
          padding: new Padding(
            left: 20,
            top: 10,
            right: 20,
            bottom: 10),
          spacing: 10,
          childBehavior: new ChildBehavior(
            layoutControlsWidth: true,
            forceExpandWidth: true)),
        new CompositeSpec(
          name: boxName + "Title",
          transform: new RectTransformSpec(
            size: new Vector2(x: 0f, y: 50f)),
          children: SpecList(
            new TextSpec(
              text: boxTitle,
              font: FontName.EurostileBqBoldExtended,
              fontStyle: FontStyle.Bold,
              fontSize: 22))));
  }
}