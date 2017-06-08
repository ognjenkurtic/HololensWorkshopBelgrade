using Assets.Interfaces;
using Assets.Services;
using UnityEngine;

namespace Assets.Controllers
{
    public class QuadCubeController
    {
        private readonly Vector3 _movementDirection;
        protected readonly IMovementService MovementService;

        public Vector3 MyGameObjectPosition { set; private get; }

        public float MovementSpeed { set; private get; }


        public QuadCubeController(IMovementService movementService, Vector3 movementDirection)
        {
            MovementService = movementService;
            _movementDirection = movementDirection;
        }

        public virtual void StartMovement()
        {
            if (MovementService != null)
            {
                MovementService.InitializeMovementInGivenDirection(MyGameObjectPosition, _movementDirection, MovementSpeed);
            }
        }
    }
}