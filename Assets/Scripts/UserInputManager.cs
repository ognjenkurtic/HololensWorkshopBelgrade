using UnityEngine;
using UnityEngine.UI;

public class UserInputManager : MonoBehaviour
{
    public Text AboutText;
    public Text LocationsText;
    public Text TechnologiesText;
        
    public void About()
    {
        LocationsText.enabled = false;
        TechnologiesText.enabled = false;
        AboutText.enabled = true;
    }

    public void Locations()
    {
        TechnologiesText.enabled = false;
        AboutText.enabled = false;
        LocationsText.enabled = true;
    }

    public void Technologies()
    {
        AboutText.enabled = false;
        LocationsText.enabled = false;
        TechnologiesText.enabled = true;
    }
}
