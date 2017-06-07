using Assets.Interfaces;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Controllers
{
    public class CubeController
    {
        private readonly int _numberOfMoves;
        private readonly IMovementService _movementService;
        private int _numberOfClicks;

        public Vector3 MyGameObjectPosition { private get; set; }

        public Vector3 AnchorGameObjectPosition { private get; set; }

        public QuadCubeController[] QuadCubeControllers { private get; set; }

        public TextController[] TextControllers { private get; set; }

        public AudioSource AudioSource { private get; set; }

        public CubeController(int numberOfMoves, IMovementService movementService)
        {
            _numberOfMoves = numberOfMoves;
            _movementService = movementService;
        }

        public void Click()
        {
            _numberOfClicks++;

            switch (_numberOfClicks)
            {
                case 1:
                    InitializeMovement();
                    return;
                case 2:
                    AnimateExplosion();
                    return;
                default:
                    return;
            }
        }

        private void InitializeMovement()
        {
            _movementService.InitializeMovementTowardsPosition(MyGameObjectPosition, _numberOfMoves, AnchorGameObjectPosition);
        }

        private void AnimateExplosion()
        {
            AudioSource.Play();

            for (var i = 0; i < QuadCubeControllers.Length; i++)
            {
                QuadCubeControllers[i].StartMovement();
            }

            for (var i = 0; i < TextControllers.Length; i++)
            {
                TextControllers[i].StartAnimation();
                TextControllers[i].ResizeColider();
            }
        }
    }
}