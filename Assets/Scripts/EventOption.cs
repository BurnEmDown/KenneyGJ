﻿using System;
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
                    if (effect.isPercentage)
                    {
                        StatsController.Instance.ChangePopByPercentage(effect.amount);
                    }
                    else
                    {
                        if (effect.amount <= 0)
                        {
                            StatsController.Instance.SubtractPopByAmount(effect.amount);
                        }
                        else
                        {
                            StatsController.Instance.AddPopByAmount(effect.amount);
                        }
                    }
                    break;
                case Stats.PopulationGrowth:
                    if (effect.isPercentage)
                    {
                        StatsController.Instance.ChangePopByPercentage(effect.amount);
                    }
                    else
                    {
                        StatsController.Instance.ChangePopGrowthByAmount(effect.amount);
                    }
                    break;
                case Stats.Food:
                    if (effect.amount <= 0)
                    {
                        StatsController.Instance.SubtractFood(effect.amount);
                    }
                    else
                    {
                        StatsController.Instance.AddFood(effect.amount);
                    }
                    break;
                case Stats.FreeLand:
                    if (effect.isPercentage)
                    {
                        StatsController.Instance.ChangeFreeLandByPercentage(effect.amount);
                    }
                    else
                    {
                        if (effect.amount <= 0)
                        {
                            StatsController.Instance.SubtractFreeLandByAmount(effect.amount);
                        }
                        else
                        {
                            StatsController.Instance.AddFreeLandByAmount(effect.amount);
                        }
                    }
                    break;
                case Stats.Money:
                    if (effect.isPercentage)
                    {
                        StatsController.Instance.ChangeMoneyByPercentage(effect.amount);
                    }
                    else
                    {
                        if (effect.amount <= 0)
                        {
                            StatsController.Instance.SubtractMoneyByAmount(effect.amount);
                        }
                        else
                        {
                            StatsController.Instance.AddMoneyByAmount(effect.amount);
                        }
                    }
                    break;
                case Stats.Unemployment:
                    if (effect.isPercentage)
                    {
                        StatsController.Instance.ChangeUnemploymentByPercentage(effect.amount);
                    }
                    else
                    {
                        if (effect.amount <= 0)
                        {
                            StatsController.Instance.SubtractUnemploymentByAmount(effect.amount);
                        }
                        else
                        {
                            StatsController.Instance.AddUnemploymentByAmount(effect.amount);
                        }
                    }
                    break;
                case Stats.Environment:
                    if (effect.amount > 0)
                    {
                        StatsController.Instance.IncreaseEnvironment();
                    }
                    else
                    {
                        StatsController.Instance.DecreaseEnvironment();
                    }
                    break;
            }
        }
    }
}