using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    public static StatsController Instance;
    
    private long population;
    private double populationGrowth;
    private int food;
    private int freeLand;
    private int money;
    private double unemployment; //percentage 0-100
    private float creativePotential; // 0.5 - 1.5
    private int environment; // 1 - 5
    
    #region GettersSetters
    
    public long Population
    { 
        get => population;
        private set {
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
        private set
        {
            populationGrowth = Math.Round(value, 2);
        }
    }

    public int Food
    {
        get => food;
        private set {
            if (value >= 0)
                food = value;
        }
    }
        
    public int FreeLand
    {
        get => freeLand;
        private set {
            if (value >= 0)
                freeLand = value;
        }
    }
        
    public int Money
    {
        get => money;
        private set {
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
        long newPop = (long)((long) population * PopulationGrowth);
        population += newPop;
    }

    public void ChangePopGrowthByAmount(float amount)
    {
        PopulationGrowth += amount;
    }

    public void ChangePopGrowthByPercentage(float percentage)
    {
        PopulationGrowth *= percentage;
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

    public void AddEmploymentByAmount(int amount)
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
    
    public void SubtractEmploymentByAmount(int amount)
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
    
}
