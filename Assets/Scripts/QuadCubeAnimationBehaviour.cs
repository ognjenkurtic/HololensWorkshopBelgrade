using Assets.Controllers;
using Assets.Interfaces;
using UnityEngine;

namespace Assets.Scripts
{
    public class QuadCubeAnimationBehaviour : MonoBehaviour
    {
        public Vector3 MovementDirection;
        protected IMovementService MovementService;

        public QuadCubeController QuadCubeController { get; protected set; }

        void Start()
        {
            MovementService = Registration.Resolve<IMovementService>();
            CreateController();
        }

        protected virtual void CreateController()
        {
            QuadCubeController = new QuadCubeController(MovementService, MovementDirection);
        }

        // Update is called once per frame
        protected void Update ()
        {
            SetControllerProperties();
            Animate();
        }

        protected virtual void SetControllerProperties()
        {
            QuadCubeController.MyGameObjectPosition = gameObject.transform.position;
            QuadCubeController.MovementSpeed = Time.deltaTime;
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
