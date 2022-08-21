using System;
using System.Collections.Generic;
using UnityEngine;

public class EventsController : MonoBehaviour
{
    public static EventsController Instance;

    private List<Event> quarterEventsList;
    private List<Event> newYearEventsList;

    void Awake()
    {
        if (Instance)
        {
            Destroy(this);
        }
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
