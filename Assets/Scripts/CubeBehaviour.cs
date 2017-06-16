using System.Linq;
using Assets.Controllers;
using Assets.Interfaces;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace Assets.Scripts
{
    public class CubeBehaviour : MonoBehaviour, ICubeClickHandler
    {
        private const int NumberOfMoves = 100;

        private IMovementService _movementService;
        private CubeController _cubeController;

        public QuadCubeAnimationBehaviour[] CubeAnimations;
        public GameObject AnchorGameObject;
        public AudioSource AudioSource;
        public GameObject SmokePrefab;
        public Canvas Canvas;

        void Start()
        {
            _movementService = Registration.Resolve<IMovementService>();
            var soundService = Registration.Resolve<ISoundService>();
            var smokeService = Registration.Resolve<ISmokeService>();

            _cubeController = new CubeController(NumberOfMoves, _movementService, soundService, smokeService);
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            _cubeController.Click();
        }

        private void Update()
        {
            SetControllerProperties();

            var position = _movementService.PerformMove();
            if (position.HasValue)
            {
                gameObject.transform.position = position.Value;
            }
        }

        private void SetControllerProperties()
        {
            _cubeController.MyGameObjectPosition = gameObject.transform.position;
            if (AnchorGameObject != null)
            {
                _cubeController.AnchorGameObjectPosition = AnchorGameObject.transform.position;
            }

            _cubeController.AudioSource = AudioSource;
            _cubeController.SmokePrefab = SmokePrefab;

            _cubeController.QuadCubeControllers = CubeAnimations.Select(a => a.QuadCubeController).ToArray();
            _cubeController.Canvas = Canvas;
        }
    }
}
