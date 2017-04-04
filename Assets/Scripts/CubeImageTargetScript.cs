using System;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class CubeImageTargetScript : MonoBehaviour, IInputClickHandler
{
    public void OnInputClicked(InputClickedEventData eventData)
    {
        gameObject.AddComponent<Rigidbody>();
    }
}
