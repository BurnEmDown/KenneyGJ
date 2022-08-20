using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public TurnController Instance;

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
        // show the new year event 
        // show the new quarter event
    }

    public void NextQuarter()
    {
        // show the new quarter event
    }
}
