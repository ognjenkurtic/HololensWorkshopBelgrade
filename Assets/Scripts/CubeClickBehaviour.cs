using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace Assets.Scripts
{
    public class CubeClickBehaviour : MonoBehaviour, IInputClickHandler
    {
        private const int NumberOfMoves = 100;

        private int _numberOfClicks;
        private int _movesLeft;
        private Vector3 _movementDirection;

        public QuadCubeAnimationBehaviour[] CubeAnimations;

        public GameObject AnchorGameObject;


        public void OnInputClicked(InputClickedEventData eventData)
        {
            _numberOfClicks++;

            switch (_numberOfClicks)
            {
                case 1:
                    var currentPosition = transform.position;
                    var goalPosition = AnchorGameObject.transform.position;
                    var dx = (goalPosition.x - currentPosition.x) / NumberOfMoves;
                    var dy = (goalPosition.y - currentPosition.y) / NumberOfMoves;
                    var dz = (goalPosition.z - currentPosition.z) / NumberOfMoves;
                    _movementDirection = new Vector3(dx, dy, dz);
                    _movesLeft = NumberOfMoves;
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
                CubeAnimations[i].AnimTrigger = true;
            }
        }

        private void Update()
        {
            if (!AnimateCube)
            {
                return;
            }
            
            var position = gameObject.transform.position;
            position += _movementDirection;
            gameObject.transform.position = position;
            _movesLeft--;
        }

        private bool AnimateCube
        {
            get { return _numberOfClicks == 1 && _movesLeft > 0; }
        }
    }
}
