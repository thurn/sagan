using Specs.Core;
using Specs.Generated;
using UnityEngine;

namespace Specs.Unity
{
  public class CanvasGroupSpec : Spec<CanvasGroup>
  {
    public float Alpha { get; }
    public bool IsInteractable { get; }
    public bool BlocksRaycasts { get; }
    public bool IgnoreParentGroups { get; }

    public CanvasGroupSpec(
      float alpha = 1.0f,
      bool isInteractable = true,
      bool blocksRaycasts = true,
      bool ignoreParentGroups = false)
    {
      Alpha = alpha;
      IsInteractable = isInteractable;
      BlocksRaycasts = blocksRaycasts;
      IgnoreParentGroups = ignoreParentGroups;
    }

    public override CanvasGroup Mount(Res res, GameObject gameObject) =>
      gameObject.AddComponent<CanvasGroup>();

    public override CanvasGroup GetInstance(GameObject gameObject) =>
      gameObject.GetComponent<CanvasGroup>();
 
    public override void Update(Res res, CanvasGroup canvasGroup)
    {
      canvasGroup.alpha = Alpha;
      canvasGroup.interactable = IsInteractable;
      canvasGroup.blocksRaycasts = BlocksRaycasts;
      canvasGroup.ignoreParentGroups = IgnoreParentGroups;
    }
  }
}