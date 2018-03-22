using Specs.Core;
using Specs.Generated.Resources;
using Specs.Util;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Specs.Unity
{
  public enum ActionType
  {
    PointerEnter,
    PointerExit,
    PointerDown,
    PointerUp,
    PointerClick
  }

  public abstract class EventHandlerComponent : MonoBehaviour
  {
    public Action Action { get; set; }
  }

  public class PointerEnterHandlerComponent : EventHandlerComponent, IPointerEnterHandler
  {
    public void OnPointerEnter(PointerEventData eventData) => Action?.Invoke();
  }

  public class PointerExitHandlerComponent : EventHandlerComponent, IPointerExitHandler
  {
    public void OnPointerExit(PointerEventData eventData) => Action?.Invoke();
  }

  public class PointerDownHandlerComponent : EventHandlerComponent, IPointerDownHandler
  {
    public void OnPointerDown(PointerEventData eventData) => Action?.Invoke();
  }

  public class PointerUpHandlerComponent : EventHandlerComponent, IPointerUpHandler
  {
    public void OnPointerUp(PointerEventData eventData) => Action?.Invoke();
  }

  public class PointerClickHandlerComponent : EventHandlerComponent, IPointerClickHandler
  {
    public void OnPointerClick(PointerEventData eventData) => Action?.Invoke();
  }

  public class EventHandlerSpec : BehaviourSpec<EventHandlerComponent>
  {
    public ActionType ActionType { get; }
    public Action Action { get; }

    public EventHandlerSpec(
      ActionType actionType,
      Action action)
    {
      ActionType = actionType;
      Action = action;
    }

    protected override EventHandlerComponent AddComponent(GameObject gameObject)
    {
      switch (ActionType)
      {
        case ActionType.PointerEnter:
          return gameObject.AddComponent<PointerEnterHandlerComponent>();

        case ActionType.PointerExit:
          return gameObject.AddComponent<PointerExitHandlerComponent>();

        case ActionType.PointerDown:
          return gameObject.AddComponent<PointerDownHandlerComponent>();

        case ActionType.PointerUp:
          return gameObject.AddComponent<PointerUpHandlerComponent>();

        case ActionType.PointerClick:
          return gameObject.AddComponent<PointerClickHandlerComponent>();

        default:
          throw Errors.UnknownEnumValue(ActionType);
      }
    }

    protected override EventHandlerComponent GetComponent(GameObject gameObject)
    {
      switch (ActionType)
      {
        case ActionType.PointerEnter:
          return gameObject.GetComponent<PointerEnterHandlerComponent>();

        case ActionType.PointerExit:
          return gameObject.GetComponent<PointerExitHandlerComponent>();

        case ActionType.PointerDown:
          return gameObject.GetComponent<PointerDownHandlerComponent>();

        case ActionType.PointerUp:
          return gameObject.GetComponent<PointerUpHandlerComponent>();

        case ActionType.PointerClick:
          return gameObject.GetComponent<PointerClickHandlerComponent>();

        default:
          throw Errors.UnknownEnumValue(ActionType);
      }
    }

    protected override void UpdateComponent(Res res, EventHandlerComponent instance)
    {
      instance.Action = Action;
    }
  }
}