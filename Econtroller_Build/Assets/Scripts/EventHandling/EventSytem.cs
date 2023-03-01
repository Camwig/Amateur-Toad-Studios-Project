using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvent")]

public class EventSytem : ScriptableObject
{

    public List<EventListener> Listeners = new List<EventListener>();

    public void Raise(Component sender, object data)
    {
        for (int i=0; i < Listeners.Count;i++)
        {
            if (Listeners[i] != null)
            {
                Listeners[i].OnEventRaised(sender,data);
            }
        }
    }

    public void RegisterListener(EventListener listener)
    {
        if (!Listeners.Contains(listener))
            Listeners.Add(listener);
    } 
    
    public void UnRegisterListener(EventListener listener)
    {
        if (Listeners.Contains(listener))
            Listeners.Remove(listener);
    }
}
