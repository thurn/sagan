using Specs.Core;
using Specs.Generated;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Specs.Unity
{
  public class EventSystemSpec : Spec<EventSystem>
  {
    public bool SendNavigationEvents { get; }
    public int DragThreshold { get; }

    public EventSystemSpec(
      bool sendNavigationEvents = true,
      int dragThreshold = 5)
    {
      SendNavigationEvents = sendNavigationEvents;
      DragThreshold = dragThreshold;
    }

    public override EventSystem Mount(Res res, GameObject gameObject)
      => gameObject.AddComponent<EventSystem>();

    public override void Update(Res res, EventSystem eventSystem)
    {
      eventSystem.sendNavigationEvents = SendNavigationEvents;
      eventSystem.pixelDragThreshold = DragThreshold;
    }

    public override EventSystem GetInstance(GameObject gameObject) =>
      gameObject.GetComponent<EventSystem>();
  }
}