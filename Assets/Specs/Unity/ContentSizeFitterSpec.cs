using Specs.Core;
using Specs.Generated.Resources;
using UnityEngine.UI;

namespace Specs.Unity
{
  public class ContentSizeFitterSpec : BehaviourSpec<ContentSizeFitter>
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

    protected override void UpdateComponent(Res res, ContentSizeFitter sizeFitter)
    {
      sizeFitter.horizontalFit = HorizontalFitMode;
      sizeFitter.verticalFit = VerticalFitMode;
    }
  }
}