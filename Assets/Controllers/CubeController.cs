using Assets.Interfaces;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Controllers
{
    public class CubeController
    {
        private readonly int _numberOfMoves;
        private readonly IMovementService _movementService;
        private readonly QuadCubeController[] _quadCubeControllers;

        private int _numberOfClicks;

        public Vector3 MyGameObjectPosition { private get; set; }

        public Vector3 AnchorGameObjectPosition { private get; set; }

        public CubeController(int numberOfMoves, IMovementService movementService, QuadCubeController[] quadCubeControllers)
        {
            _numberOfMoves = numberOfMoves;
            _movementService = movementService;
            _quadCubeControllers = quadCubeControllers;
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
            for (var i = 0; i < _quadCubeControllers.Length; i++)
            {
                _quadCubeControllers[i].StartMovement();

            }
        }
    }
}