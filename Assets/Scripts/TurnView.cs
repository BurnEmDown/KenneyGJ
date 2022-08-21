using UnityEngine;
using UnityEngine.UI;

public class TurnView : MonoBehaviour
{
    public static TurnView Instance;

    public Text yearText;
    public Text quarterText;
    
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

    public void UpdateDate(int quarter, int year)
    {
        yearText.text = year.ToString();
        quarterText.text = quarter.ToString();
    }
    
    public void UpdateDate(int quarter)
    {
        quarterText.text = quarter.ToString();
    }
}
