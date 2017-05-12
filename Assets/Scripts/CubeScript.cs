using System;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;

public class CubeScript : MonoBehaviour, IInputClickHandler
{
    public GameObject CubePrefab;
   
    public void OnInputClicked(InputClickedEventData eventData)
    {
        var position = gameObject.transform.position;
        var rotation = gameObject.transform.rotation;
        var scale = gameObject.transform.lossyScale;

        var prefab = Instantiate(CubePrefab);
        prefab.transform.position = position;
        prefab.transform.rotation = rotation;
        prefab.transform.localScale = scale;
    }
}
