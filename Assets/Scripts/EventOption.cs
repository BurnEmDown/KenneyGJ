using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class EventOption : ScriptableObject
{
    public string optionText;
    public List<EventEffect> effects;
    public Button assignedButton;

    public void ActivateEffects()
    {
        foreach (EventEffect effect in effects)
        {
            switch (effect.statAffected)
            {
                case Stats.Population:
                    if (effect.isPercentage)
                    {
                        StatsController.Instance.ChangePopByPercentage(effect.intAmount);
                    }
                    else
                    {
                        if (effect.intAmount <= 0)
                        {
                            StatsController.Instance.SubtractPopByAmount(effect.intAmount);
                        }
                        else
                        {
                            StatsController.Instance.AddPopByAmount(effect.intAmount);
                        }
                    }
                    break;
                case Stats.PopulationGrowth:
                    StatsController.Instance.ChangePopGrowthByAmount(effect.floatAmount);
                    break;
                case Stats.Food:
                    if (effect.intAmount <= 0)
                    {
                        StatsController.Instance.SubtractFood(effect.intAmount);
                    }
                    else
                    {
                        StatsController.Instance.AddFood(effect.intAmount);
                    }
                    break;
                case Stats.FreeLand:
                    if (effect.isPercentage)
                    {
                        StatsController.Instance.ChangeFreeLandByPercentage(effect.intAmount);
                    }
                    else
                    {
                        if (effect.intAmount <= 0)
                        {
                            StatsController.Instance.SubtractFreeLandByAmount(effect.intAmount);
                        }
                        else
                        {
                            StatsController.Instance.AddFreeLandByAmount(effect.intAmount);
                        }
                    }
                    break;
                case Stats.Farms:
                    if (effect.isPercentage)
                    {
                        StatsController.Instance.ChangeFarmsByPercentage(effect.intAmount);
                    }
                    else
                    {
                        if (effect.intAmount <= 0)
                        {
                            StatsController.Instance.SubtractFarmsByAmount(effect.intAmount);
                        }
                        else
                        {
                            StatsController.Instance.AddFarmsByAmount(effect.intAmount);
                        }
                    }
                    break;
                case Stats.Money:
                    if (effect.isPercentage)
                    {
                        StatsController.Instance.ChangeMoneyByPercentage(effect.intAmount);
                    }
                    else
                    {
                        if (effect.intAmount <= 0)
                        {
                            StatsController.Instance.SubtractMoneyByAmount(effect.intAmount);
                        }
                        else
                        {
                            StatsController.Instance.AddMoneyByAmount(effect.intAmount);
                        }
                    }
                    break;
                case Stats.Happiness:
                    if (effect.intAmount <= 0)
                    {
                        StatsController.Instance.SubtractHappinessByAmount(effect.intAmount);
                    }
                    else
                    {
                        StatsController.Instance.AddHappinessByAmount(effect.intAmount);
                    }
                    break;
                case Stats.Unemployment:
                    if (effect.isPercentage)
                    {
                        StatsController.Instance.ChangeUnemploymentByPercentage(effect.intAmount);
                    }
                    else
                    {
                        if (effect.intAmount <= 0)
                        {
                            StatsController.Instance.SubtractUnemploymentByAmount(effect.intAmount);
                        }
                        else
                        {
                            StatsController.Instance.AddUnemploymentByAmount(effect.intAmount);
                        }
                    }
                    break;
                case Stats.CreativePotential:
                    if (effect.floatAmount < 0)
                    {
                        StatsController.Instance.DecreaseCreativePotentialByAmount(effect.floatAmount);
                    }
                    else
                    {
                        StatsController.Instance.IncreaseCreativePotentialByAmount(effect.floatAmount);
                    }
                    break;
                case Stats.Environment:
                    if (effect.intAmount > 0)
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

    public void DisableOption()
    {
        assignedButton.interactable = false;
    }

    public void EnableOption()
    {
        assignedButton.interactable = true;
    }
}