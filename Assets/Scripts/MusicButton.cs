using System;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    [SerializeField] public Button button;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
