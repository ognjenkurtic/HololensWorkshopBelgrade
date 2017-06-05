using Assets.Interfaces;
using Assets.Services;
using UnityEngine;

namespace Assets.Controllers
{
    public class QuadCubeController
    {
        private readonly Vector3 _movementDirection;
        private readonly IMovementService _movementService;

        public Vector3 MyGameObjectPosition { set; private get; }

        public float MovementSpeed { set; private get; }


        public QuadCubeController(IMovementService movementService, Vector3 movementDirection)
        {
            _movementService = movementService;
            _movementDirection = movementDirection;
        }

        public void StartMovement()
        {
            _movementService.InitializeMovementInGivenDirection(MyGameObjectPosition, _movementDirection, MovementSpeed);
        }
    }
}