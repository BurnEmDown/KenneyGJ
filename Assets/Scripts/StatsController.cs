using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    public static StatsController Instance;

    private int population;
    private double populationGrowth;
    private int food;
    private int farms;
    private int freeLand;
    private int money;
    private double unemployment; //percentage 0-100
    private float creativePotential; // 0.5 - 1.5
    private int environment; // 1 - 5

    #region GettersSetters

    public int Population
    {
        get => population;
        private set
        {
            if (value > 0)
                population = value;
            else
            {
                // pop is zero, game over!!!
            }
        }
    }

    public double PopulationGrowth
    {
        get => populationGrowth;
        private set { populationGrowth = Math.Round(value, 2); }
    }

    public int Food
    {
        get => food;
        private set
        {
            if (value >= 0)
                food = value;
        }
    }

    public int Farms
    {
        get => farms;
        private set
        {
            if (value >= 0)
                farms = value;
        }
    }

    public int FreeLand
    {
        get => freeLand;
        private set
        {
            if (value >= 0)
                freeLand = value;
        }
    }

    public int Money
    {
        get => money;
        private set
        {
            if (value >= 0)
                money = value;
        }
    }

    public double Unemployment
    {
        get => unemployment;
        private set
        {
            if (value is < 0.0 or > 100.0)
            {
                Debug.LogError("tried to set unemployment to invalid number");
                return;
            }

            value = Math.Round(value, 1);
            unemployment = value;
        }
    }

    public int Environment
    {
        get => environment;
        set
        {
            if (value is >= 1 and <= 5)
                environment = value;
        }
    }

    #endregion

    #region StatsChangers

    public void GrowPop()
    {
        int newPop = (int)((long)population * PopulationGrowth);
        population += newPop;
    }

    public void AddPopByAmount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to add negative pop");
            return;
        }

        population += amount;
    }

    public void SubtractPopByAmount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to subtract negative pop");
            return;
        }

        if (amount > population)
        {
            // population will be 0, game over?
            amount = population;
        }
        population -= amount;
    }

    public void ChangePopByPercentage(int percentage)
    {
        float realPercentage = GetPercentageFromInt(percentage);

        int newPop = (int)(population * realPercentage);
        population = newPop;
    }

    public void ChangePopGrowthByAmount(int amount)
    {
        float realAmount = GetPercentageFromInt(amount);
        
        PopulationGrowth += realAmount;
    }

    public void ChangePopGrowthByPercentage(int percentage)
    {
        float realPercentage = GetPercentageFromInt(percentage);
        
        PopulationGrowth *= realPercentage;
    }

    public void AddFood(int newFood)
    {
        if (newFood < 0)
        {
            Debug.LogError("tried to add negative food");
            return;
        }
            

        food += newFood;
    }

    public void SubtractFood(int foodTaken)
    {
        if (foodTaken < 0)
        {
            Debug.LogError("tried to subtract negative food");
            return;
        }
        
        if (foodTaken > food)
        {
            // too much food was taken, need to hurt player
            foodTaken = food;
        }
        food -= foodTaken;
    }

    public void AddFreeLandByAmount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to add negative free land");
            return;
        }

        freeLand += amount;
    }

    public void SubtractFreeLandByAmount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to subtract negative free land");
            return;
        }
        
        if (amount > freeLand)
        {
            // too much free land was taken, need to hurt player
            amount = freeLand;
        }
        freeLand -= amount;
    }

    public void ChangeFreeLandByPercentage(int percentage)
    {
        float realPercentage = GetPercentageFromInt(percentage);

        int newFreeLand = (int)(FreeLand * realPercentage);
        FreeLand = newFreeLand;
    }
    
    public void AddFarmsByAmount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to add negative farms");
            return;
        }

        farms += amount;
    }

    public void SubtractFarmsByAmount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to subtract negative farms");
            return;
        }
        
        if (amount > farms)
        {
            // too much farms was taken, need to hurt player
            amount = farms;
        }
        farms -= amount;
    }

    public void ChangeFarmsByPercentage(int percentage)
    {
        float realPercentage = GetPercentageFromInt(percentage);

        int newFreeLand = (int)(FreeLand * realPercentage);
        FreeLand = newFreeLand;
    }

    public void AddMoneyByAmount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to add negative money");
            return;
        }
        Money += amount;
    }
    
    public void SubtractMoneyByAmount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to subtract negative money");
            return;
        }

        if (amount > money)
        {
            // too much money was taken, need to hurt player
            amount = money;
        }
        Money -= amount;
    }

    public void ChangeMoneyByPercentage(float percentage)
    {
        if (percentage < 0)
            return;
        
        int newMoney = (int)(Money * percentage);
        Money = newMoney;
    }

    public void AddUnemploymentByAmount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to add negative unemployment");
            return;
        }

        if (unemployment + amount > 100)
        {
            unemployment = 100;
            return;
        }
        else
        {
            unemployment += amount;
        }

    }
    
    public void SubtractUnemploymentByAmount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to subtract negative unemployment");
            return;
        }

        if (unemployment - amount < 0)
        {
            unemployment = 0;
            return;
        }
        else
        {
            unemployment -= amount;
        }

    }
    
    public void ChangeUnemploymentByPercentage(float percentage)
    {
        if (percentage < 0)
            return;
        
        int newUnemployment = (int)(unemployment * percentage);
        unemployment = newUnemployment;
    }

    public void IncreaseEnvironment()
    {
        if (environment < 5)
            environment++;
    }
    
    public void DecreaseEnvironment()
    {
        if (environment > 1)
            environment--;
    }
    
    #endregion
    
    void Awake()
    {
        if(Instance)
            return;
        else
        {
            Instance = this;
        }
    }

    public void UpdateAllViews()
    {
        StatsView.Instance.UpdateAllStats(Population, PopulationGrowth, Food, FreeLand, farms, Money, Unemployment,
            Environment);
    }

    private float GetPercentageFromInt(int num)
    {
        float percentage = (float) num / 100f;

        return percentage;
    }
    
}
