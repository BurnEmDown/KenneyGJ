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
    private int happiness; //percentage 0-100
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
    
    public int Happiness
    {
        get => happiness;
        private set
        {
            if (value is >= 0 and <= 100)
                happiness = value;
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

    public void AddPopByAmount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to add negative pop");
            return;
        }

        Population += amount;
    }

    public void SubtractPopByAmount(int amount)
    {
        amount = Math.Abs(amount);

        if (amount > Population)
        {
            // population will be 0, game over?
            amount = Population;
        }
        Population -= amount;
    }

    public void ChangePopByPercentage(float percentage)
    {
        int newPop = (int)(Population * percentage);
        Population = newPop;
    }

    public void ChangePopGrowthByAmount(float amount)
    {
        PopulationGrowth += amount;
    }

    public void AddFood(int newFood)
    {
        if (newFood < 0)
        {
            Debug.LogError("tried to add negative food");
            return;
        }
            

        Food += newFood;
    }

    public void SubtractFood(int foodTaken)
    {
        foodTaken = Math.Abs(foodTaken);

        if (foodTaken > Food)
        {
            // too much food was taken, need to hurt player
            foodTaken = Food;
        }
        Food -= foodTaken;
    }

    public void ChangeFoodByPercentage(float percentage)
    {
        if (percentage < 0)
        {
            Debug.LogError("tried to change food with negative percentage");
            return;
        }
        
        int newFood = (int)(Food * percentage);
        Food = newFood;
    }

    public void AddFreeLandByAmount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to add negative free land");
            return;
        }

        FreeLand += amount;
    }

    public void SubtractFreeLandByAmount(int amount)
    {
        amount = Math.Abs(amount);

        if (amount > FreeLand)
        {
            // too much free land was taken, need to hurt player
            amount = FreeLand;
        }
        FreeLand -= amount;
    }

    public void ChangeFreeLandByPercentage(float percentage)
    {
        if (percentage < 0)
        {
            Debug.LogError("tried to change free land with negative percentage");
            return;
        }
        
        int newFreeLand = (int)(FreeLand * percentage);
        FreeLand = newFreeLand;
    }
    
    public void ChangeFarmsByPercentage(float percentage)
    {
        if (percentage < 0)
        {
            Debug.LogError("tried to change farms with negative percentage");
            return;
        }
        
        int newFarms = (int)(Farms * percentage);
        Farms = newFarms;
    }
    
    public void AddFarmsByAmount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to add negative farms");
            return;
        }

        Farms += amount;
    }

    public void SubtractFarmsByAmount(int amount)
    {
        amount = Math.Abs(amount);

        if (amount > Farms)
        {
            // too much farms was taken, need to hurt player
            amount = Farms;
        }
        Farms -= amount;
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
        amount = Math.Abs(amount);

        if (amount > Money)
        {
            // too much money was taken, need to hurt player
            amount = Money;
        }
        Money -= amount;
    }

    public void ChangeMoneyByPercentage(float percentage)
    {
        if (percentage < 0)
        {
            Debug.LogError("tried to change with negative percentage");
            return;
        }

        int newMoney = (int)(Money * percentage);
        Money = newMoney;
    }

    public void AddHappinessByAmount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to add negative happiness");
            return;
        }

        if (amount + Happiness > 100)
        {
            Happiness = 100;
            return;
        }


        Happiness += amount;
    }
    
    public void SubtractHappinessByAmount(int amount)
    {
        amount = Math.Abs(amount);

        if (Happiness - amount < 0)
        {
            Happiness = 0;
            return;
        }


        Happiness -= amount;
    }

    public void AddUnemploymentByAmount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to add negative unemployment");
            return;
        }

        if (Unemployment + amount > 100)
        {
            Unemployment = 100;
            return;
        }
        else
        {
            Unemployment += amount;
        }

    }
    
    public void SubtractUnemploymentByAmount(int amount)
    {
        amount = Math.Abs(amount);

        if (Unemployment - amount < 0)
        {
            Unemployment = 0;
            return;
        }
        else
        {
            Unemployment -= amount;
        }

    }
    
    public void ChangeUnemploymentByPercentage(float percentage)
    {
        if (percentage < 0)
            return;
        
        int newUnemployment = (int)(Unemployment * percentage);
        Unemployment = newUnemployment;
    }

    public void IncreaseCreativePotentialByAmount(float amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to add negative creative potential");
            return;
        }

        creativePotential += amount;
        if (creativePotential > 1.5f)
            creativePotential = 1.5f;
    }
    
    public void DecreaseCreativePotentialByAmount(float amount)
    {
        amount = Math.Abs(amount);

        creativePotential -= amount;
        if (creativePotential < 0.5f)
            creativePotential = 0.5f;
    }

    public void IncreaseEnvironment()
    {
        if (Environment < 5)
            Environment++;
    }
    
    public void DecreaseEnvironment()
    {
        if (Environment > 1)
            Environment--;
    }
    
    #endregion
    
    void Awake()
    {
        if (Instance)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            SetInitialStats();
            UpdateAllViews();
        }
    }

    public void UpdateAllViews()
    {
        StatsView.Instance.UpdateAllStats(Population, PopulationGrowth, Food, FreeLand, Farms, Money, Happiness, Unemployment,
            Environment);
    }

    private float GetPercentageFromInt(int num)
    {
        float percentage = (float) num / 100f;

        return percentage;
    }
    
    public void NewYearCalculations()
    {
        PopsEatFood();
        GrowFoodFromFarms();
        CollectMoneyFromPopulation();
        GrowPop();
    }

    public void SetInitialStats()
    {
        Population = 1000;
        PopulationGrowth = 1.5;
        Food = 1000;
        Farms = 10;
        FreeLand = 10;
        Money = 1000;
        Happiness = 80;
        Unemployment = 10;
        creativePotential = 1.0f;
        environment = 1;
    }
    
    public void PopsEatFood()
    {
        SubtractFood(Population);
    }

    public void GrowFoodFromFarms()
    {
        Food += Farms * 100;
    }

    public void CollectMoneyFromPopulation()
    {
        double employment = 100 - Unemployment;
        Money += (int) (Population * creativePotential * employment / 100);
    }
    
    public void GrowPop()
    {
        int newPop = (int)((long)Population * PopulationGrowth);
        Population += newPop;
    }
}
