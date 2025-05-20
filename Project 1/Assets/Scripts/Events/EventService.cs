using Player;
using UnityEngine;

namespace Events
{
    public class EventService
    {
        public EventController<Vector3> onPlayerPositionChanged;
        public EventController<bool> onSpeedBoosterToggled;
        public EventController<bool> OnShieldToggled;
        public EventController OnDestroyerToggled;
        public EventService()
        {
            onPlayerPositionChanged = new EventController<Vector3>();
            onSpeedBoosterToggled = new EventController<bool>();
            OnShieldToggled = new EventController<bool>();
            OnDestroyerToggled = new EventController();
        }

    }
}