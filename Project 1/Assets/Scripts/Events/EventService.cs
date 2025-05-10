using Player;
using UnityEngine;

namespace Events
{
    public class EventService
    {
        public EventController<Vector3> onPlayerPositionChanged;

        public EventService()
        {
            onPlayerPositionChanged = new EventController<Vector3>();
        }

    }
}