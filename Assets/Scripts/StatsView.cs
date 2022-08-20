using UnityEngine;
using UnityEngine.UI;

public class StatsView : MonoBehaviour
{
    public static StatsView Instance;

    public Text popText;
    public Text popGrowthText;
    public Text foodText;
    public Text freeLandText;
    public Text moneyText;
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

    public void UpdateAllStats(long pop, double popGrowth, int food, int freeLand, int money, double unemployment, int environment)
    {
        UpdatePop(pop);
        UpdatePopGrowth(popGrowth);
        UpdateFood(food);
        UpdateFreeLand(freeLand);
        UpdateMoney(money);
        UpdateUnemployment(unemployment);
        UpdateEnvironment(environment);
    }

    public void UpdatePop(long pop)
    {
        popText.text = pop.ToString();
    }

    public void UpdatePopGrowth(double popGrowth)
    {
        popGrowthText.text = popGrowth.ToString();
    }

    public void UpdateFood(int food)
    {
        foodText.text = food.ToString();
    }

    public void UpdateFreeLand(int freeLand)
    {
        freeLandText.text = freeLand.ToString();
    }

    public void UpdateMoney(int money)
    {
        moneyText.text = money.ToString();
    }

    public void UpdateUnemployment(double unemployment)
    {
        unemploymentText.text = unemployment.ToString();
    }

    public void UpdateEnvironment(int environment)
    {
        // this one is a bar that gets filled
    }
}
