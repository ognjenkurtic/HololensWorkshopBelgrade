using Assets.Interfaces;
using Assets.Services;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace Assets.Scripts
{
    public class CubeClickBehaviour : MonoBehaviour, IInputClickHandler
    {
        private const int NumberOfMoves = 100;

        private int _numberOfClicks;

        public QuadCubeAnimationBehaviour[] CubeAnimations;

        public GameObject AnchorGameObject;

        private IMovementService _movementService;

        void Awake()
        {
            _movementService = Registration.Resolve<IMovementService>();
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            _numberOfClicks++;

            switch (_numberOfClicks)
            {
                case 1:
                    _movementService.InitializeMovementTowardsPosition(gameObject.transform.position, NumberOfMoves, AnchorGameObject.transform.position);
                    return;
                case 2:
                    AnimateExplosion();
                    return;
                default:
                    print("def");
                    return;
            }
        }

        private void AnimateExplosion()
        {
            for (var i = 0; i < CubeAnimations.Length; i++)
            {
                CubeAnimations[i].StartMovement();
            }
        }

        private void Update()
        {
            gameObject.transform.position = _movementService.PerformMove();
        }
    }
}
