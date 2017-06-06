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
            MovementService.InitializeMovementInGivenDirection(MyGameObjectPosition, _movementDirection, MovementSpeed);
        }
    }

    public class QuadCubeScaleController : QuadCubeController
    {
        public Vector3 CurrentScale { set; private get; }

        public QuadCubeScaleController(IMovementService movementService, Vector3 movementDirection) : base(movementService, movementDirection)
        {
        }

        public override void StartMovement()
        {
            base.StartMovement();
            MovementService.InitializeScaleChange(CurrentScale);
        }
    }
}