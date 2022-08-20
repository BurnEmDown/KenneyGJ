using UnityEngine;

public class EventsController : MonoBehaviour
{
    public EventsController Instance;
    
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
