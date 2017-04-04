using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class TestScriptAlbo : MonoBehaviour, IInputClickHandler
{
    public Animator AnimatorObject;
    public GameObject SomeGameObject;
    private bool _isActive = true;

    // Use this for initialization
    void Start () {

    }
	
    // Update is called once per frame
    void Update () {
		
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        print("clicked");

        _isActive = !_isActive;

        AnimatorObject.enabled = _isActive;
    }
}
