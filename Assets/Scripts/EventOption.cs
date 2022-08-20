using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EventOption : ScriptableObject
{
    public string optionName;
    public string optionText;
    public List<EventEffect> effects;

    public void ActivateEffects()
    {
        foreach (EventEffect effect in effects)
        {
            switch (effect.statAffected)
            {
                case Stats.Population:
                    
                    break;
                case Stats.PopulationGrowth:
                    
                    break;
                case Stats.Food:
                    
                    break;
                case Stats.FreeLand:
                    
                    break;
                case Stats.Money:
                    
                    break;
                case Stats.Unemployment:
                    
                    break;
                case Stats.Environment:
                    
                    break;
            }
        }
    }
}