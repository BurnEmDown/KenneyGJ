using System;
using System.Collections.Generic;
using UnityEngine;

public class EventsController : MonoBehaviour
{
    public static EventsController Instance;

    private List<Event> eventsList;

    void Awake()
    {
        if(Instance)
            return;
        else
        {
            Instance = this;
        }
    }

    public void ShowNewEvent(Action onComplete)
    {
        
        
        
        onComplete.Invoke();
    }

    public void ShowNewYearEvent(Action onComplete)
    {
        
        
        
        onComplete.Invoke();
    }
}
