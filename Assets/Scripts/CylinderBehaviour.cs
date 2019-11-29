using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class CylinderBehaviour : MonoBehaviour, IInputClickHandler {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnInputClicked(InputClickedEventData eventData)
    {

    }

    public void Click()
    {
        this.gameObject.transform.position = new Vector3(3, 4, 4);
    }
}
