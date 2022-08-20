using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public static TurnController Instance;

    private int year;
    private int quarter;
    
    void Awake()
    {
        if(Instance)
            return;
        else
        {
            Instance = this;
        }
    }

    public void NewYear()
    {
        // calculate new money, food, population, etc.
        
        // indicate changes to the player on UI
        StatsController.Instance.UpdateAllViews();
        
        // show the new year event, then show the event of the first quarter of the year
        EventsController.Instance.ShowNewYearEvent(NextQuarter);
    }

    public void NextQuarter()
    {
        // show the new quarter event
        EventsController.Instance.ShowNewEvent(() =>
        {
            quarter++;
            if (quarter == 4)
            {
                quarter = 1;
                year++;
                TurnView.Instance.UpdateDate(quarter, year);
                NewYear();
            }
            else
            {
                TurnView.Instance.UpdateDate(quarter);
                NextQuarter();
            }
            
        });
    }
}
