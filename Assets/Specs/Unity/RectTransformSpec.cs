using System;
using System.Collections.Immutable;
using Specs.Core;
using Specs.Generated;
using Specs.Util;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Specs.Unity
{
  public enum VerticalAnchor
  {
    Top,
    Middle,
    Bottom,
    Stretch
  }

  public enum HorizontalAnchor
  {
    Left,
    Center,
    Right,
    Stretch
  }

  public class RectTransformSpec : ComponentSpec<RectTransform>, ITransformSpec
  {
    public Vector2 Size { get; }
    public Vector3 Position { get; }
    public Vector2 Pivot { get; }
    public Vector2 AnchorMin { get; }
    public Vector2 AnchorMax { get; }
    public Vector3 EulerRotation { get; }
    public Vector3 Scale { get; }

    public RectTransformSpec(
      Vector2 size = new Vector2(),
      TextAnchor pivot = TextAnchor.MiddleCenter,
      Vector2 position = new Vector2(),
      VerticalAnchor verticalAnchor = VerticalAnchor.Top,
      HorizontalAnchor horizontalAnchor = HorizontalAnchor.Left)
    {
      Size = size;
      Position = position;
      var anchors = AnchorValues(verticalAnchor, horizontalAnchor);
      AnchorMin = anchors.Item1;
      AnchorMax = anchors.Item2;
      Pivot = PivotValue(pivot);
      EulerRotation = Vector2.zero;
      Scale = Vector3.one;
    }

    public RectTransformSpec(
      Vector2 size,
      Vector3 position,
      Vector2? pivotPosition = null,
      Vector2 anchorMin = new Vector2(),
      Vector2 anchorMax = new Vector2(),
      Vector3 eulerRotation = new Vector3(),
      Vector3? scale = null)
    {
      Size = size;
      Position = position;
      Pivot = pivotPosition.GetValueOrDefault(new Vector2(x: 0.5f, y: 0.5f));
      AnchorMin = anchorMin;
      AnchorMax = anchorMax;
      EulerRotation = eulerRotation;
      Scale = scale.GetValueOrDefault(Vector3.one);
    }

    protected override void UpdateComponent(Res res, RectTransform transform)
    {
      //      component.sizeDelta = Vector2.zero;
      //      component.position = Vector3.zero;
      //      component.pivot = Vector2.zero;
      //      component.anchorMin = Vector2.zero;
      //      component.anchorMax = Vector2.zero;
      //      component.localEulerAngles = Vector3.zero;
      //      component.localScale = Vector3.one;

      transform.sizeDelta = Size;
      transform.position = Position;
      transform.pivot = Pivot;
      transform.anchorMin = AnchorMin;
      transform.anchorMax = AnchorMax;
      transform.localEulerAngles = EulerRotation;
      transform.localScale = Scale;

//      if (transform.sizeDelta != Size)
//      {
//        transform.sizeDelta = Size;
//      }
//      
//      if (transform.position != Position)
//      {
//        transform.position = Position;
//      }
//
//      if (transform.pivot != Pivot)
//      {
//        transform.pivot = Pivot;
//      }
//
//      if (transform.anchorMin != AnchorMin)
//      {
//        transform.anchorMin = AnchorMin;
//      }
//
//      if (transform.anchorMax != AnchorMax)
//      {
//        transform.anchorMax = AnchorMax;
//      }
//
//      if (transform.localEulerAngles != EulerRotation)
//      {
//        transform.localEulerAngles = EulerRotation;
//      }
//
//      if (transform.localScale != Scale)
//      {
//        transform.localScale = Scale;
//      }
    }
 
    private static Vector2 PivotValue(TextAnchor pivot)
    {
      switch (pivot)
      {
        case TextAnchor.UpperLeft:
          return new Vector2(x: 0f, y: 1f);
        case TextAnchor.UpperCenter:
          return new Vector2(x: 0.5f, y: 1f);
        case TextAnchor.UpperRight:
          return new Vector2(x: 1f, y: 1f);
        case TextAnchor.MiddleLeft:
          return new Vector2(x: 0f, y: 0.5f);
        case TextAnchor.MiddleCenter:
          return new Vector2(x: 0.5f, y: 0.5f);
        case TextAnchor.MiddleRight:
          return new Vector2(x: 1f, y: 0.5f);
        case TextAnchor.LowerLeft:
          return new Vector2(x: 0f, y: 0f);
        case TextAnchor.LowerCenter:
          return new Vector2(x: 0.5f, y: 1f);
        case TextAnchor.LowerRight:
          return new Vector2(x: 1f, y: 0f);
        default:
          throw Errors.UnknownEnumValue(pivot);
      }
    }

    private static Tuple<Vector2, Vector2> AnchorValues(
      VerticalAnchor verticalAnchor,
      HorizontalAnchor horizontalAnchor)
    {
      float minX;
      float minY;
      float maxX;
      float maxY;

      switch (horizontalAnchor)
      {
        case HorizontalAnchor.Right:
          minX = 1f;
          maxX = 1f;
          break;
        case HorizontalAnchor.Center:
          minX = 0.5f;
          maxX = 0.5f;
          break;
        case HorizontalAnchor.Left:
          minX = 0f;
          maxX = 0f;
          break;
        case HorizontalAnchor.Stretch:
          minX = 0f;
          maxX = 1f;
          break;
        default:
          throw Errors.UnknownEnumValue(verticalAnchor);
      }

      switch (verticalAnchor)
      {
        case VerticalAnchor.Top:
          minY = 1f;
          maxY = 1f;
          break;
        case VerticalAnchor.Middle:
          minY = 0.5f;
          maxY = 0.5f;
          break;
        case VerticalAnchor.Bottom:
          minY = 0f;
          maxY = 0f;
          break;
        case VerticalAnchor.Stretch:
          minY = 0f;
          maxY = 1f;
          break;
        default:
          throw Errors.UnknownEnumValue(verticalAnchor);
      }

      return Tuple.Create(new Vector2(minX, minY), new Vector2(maxX, maxY));
    }

    public Transform MountTransform(Res res, GameObject gameObject) =>
      Mount(res, gameObject);

    public void UpdateTransform(Res res, Transform instance)
    {
      Requires.Argument(
        instance is RectTransform,
        nameof(instance),
        message: "Must pass a RectTransform");
      UpdateComponent(res, (RectTransform)instance);
    }
  }
}