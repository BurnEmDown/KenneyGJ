using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnView : MonoBehaviour
{
    public static TurnView Instance;

    public TMP_Text yearText;
    public TMP_Text quarterText;
    
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
