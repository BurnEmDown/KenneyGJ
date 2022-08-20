using System;
using UnityEngine;

[CreateAssetMenu]
public class EventOption : ScriptableObject
{
    public string optionName;
    public string optionText;
    public Action effects;
}