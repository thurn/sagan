using Specs.Core;
using Specs.Generated;
using UnityEngine;
using UnityEngine.UI;

namespace Specs.Unity
{
  public class CanvasScalerSpec : Spec<CanvasScaler>
  {
    public CanvasScaler.ScaleMode ScaleMode { get; }
    public Vector2 ReferenceResolution { get; }
    public CanvasScaler.ScreenMatchMode ScreenMatchMode { get; }
    public float MatchWidthOrHeight { get; }
    public float ReferencePixelsPerUnit { get; }

    public CanvasScalerSpec(
      CanvasScaler.ScaleMode scaleMode = CanvasScaler.ScaleMode.ConstantPhysicalSize,
      Vector2? referenceResolution = null,
      CanvasScaler.ScreenMatchMode screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight,
      float matchWidthOrHeight = 0f,
      float referencePixelsPerUnit = 100f)
    {
      ScaleMode = scaleMode;
      ReferenceResolution = referenceResolution.GetValueOrDefault(new Vector2(x: 1920, y: 1080));
      ScreenMatchMode = screenMatchMode;
      MatchWidthOrHeight = matchWidthOrHeight;
      ReferencePixelsPerUnit = referencePixelsPerUnit;
    }

    protected override CanvasScaler Mount(Res res, GameObject gameObject) =>
      gameObject.AddComponent<CanvasScaler>();

    protected override void Update(Res res, CanvasScaler canvasScaler)
    {
      canvasScaler.uiScaleMode = ScaleMode;
      canvasScaler.referenceResolution = ReferenceResolution;
      canvasScaler.screenMatchMode = ScreenMatchMode;
      canvasScaler.matchWidthOrHeight = MatchWidthOrHeight;
      canvasScaler.referencePixelsPerUnit = ReferencePixelsPerUnit;
    }

    protected override CanvasScaler GetInstance(GameObject gameObject) =>
      gameObject.GetComponent<CanvasScaler>();
  }
}