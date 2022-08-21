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
    
    private void DisableInvalidEventOptions(Event eventToCheck)
    {
        foreach (var option in eventToCheck.eventOptions)
        {
            foreach (var effect in option.effects)
            {
                switch (effect.statAffected)
                {
                    case Stats.Money:
                        if (!effect.isPercentage && StatsController.Instance.Money + effect.amount < 0)
                        {
                            // disable option
                        }
                        break;
                    
                    case Stats.FreeLand:
                        if (!effect.isPercentage && StatsController.Instance.FreeLand + effect.amount < 0)
                        {
                            // disable option
                        }
                        break;
                    case Stats.Food:
                        if (!effect.isPercentage && StatsController.Instance.Food + effect.amount < 0)
                        {
                            // disable option
                        }
                        break;
                    case Stats.Farms:
                        if (!effect.isPercentage && StatsController.Instance.Farms + effect.amount < 0)
                        {
                            // disable option
                        }
                        break;
                    default:
                        break;
                    
                }
            }
        }
    }
}
