using Specs.Core;
using Specs.Generated;
using UnityEngine;
using UnityEngine.UI;

namespace Specs.Unity
{
  public class LayoutElementSpec : Spec<LayoutElement>
  {
    public float? MinWidth { get; }
    public float? MinHeight { get; }
    public float? PreferredWidth { get; }
    public float? PreferredHeight { get; }
    public float? FlexibleWidth { get; }
    public float? FlexibleHeight { get; }

    /// <param name="minWidth">The minimum width this layout element can be allocated</param>
    /// <param name="minHeight">The minimum height this layout element may be allocated.</param>
    /// <param name="preferredWidth">The preferred width this layout element should be allocated
    /// if there is sufficient space.</param>
    /// <param name="preferredHeight">The preferred height this layout element should be allocated
    /// if there is sufficient space.</param>
    /// <param name="flexibleWidth">The extra relative width this layout element should be
    /// allocated if there is additional available space.</param>
    /// <param name="flexibleHeight">The extra relative height this layout element should be
    /// allocated if there is additional available space.</param>
    public LayoutElementSpec(
      float? minWidth = null,
      float? minHeight = null,
      float? preferredWidth = null,
      float? preferredHeight = null,
      float? flexibleWidth = null,
      float? flexibleHeight = null)
    {
      MinWidth = minWidth;
      MinHeight = minHeight;
      PreferredWidth = preferredWidth;
      PreferredHeight = preferredHeight;
      FlexibleWidth = flexibleWidth;
      FlexibleHeight = flexibleHeight;
    }

    protected override LayoutElement Mount(Res res, GameObject parent) =>
      parent.AddComponent<LayoutElement>();

    protected override LayoutElement GetInstance(GameObject parent) =>
      parent.GetComponent<LayoutElement>();

    protected override void Update(Res res, LayoutElement layoutElement)
    {
      if (MinWidth.HasValue)
      {
        layoutElement.minWidth = MinWidth.Value;
      }
      if (MinHeight.HasValue)
      {
        layoutElement.minHeight = MinHeight.Value;
      }
      if (PreferredWidth.HasValue)
      {
        layoutElement.preferredWidth = PreferredWidth.Value;
      }
      if (PreferredHeight.HasValue)
      {
        layoutElement.preferredHeight = PreferredHeight.Value;
      }
      if (FlexibleWidth.HasValue)
      {
        layoutElement.flexibleWidth = FlexibleWidth.Value;
      }
      if (FlexibleHeight.HasValue)
      {
        layoutElement.flexibleHeight = FlexibleHeight.Value;
      }
    }
  }
}