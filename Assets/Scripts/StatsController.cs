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

    public void GrowPop()
    {
        int newPop = (int)((long)Population * PopulationGrowth);
        Population += newPop;
    }

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
        if (amount < 0)
        {
            Debug.LogError("tried to subtract negative pop");
            return;
        }

        if (amount > Population)
        {
            // population will be 0, game over?
            amount = Population;
        }
        Population -= amount;
    }

    public void ChangePopByPercentage(int percentage)
    {
        float realPercentage = GetPercentageFromInt(percentage);

        int newPop = (int)(Population * realPercentage);
        Population = newPop;
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
            

        Food += newFood;
    }

    public void SubtractFood(int foodTaken)
    {
        if (foodTaken < 0)
        {
            Debug.LogError("tried to subtract negative food");
            return;
        }
        
        if (foodTaken > Food)
        {
            // too much food was taken, need to hurt player
            foodTaken = Food;
        }
        Food -= foodTaken;
    }

    public void GrowFoodFromFarms()
    {
        Food += Farms * 100;
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
        if (amount < 0)
        {
            Debug.LogError("tried to subtract negative free land");
            return;
        }
        
        if (amount > FreeLand)
        {
            // too much free land was taken, need to hurt player
            amount = FreeLand;
        }
        FreeLand -= amount;
    }

    public void ChangeFreeLandByPercentage(int percentage)
    {
        float realPercentage = GetPercentageFromInt(percentage);

        int newFreeLand = (int)(FreeLand * realPercentage);
        FreeLand = newFreeLand;
    }
    
    public void ChangeFarmsByPercentage(int percentage)
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

        Farms += amount;
    }

    public void SubtractFarmsByAmount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to subtract negative farms");
            return;
        }
        
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
        if (amount < 0)
        {
            Debug.LogError("tried to subtract negative money");
            return;
        }

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

    public void CollectMoneyFromPopulation()
    {
        double employment = 100 - Unemployment;
        Money += (int) (Population * creativePotential * employment / 100);
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
        if (amount < 0)
        {
            Debug.LogError("tried to subtract negative happiness");
            return;
        }

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
        if (amount < 0)
        {
            Debug.LogError("tried to subtract negative unemployment");
            return;
        }

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

    public void IncreaseCreativePotentialByAmount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to add negative creative potential");
            return;
        }

        float percentage = GetPercentageFromInt(amount);
        
        creativePotential += percentage;
        if (creativePotential > 1.5f)
            creativePotential = 1.5f;
    }
    
    public void DecreaseCreativePotentialByAmount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("tried to subtract negative creative potential");
            return;
        }
        
        float percentage = GetPercentageFromInt(amount);

        creativePotential -= percentage;
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
        GrowFoodFromFarms();
        CollectMoneyFromPopulation();
        GrowPop();
    }

    public void SetInitialStats()
    {
        Population = 100;
        PopulationGrowth = 1.5;
        Food = 100;
        Farms = 100;
        FreeLand = 100;
        Money = 100;
        Happiness = 80;
        Unemployment = 10;
        creativePotential = 1.0f;
        environment = 1;
    }
}
