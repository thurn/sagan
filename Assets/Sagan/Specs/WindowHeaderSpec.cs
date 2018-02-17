using System.Collections.Immutable;
using Specs.Core;
using Specs.Generated;
using Specs.Unity;
using UnityEngine;

namespace Sagan.Specs
{
  public class WindowHeaderSpec : CompositeSpec
  {
    public WindowHeaderSpec(string windowTitle, float windowWidth) : base(
      name: "WindowHeader",
      transform: Transform(),
      children: Children(windowTitle, windowWidth))
    {
    }

    private static ITransformSpec Transform() =>
      new RectTransformSpec(
        size: new Vector2(x: 0, y: 210f));
 
    private static ImmutableList<ISpec> Children(
      string windowTitle,
      float windowWidth) =>
      SpecList(
        new LayoutGroupSpec(
          layoutDirection: LayoutDirection.Vertical,
          childBehavior: new ChildBehavior(
            layoutControlsWidth: true,
            forceExpandWidth: true),
          spacing: 10f),
        new CompositeSpec(
          name: "WindowHeaderBackground",
          transform: new RectTransformSpec(
            size: new Vector2(x: windowWidth * 0.9f, y: 50),
            pivot: TextAnchor.UpperCenter),
          children: SpecList(
            new ImageSpec(
              sourceImage: SpriteName.WindowHeader,
              imageType: new TiledImageType()),
            Text(windowTitle))),
        Image(SpriteName.ExampleImage));

    private static CompositeSpec Image(SpriteName imageName) =>
      new CompositeSpec(
        name: "WindowImage",
        transform: new RectTransformSpec(
          size: new Vector2(x: 500f, y: 150f)),
        children: SpecList(
          new ImageSpec(
            sourceImage: imageName,
            imageType: new SimpleImageType())));

    private static CompositeSpec Text(string windowTitle) =>
      new CompositeSpec(
        name: "WindowTitle",
        transform: new RectTransformSpec(
          horizontalAnchor: HorizontalAnchor.Stretch,
          verticalAnchor: VerticalAnchor.Stretch),
        children: SpecList(
          new ContentSizeFitterSpec(),
          new TextSpec(
            text: windowTitle,
            fontSize: 30,
            font: FontName.EurostileBqBoldExtended)));
  }
}