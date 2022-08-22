using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventsController : MonoBehaviour
{
    public static EventsController Instance;

    [SerializeField] private List<Event> quarterEventsList;
    [SerializeField] private List<Event> badEventsList;
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
        quarterEvent.EnableAllOptions();
        DisableInvalidEventOptions(quarterEvent);
    }
    
    public void ShowBadEvent(Action onComplete)
    {
        int eventNum = Random.Range(0, badEventsList.Count-1);

        Event badEvent = badEventsList[eventNum];
        EventsView.Instance.ShowEvent(badEvent, onComplete);
        badEvent.EnableAllOptions();
        DisableInvalidEventOptions(badEvent);
    }

    public void ShowNewYearEvent(Action onComplete)
    {
        int eventNum = Random.Range(0, newYearEventsList.Count-1);
        
        Event yearlyEvent = newYearEventsList[eventNum];
        EventsView.Instance.ShowEvent(yearlyEvent, onComplete);
        yearlyEvent.EnableAllOptions();
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
