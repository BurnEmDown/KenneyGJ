using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsView : MonoBehaviour
{
    public static StatsView Instance;

    private static readonly Color defaultColor = Color.black;

    public Slider environmentBar;
    public TMP_Text popGrowthText;
    public TMP_Text foodText;
    public TMP_Text freeLandText;
    public TMP_Text farmsText;
    public TMP_Text moneyText;
    public TMP_Text happinessText;
    public TMP_Text unemploymentText;
    public TMP_Text popText;
    public GameObject statsInfo;
    
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
        UpdateDefaultTextColor();
    }

    private void UpdateDefaultTextColor()
    {
        popGrowthText.color = Color.black;
        foodText.color = Color.black;
        freeLandText.color = Color.black;
        farmsText.color = Color.black;
        moneyText.color = Color.black;
        happinessText.color = Color.black;
        unemploymentText.color = Color.black;
        popText.color = Color.black;
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
        environmentBar.value = environment;
    }

    public void InfoButtonClicked()
    {
        bool activate = !statsInfo.activeInHierarchy;
        statsInfo.SetActive(activate);
    }

    public void UpdateStatTemp(Color color, Stats stat, int num, double percentage, bool isPercentage)
    {
        switch (stat)
        {
            case Stats.Population:
                popText.color = color;
                if (isPercentage)
                {
                    popText.text = StatsController.Instance.TempChangePopByPercentage(percentage).ToString() + "M";
                }
                else
                {
                    popText.text = StatsController.Instance.TempChangePopByAmount(num).ToString() + "M";
                }
                break;
            case Stats.Food:
                foodText.color = color;
                if (isPercentage)
                {
                    foodText.text = StatsController.Instance.TempChangeFoodByPercentage(percentage).ToString();
                }
                else
                {
                    foodText.text = StatsController.Instance.TempChangeFoodByAmount(num).ToString();
                }
                break;
            case Stats.Money:
                moneyText.color = color;
                if (isPercentage)
                {
                    moneyText.text = StatsController.Instance.TempChangeMoneyByPercentage(percentage).ToString() + "T$";
                }
                else
                {
                    moneyText.text = StatsController.Instance.TempChangeMoneyByAmount(num).ToString() + "T$";    
                }
                break;
            case Stats.PopulationGrowth:
                popGrowthText.color = color;
                popGrowthText.text = StatsController.Instance.TempChangePopGrowthByAmount(percentage).ToString() + "%";
                break;
            case Stats.Farms:
                farmsText.color = color;
                if (isPercentage)
                {
                    farmsText.text = StatsController.Instance.TempChangeFarmsByPercentage(percentage).ToString();
                }
                else
                {
                    farmsText.text = StatsController.Instance.TempChangeFarmsByAmount(num).ToString();
                }
                break;
            case Stats.FreeLand:
                freeLandText.color = color;
                if (isPercentage)
                {
                    freeLandText.text = StatsController.Instance.TempChangeFreeLandByPercentage(percentage).ToString();
                }
                else
                {
                    freeLandText.text = StatsController.Instance.TempChangeFreeLandByAmount(num).ToString();
                }
                break;
            case Stats.Happiness:
                happinessText.color = color;
                happinessText.text = StatsController.Instance.TempChangeHappinessByAmount(num).ToString() + "%";
                break;
            case Stats.Environment:
                environmentBar.value += num;
                if (environmentBar.value > 5)
                    environmentBar.value = 5;
                if (environmentBar.value < 1)
                    environmentBar.value = 1;
                break;
            case Stats.Unemployment:
                color = num < 0 ? Color.green : Color.red;
                unemploymentText.color = color;
                unemploymentText.text = StatsController.Instance.TempChangeUnemploymentByAmount(num).ToString() + "%";
                break;
        }
    }
}
