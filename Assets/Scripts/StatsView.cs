using UnityEngine;
using UnityEngine.UI;

public class StatsView : MonoBehaviour
{
    public static StatsView Instance;

    public Text popText;
    public Text popGrowthText;
    public Text foodText;
    public Text freeLandText;
    public Text farmsText;
    public Text moneyText;
    public Text happinessText;
    public Text unemploymentText;
    public GameObject environmentBar;
    
    void Awake()
    {
        if(Instance)
            return;
        else
        {
            Instance = this;
        }
    }

    public void UpdateAllStats(int pop, double popGrowth, int food, int freeLand, int farms, int money, int happiness, double unemployment, int environment)
    {
        UpdatePop(pop);
        UpdatePopGrowth(popGrowth);
        UpdateFood(food);
        UpdateFreeLand(freeLand);
        UpdateFarms(farms);
        UpdateMoney(money);
        UpdateHappiness(happiness);
        UpdateUnemployment(unemployment);
        UpdateEnvironment(environment);
    }

    public void UpdatePop(int pop)
    {
        popText.text = pop.ToString() + "M";
    }

    public void UpdatePopGrowth(double popGrowth)
    {
        popGrowthText.text = popGrowth.ToString() + "%";
    }

    public void UpdateFood(int food)
    {
        foodText.text = food.ToString();
    }

    public void UpdateFreeLand(int freeLand)
    {
        freeLandText.text = freeLand.ToString();
    }
    
    public void UpdateFarms(int farms)
    {
        farmsText.text = farms.ToString();
    }

    public void UpdateMoney(int money)
    {
        moneyText.text = money.ToString() + "T$";
    }
    
    public void UpdateHappiness(int happiness)
    {
        happinessText.text = happiness.ToString() + "%";
    }

    public void UpdateUnemployment(double unemployment)
    {
        unemploymentText.text = unemployment.ToString() + "%";
    }

    public void UpdateEnvironment(int environment)
    {
        // this one is a bar that gets filled
    }
}
