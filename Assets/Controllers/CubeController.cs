using Assets.Interfaces;
using UnityEngine;

namespace Assets.Controllers
{
    public class CubeController
    {
        private readonly int _numberOfMoves;
        private readonly IMovementService _movementService;
        private readonly ISoundService _soundService;
        private readonly ISmokeService _smokeService;
        private int _numberOfClicks;

        public Vector3 MyGameObjectPosition { private get; set; }

        public Vector3 AnchorGameObjectPosition { private get; set; }

        public QuadCubeController[] QuadCubeControllers { private get; set; }

        public TextController[] TextControllers { private get; set; }

        public AudioSource AudioSource
        {
            set
            {
                _soundService.SetAudioSource(value);
            }
        }

        public GameObject SmokePrefab
        {
            set
            {
                _smokeService.SetSmokeObject(value);
            }
        }

        public CubeController(int numberOfMoves, IMovementService movementService, ISoundService soundService, ISmokeService smokeService)
        {
            _numberOfMoves = numberOfMoves;
            _movementService = movementService;
            _soundService = soundService;
            _smokeService = smokeService;
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
            if (_movementService != null)
            {
                _movementService.InitializeMovementTowardsPosition(MyGameObjectPosition, _numberOfMoves, AnchorGameObjectPosition);
            }
        }

        private void AnimateExplosion()
        {
            if (_soundService != null)
            {
                _soundService.PlaySound();
            }

            if (_smokeService != null)
            {
                _smokeService.PlaySmoke(MyGameObjectPosition);
            }

            if (QuadCubeControllers != null)
            {
                for (var i = 0; i < QuadCubeControllers.Length; i++)
                {
                    QuadCubeControllers[i].StartMovement();
                }
            }

            if (TextControllers != null)
            {
                for (var i = 0; i < TextControllers.Length; i++)
                {
                    TextControllers[i].StartAnimation();
                    TextControllers[i].ResizeColider();
                }
            }
        }
    }
}