using Assets.Controllers;
using UnityEngine;

namespace Assets.Scripts
{
    public class TextBehaviour : MonoBehaviour
    {
        public Animator AnimatorObject;

        public TextController TextController { get; protected set; }

        void Awake()
        {
            TextController = new TextController(AnimatorObject);
        }
    }
}
