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
      IImmutableList<Spec> children = null) : base(
        name: boxName + "ControlBox",
        transform: Transform(),
        children: Children(
          boxName,
          boxTitle,
          children ?? List())
      )
    {
    }

    private static ITransformSpec Transform() =>
      new RectTransformSpec(
        pivot: TextAnchor.UpperCenter);

    private static IImmutableList<Spec> Children(
      string boxName,
      string boxTitle,
      IImmutableList<Spec> children) =>
      List(
        new ImageSpec(
          sourceImage: SpriteName.TextFieldNormal,
          imageType: new TiledImageType()),
        new LayoutGroupSpec(
          layoutDirection: LayoutDirection.Vertical,
          padding: new Padding(
            left: 20,
            top: 10,
            right: 20,
            bottom: 30),
          spacing: 10,
          childBehavior: new ChildBehavior(
            layoutControlsWidth: true,
            forceExpandWidth: true)),
        new CompositeSpec(
          name: boxName + "ControlBoxTitle",
          transform: new RectTransformSpec(
            size: new Vector2(x: 0f, y: 50f)),
          children: List(
            new TextSpec(
              text: boxTitle,
              font: FontName.EurostileBqBoldExtended,
              fontStyle: FontStyle.Bold,
              fontSize: 22)))
        ).AddRange(children);
  }
}