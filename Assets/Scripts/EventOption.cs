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
                case Stats.Farms:
                    if (effect.isPercentage)
                    {
                        StatsController.Instance.ChangeFarmsByPercentage(effect.amount);
                    }
                    else
                    {
                        if (effect.amount <= 0)
                        {
                            StatsController.Instance.SubtractFarmsByAmount(effect.amount);
                        }
                        else
                        {
                            StatsController.Instance.AddFarmsByAmount(effect.amount);
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
                case Stats.Happiness:
                    if (effect.amount <= 0)
                    {
                        StatsController.Instance.SubtractHappinessByAmount(effect.amount);
                    }
                    else
                    {
                        StatsController.Instance.AddHappinessByAmount(effect.amount);
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

    public void DisableOption()
    {
        assignedButton.interactable = false;
    }

    public void EnableOption()
    {
        assignedButton.interactable = true;
    }
}