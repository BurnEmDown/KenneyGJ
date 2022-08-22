using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class EventOptionButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public EventOption eventOption;

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (EventEffect effect in eventOption.effects)
        {
            Color color;

            if (effect.isPercentage && effect.floatAmount < 1)
            {
                color = Color.red;
            }
            else if (effect.intAmount < 0)
            {
                color = Color.red;
            }
            else
            {
                color = Color.green;
            }
            
            StatsView.Instance.UpdateStatTemp(color,effect.statAffected,effect.intAmount,effect.floatAmount, effect.isPercentage);
        }


        
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        StatsController.Instance.UpdateAllViews();
    }


}