using System;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class CubeClickBehaviour : MonoBehaviour, IInputClickHandler
{
        
    public QuadCubeAnimationBehaviour[] CubeAnimations;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        print("test");
        for (var i = 0; i < CubeAnimations.Length; i++)
        {
            CubeAnimations[i].AnimTrigger = true;
        }
    }

    private void Update()
    {

    }

}
