using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class UserInputManager : MonoBehaviour
    {
        public Text AboutText;
        public Text LocationsText;
        public Text TechnologiesText;
        public Text ProjectsText;
        public Text PositionsText;
        
        public void About()
        {
            LocationsText.enabled = false;
            TechnologiesText.enabled = false;
            ProjectsText.enabled = false;
            PositionsText.enabled = false;
            AboutText.enabled = true;
        }

        public void Locations()
        {
            LocationsText.enabled = true;
            TechnologiesText.enabled = false;
            ProjectsText.enabled = false;
            PositionsText.enabled = false;
            AboutText.enabled = false;
        }

        public void Technologies()
        {
            LocationsText.enabled = false;
            TechnologiesText.enabled = true;
            ProjectsText.enabled = false;
            PositionsText.enabled = false;
            AboutText.enabled = false;
        }

        public void Positions()
        {
            LocationsText.enabled = false;
            TechnologiesText.enabled = false;
            ProjectsText.enabled = false;
            PositionsText.enabled = true;
            AboutText.enabled = false;
        }

        public void Projects()
        {
            LocationsText.enabled = false;
            TechnologiesText.enabled = false;
            ProjectsText.enabled = true;
            PositionsText.enabled = false;
            AboutText.enabled = false;
        }

        public void ResetScene()
        {
            Registration.RegisterTypes();
            FindObjectOfType<SphereDragScript>().ResetSphere();

            var activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.name);
        }
        public void RestartScene()
        {
            Registration.RegisterTypes();

            var activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.name);
        }
    }
}
