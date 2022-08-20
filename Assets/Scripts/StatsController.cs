using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    public StatsController Instance;
    
    private long population;
    private int food;
    private int freeLand;
    private int money;
    private int unemployment; //percentage 0-100
    private float creativePotential; // 0.5 - 1.5
    private int environment; // 1 - 5
    
    #region GettersSetters
    
    public long Population
    { 
        get => population;
        private set {
            if (value >= 0)
                population = value;
        }
    }
    
    public float PopulationGrowth { get; private set; }

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
        
    public int Unemployment
    {
        get => unemployment;
        private set {
            if (value is >= 0 and <= 100)
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
