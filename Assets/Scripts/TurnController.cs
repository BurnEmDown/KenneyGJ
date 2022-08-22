using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TurnController : MonoBehaviour
{
    public static TurnController Instance;

    private int year;
    private int quarter;

    private const int START_YEAR = 2250;
    private const int START_QUARTER = 1;

    private const int END_YEAR = 2260;

    private bool badEventThisYear = false;
    
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
        year = START_YEAR;
        quarter = START_QUARTER;
        TurnView.Instance.UpdateDate(quarter, year);
        FirstYear();
    }

    public void FirstYear()
    {
        // show the new year event, then show the event of the first quarter of the year
        EventsController.Instance.ShowNewYearEvent(NextQuarter);
    }

    public void NewYear()
    {
        // calculate new money, food, population, etc.
        StatsController.Instance.NewYearCalculations();
        
        // indicate changes to the player on UI
        StatsController.Instance.UpdateAllViews();
        
        // show the new year event, then show the event of the first quarter of the year
        EventsController.Instance.ShowNewYearEvent(NextQuarter);
    }

    private void NextQuarter()
    {
        if (!badEventThisYear)
        {
            int rand = Random.Range(0, 3);
            if (rand == 0)
            {
                badEventThisYear = true;
                EventsController.Instance.ShowBadEvent(OnEventComplete);
                return;
            }
        }
        
        // show the new quarter event
        EventsController.Instance.ShowNewEvent(OnEventComplete);
    }

    private void OnEventComplete()
    {
        quarter++;
        if (quarter == 5)
        {
            quarter = 1;
            year++;
            badEventThisYear = false;
            TurnView.Instance.UpdateDate(quarter, year);

            if (year == END_YEAR)
            {
                GameManager.Instance.LoadVictoryScene();
            }
            NewYear();
        }
        else
        {
            TurnView.Instance.UpdateDate(quarter);
            NextQuarter();
        }
        
    }
}
