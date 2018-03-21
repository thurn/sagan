using System.Collections.Immutable;
using Sagan.Core;
using Specs.Core;
using Specs.Generated.Resources;
using Specs.Generated.Model;
using Specs.Unity;
using UnityEngine;

namespace Sagan.Specs
{
  public class ProductionItemSpec : CompositeSpec
  {
    public ProductionItemSpec(UnitType unitType) : base(
      name: unitType.GetName() + "ProductionItem",
      transform: Transform(),
      children: Children(unitType))
    {
    }

    private static ITransformSpec Transform() =>
      new RectTransformSpec(
        size: new Vector2(x: 0f, y: 51f),
        pivot: TextAnchor.UpperCenter);

    private static IImmutableList<Spec> Children(UnitType unitType) =>
      List(
        new ImageSpec(
          color: Colors.BackgroundColor),
        new LayoutGroupSpec(
          layoutDirection: LayoutDirection.Horizontal,
          spacing: 15,
          childBehavior: new ChildBehavior(
            layoutControlsHeight: true,
            layoutControlsWidth: true,
            forceExpandHeight: true)),
        new ImageBoxSpec(
          name: unitType.GetName(),
          size: new Vector2(x: 50f, y: 0),
          image: SpriteName.ExampleImage),
        new CompositeSpec(
          name: unitType.GetName() + "Text",
          transform: new RectTransformSpec(
            horizontalAnchor: HorizontalAnchor.Stretch),
          children: List(
            new TextSpec(
              text: unitType.GetName(),
              alignment: TextAnchor.MiddleLeft,
              font: FontName.RobotoRegular,
              fontSize: 20))));
  }
}