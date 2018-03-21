using Specs.Core;
using Specs.Generated.Resources;
using UnityEngine.EventSystems;

namespace Specs.Unity
{
  public class EventSystemSpec : BehaviourSpec<EventSystem>
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

    protected override void UpdateComponent(Res res, EventSystem eventSystem)
    {
      eventSystem.sendNavigationEvents = SendNavigationEvents;
      eventSystem.pixelDragThreshold = DragThreshold;
    }
  }
}