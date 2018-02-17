using Specs.Core;
using Specs.Generated;
using UnityEngine;
using UnityEngine.UI;

namespace Specs.Unity
{
  public class ContentSizeFitterSpec : Spec<ContentSizeFitter>
  {
    public ContentSizeFitter.FitMode HorizontalFitMode { get; }
    public ContentSizeFitter.FitMode VerticalFitMode { get; }

    public ContentSizeFitterSpec(
      ContentSizeFitter.FitMode horizontalFitMode = ContentSizeFitter.FitMode.PreferredSize,
      ContentSizeFitter.FitMode verticalFitMode = ContentSizeFitter.FitMode.PreferredSize)
    {
      HorizontalFitMode = horizontalFitMode;
      VerticalFitMode = verticalFitMode;
    }

    public override ContentSizeFitter Mount(Res res, GameObject gameObject) =>
      gameObject.AddComponent<ContentSizeFitter>();

    public override void Update(Res res, ContentSizeFitter sizeFitter)
    {
      sizeFitter.horizontalFit = HorizontalFitMode;
      sizeFitter.verticalFit = VerticalFitMode;
    }

    public override ContentSizeFitter GetInstance(GameObject gameObject) =>
      gameObject.GetComponent<ContentSizeFitter>();
  }
}