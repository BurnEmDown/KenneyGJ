using TMPro;
using UnityEngine;

public class EventsView : MonoBehaviour
{
    public static EventsView Instance;

    public GameObject eventTextBox;
    public TMP_Text eventText;
    public GameObject eventOptionsBox;
    public GameObject eventOptionA;
    public GameObject eventOptionB;
    public GameObject eventOptionC;
    public GameObject eventOptionD;
    
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

    public void HideAllEventUI()
    {
        eventTextBox.SetActive(false);
        eventText.gameObject.SetActive(false);
        eventOptionsBox.SetActive(false);
        eventOptionA.SetActive(false);
        eventOptionB.SetActive(false);
        eventOptionC.SetActive(false);
        eventOptionD.SetActive(false);
    }

    public void ShowEventBoxAndText()
    {
        eventTextBox.SetActive(true);
        eventText.gameObject.SetActive(true);
    }

    public void ShowEventOptions(Event eventToShow)
    {
        eventOptionsBox.SetActive(true);

        switch (eventToShow.eventOptions.Count)
        {
            case 1:
                eventOptionA.SetActive(true);
                break;
            case 2:
                eventOptionA.SetActive(true);
                eventOptionB.SetActive(true);
                break;
            case 3:
                eventOptionA.SetActive(true);
                eventOptionB.SetActive(true);
                eventOptionC.SetActive(true);
                break;
            case 4:
                eventOptionA.SetActive(true);
                eventOptionB.SetActive(true);
                eventOptionC.SetActive(true);
                eventOptionD.SetActive(true);
                break;
        }
    }
}
