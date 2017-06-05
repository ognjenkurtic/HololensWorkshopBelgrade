using Assets.Controllers;
using Assets.Interfaces;
using UnityEngine;

namespace Assets.Scripts
{
    public class QuadCubeAnimationBehaviour : MonoBehaviour
    {
        public Vector3 MovementDirection;
        protected IMovementService MovementService;

        public QuadCubeController QuadCubeController { get; private set; }

        void Awake()
        {
            MovementService = Registration.Resolve<IMovementService>();
            QuadCubeController = new QuadCubeController(MovementService, MovementDirection);
        }

        public virtual void StartMovement()
        {
            QuadCubeController.StartMovement();
        }
	
        // Update is called once per frame
        void Update ()
        {
            QuadCubeController.MyGameObjectPosition = gameObject.transform.position;
            QuadCubeController.MovementSpeed = Time.deltaTime;
            Animate();
        }

        public virtual void Animate()
        {
            var position = MovementService.PerformMove();
            if (position.HasValue)
            {
                gameObject.transform.position = position.Value;
            }
        }
    }
}
