using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventsController : MonoBehaviour
{
    public static EventsController Instance;

    [SerializeField] private List<Event> quarterEventsList;
    [SerializeField] private List<Event> newYearEventsList;

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

    private void OnEnable()
    {
        
    }

    public void OnGUI()
    {
        
    }

    public void ShowNewEvent(Action onComplete)
    {
        int eventNum = Random.Range(0, quarterEventsList.Count-1);

        Event quarterEvent = quarterEventsList[eventNum];
        quarterEventsList.RemoveAt(eventNum);
        EventsView.Instance.ShowEvent(quarterEvent, onComplete);
        DisableInvalidEventOptions(quarterEvent);
    }

    public void ShowNewYearEvent(Action onComplete)
    {
        int eventNum = Random.Range(0, newYearEventsList.Count-1);
        
        Event yearlyEvent = quarterEventsList[eventNum];
        EventsView.Instance.ShowEvent(yearlyEvent, onComplete);
        DisableInvalidEventOptions(yearlyEvent);
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
                        if (!effect.isPercentage && StatsController.Instance.Money + effect.intAmount < 0)
                        {
                            // disable option
                            option.DisableOption();
                        }
                        break;
                    
                    case Stats.FreeLand:
                        if (!effect.isPercentage && StatsController.Instance.FreeLand + effect.intAmount < 0)
                        {
                            // disable option
                            option.DisableOption();
                        }
                        break;
                    case Stats.Food:
                        if (!effect.isPercentage && StatsController.Instance.Food + effect.intAmount < 0)
                        {
                            // disable option
                            option.DisableOption();
                        }
                        break;
                    case Stats.Farms:
                        if (!effect.isPercentage && StatsController.Instance.Farms + effect.intAmount < 0)
                        {
                            // disable option
                            option.DisableOption();
                        }
                        break;
                    default:
                        break;
                    
                }
            }
        }
    }
}
