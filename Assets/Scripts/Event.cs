using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Event : ScriptableObject
{
        public string eventName;
        public string eventText;
        public List<EventOption> eventOptions;
}
