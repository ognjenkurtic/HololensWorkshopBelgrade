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

        public QuadCubeAnimationBehaviour[] CubeAnimations;

        public GameObject AnchorGameObject;

        private IMovementService _movementService;

        private CubeController _cubeController;

        void Awake()
        {
            _movementService = Registration.Resolve<IMovementService>();
            _cubeController = new CubeController(NumberOfMoves, _movementService, CubeAnimations.Select(c => c.QuadCubeController).ToArray());
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            _cubeController.Click();
        }

        private void Update()
        {
            _cubeController.MyGameObjectPosition = gameObject.transform.position;
            _cubeController.AnchorGameObjectPosition = AnchorGameObject.transform.position;

            var position = _movementService.PerformMove();
            if (position.HasValue)
            {
                gameObject.transform.position = position.Value;
            }
        }
    }
}
