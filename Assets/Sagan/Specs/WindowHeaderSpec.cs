using System.Collections.Immutable;
using Specs.Core;
using Specs.Generated.Resources;
using Specs.Unity;
using UnityEngine;

namespace Sagan.Specs
{
  public class WindowHeaderSpec : CompositeSpec
  {
    public WindowHeaderSpec(string windowTitle) : base(
      name: "WindowHeader",
      transform: Transform(),
      children: Children(windowTitle))
    {
    }

    private static ITransformSpec Transform() =>
      new RectTransformSpec();

    private static IImmutableList<Spec> Children(
      string windowTitle) =>
      List(
        new LayoutElementSpec(
          preferredHeight: 200f),
        new LayoutGroupSpec(
          layoutDirection: LayoutDirection.Vertical,
          childBehavior: new ChildBehavior(
            layoutControlsWidth: true,
            forceExpandWidth: true),
          spacing: 10f),
        new CompositeSpec(
          name: "WindowHeaderBackground",
          transform: new RectTransformSpec(
            size: new Vector2(x: 0f, y: 50),
            pivot: TextAnchor.UpperCenter),
          children: List(
            new ImageSpec(
              sourceImage: SpriteName.WindowHeader,
              imageType: new TiledImageType()),
            Text(windowTitle))),
        Image(SpriteName.ExampleImage));

    private static CompositeSpec Image(SpriteName imageName) =>
      new CompositeSpec(
        name: "WindowHeaderImage",
        transform: new RectTransformSpec(
          size: new Vector2(x: 500f, y: 150f)),
        children: List(
          new ImageSpec(
            sourceImage: imageName,
            imageType: new SimpleImageType())));

    private static CompositeSpec Text(string windowTitle) =>
      new CompositeSpec(
        name: "WindowHeaderTitle",
        transform: new RectTransformSpec(
          horizontalAnchor: HorizontalAnchor.Stretch,
          verticalAnchor: VerticalAnchor.Stretch),
        children: List(
          new ContentSizeFitterSpec(),
          new TextSpec(
            text: windowTitle,
            fontSize: 30,
            font: FontName.EurostileBqBoldExtended)));
  }
}