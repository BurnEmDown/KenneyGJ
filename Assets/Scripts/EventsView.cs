using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventsView : MonoBehaviour
{
    public static EventsView Instance;

    public GameObject eventTextBox;
    public TMP_Text eventDescriptionText;
    public TMP_Text eventNameText;
    public GameObject eventOptionsBox;
    public Button eventOptionA;
    public TMP_Text eventOptionAText;
    public Button eventOptionB;
    public TMP_Text eventOptionBText;
    public Button eventOptionC;
    public TMP_Text eventOptionCText;
    public Button eventOptionD;
    public TMP_Text eventOptionDText;

    public Action onEventCompleteAction;
    
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
        eventDescriptionText.gameObject.SetActive(false);
        eventNameText.gameObject.SetActive(false);
        eventOptionsBox.SetActive(false);
        eventOptionA.gameObject.SetActive(false);
        eventOptionB.gameObject.SetActive(false);
        eventOptionC.gameObject.SetActive(false);
        eventOptionD.gameObject.SetActive(false);
        eventOptionAText.gameObject.SetActive(false);
        eventOptionBText.gameObject.SetActive(false);
        eventOptionCText.gameObject.SetActive(false);
        eventOptionDText.gameObject.SetActive(false);
    }

    public void UpdateEventTextBox(Event eventToShow)
    {
        eventDescriptionText.text = eventToShow.eventText;
        eventNameText.text = eventToShow.eventName;
    }

    public void UpdateEventOptions(Event eventToShow)
    {
        switch (eventToShow.eventOptions.Count)
        {
            case 1:
                eventOptionAText.text = eventToShow.eventOptions[0].optionText;
                break;
            case 2:
                eventOptionAText.text = eventToShow.eventOptions[0].optionText;
                eventOptionBText.text = eventToShow.eventOptions[1].optionText;
                break;
            case 3:
                eventOptionAText.text = eventToShow.eventOptions[0].optionText;
                eventOptionBText.text = eventToShow.eventOptions[1].optionText;
                eventOptionCText.text = eventToShow.eventOptions[2].optionText;
                break;
            case 4:
                eventOptionAText.text = eventToShow.eventOptions[0].optionText;
                eventOptionBText.text = eventToShow.eventOptions[1].optionText;
                eventOptionCText.text = eventToShow.eventOptions[2].optionText;
                eventOptionDText.text = eventToShow.eventOptions[3].optionText;
                break;
        }
    }

    public void ShowEventBoxAndText()
    {
        eventTextBox.SetActive(true);
        eventDescriptionText.gameObject.SetActive(true);
        eventNameText.gameObject.SetActive(true);
    }

    public void ShowEventOptions(Event eventToShow)
    {
        eventOptionsBox.SetActive(true);

        switch (eventToShow.eventOptions.Count)
        {
            case 1:
                eventOptionA.gameObject.SetActive(true);
                eventOptionAText.gameObject.SetActive(true);
                eventToShow.eventOptions[0].assignedButton = eventOptionA;
                eventToShow.eventOptions[0].assignedButton.onClick.RemoveAllListeners();
                eventToShow.eventOptions[0].assignedButton.onClick.AddListener(eventToShow.eventOptions[0].ActivateEffects);
                eventToShow.eventOptions[0].assignedButton.onClick.AddListener(OnEventComplete);
                break;
            case 2:
                eventOptionA.gameObject.SetActive(true);
                eventOptionAText.gameObject.SetActive(true);
                eventToShow.eventOptions[0].assignedButton = eventOptionA;
                eventToShow.eventOptions[0].assignedButton.onClick.RemoveAllListeners();
                eventToShow.eventOptions[0].assignedButton.onClick.AddListener(eventToShow.eventOptions[0].ActivateEffects);
                eventToShow.eventOptions[0].assignedButton.onClick.AddListener(OnEventComplete);
                eventOptionB.gameObject.SetActive(true);
                eventOptionBText.gameObject.SetActive(true);
                eventToShow.eventOptions[1].assignedButton = eventOptionB;
                eventToShow.eventOptions[1].assignedButton.onClick.RemoveAllListeners();
                eventToShow.eventOptions[1].assignedButton.onClick.AddListener(eventToShow.eventOptions[1].ActivateEffects);
                eventToShow.eventOptions[1].assignedButton.onClick.AddListener(OnEventComplete);
                break;
            case 3:
                eventOptionA.gameObject.SetActive(true);
                eventOptionAText.gameObject.SetActive(true);
                eventToShow.eventOptions[0].assignedButton = eventOptionA;
                eventToShow.eventOptions[0].assignedButton.onClick.RemoveAllListeners();
                eventToShow.eventOptions[0].assignedButton.onClick.AddListener(eventToShow.eventOptions[0].ActivateEffects);
                eventToShow.eventOptions[0].assignedButton.onClick.AddListener(OnEventComplete);
                eventOptionB.gameObject.SetActive(true);
                eventOptionBText.gameObject.SetActive(true);
                eventToShow.eventOptions[1].assignedButton = eventOptionB;
                eventToShow.eventOptions[1].assignedButton.onClick.RemoveAllListeners();
                eventToShow.eventOptions[1].assignedButton.onClick.AddListener(eventToShow.eventOptions[1].ActivateEffects);
                eventToShow.eventOptions[1].assignedButton.onClick.AddListener(OnEventComplete);
                eventOptionC.gameObject.SetActive(true);
                eventOptionCText.gameObject.SetActive(true);
                eventToShow.eventOptions[2].assignedButton = eventOptionC;
                eventToShow.eventOptions[2].assignedButton.onClick.RemoveAllListeners();
                eventToShow.eventOptions[2].assignedButton.onClick.AddListener(eventToShow.eventOptions[2].ActivateEffects);
                eventToShow.eventOptions[2].assignedButton.onClick.AddListener(OnEventComplete);
                break;
            case 4:
                eventOptionA.gameObject.SetActive(true);
                eventOptionAText.gameObject.SetActive(true);
                eventToShow.eventOptions[0].assignedButton = eventOptionA;
                eventToShow.eventOptions[0].assignedButton.onClick.RemoveAllListeners();
                eventToShow.eventOptions[0].assignedButton.onClick.AddListener(eventToShow.eventOptions[0].ActivateEffects);
                eventToShow.eventOptions[0].assignedButton.onClick.AddListener(OnEventComplete);
                eventOptionB.gameObject.SetActive(true);
                eventOptionBText.gameObject.SetActive(true);
                eventToShow.eventOptions[1].assignedButton = eventOptionB;
                eventToShow.eventOptions[1].assignedButton.onClick.RemoveAllListeners();
                eventToShow.eventOptions[1].assignedButton.onClick.AddListener(eventToShow.eventOptions[1].ActivateEffects);
                eventToShow.eventOptions[1].assignedButton.onClick.AddListener(OnEventComplete);
                eventOptionC.gameObject.SetActive(true);
                eventOptionCText.gameObject.SetActive(true);
                eventToShow.eventOptions[2].assignedButton = eventOptionC;
                eventToShow.eventOptions[2].assignedButton.onClick.RemoveAllListeners();
                eventToShow.eventOptions[2].assignedButton.onClick.AddListener(eventToShow.eventOptions[2].ActivateEffects);
                eventToShow.eventOptions[2].assignedButton.onClick.AddListener(OnEventComplete);
                eventOptionD.gameObject.SetActive(true);
                eventOptionDText.gameObject.SetActive(true);
                eventToShow.eventOptions[3].assignedButton = eventOptionD;
                eventToShow.eventOptions[3].assignedButton.onClick.RemoveAllListeners();
                eventToShow.eventOptions[3].assignedButton.onClick.AddListener(eventToShow.eventOptions[3].ActivateEffects);
                eventToShow.eventOptions[3].assignedButton.onClick.AddListener(OnEventComplete);
                break;
        }
    }

    public void ShowEvent(Event eventToShow, Action onComplete)
    {
        onEventCompleteAction = onComplete;
        HideAllEventUI();
        ShowEventBoxAndText();
        UpdateEventTextBox(eventToShow);
        ShowEventOptions(eventToShow);
        UpdateEventOptions(eventToShow);
    }

    public void OnEventComplete()
    {
        onEventCompleteAction?.Invoke();
    }
}
