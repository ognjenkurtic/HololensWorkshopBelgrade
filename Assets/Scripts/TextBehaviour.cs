using Assets.Controllers;
using UnityEngine;

namespace Assets.Scripts
{
    public class TextBehaviour : MonoBehaviour
    {
        public Animator AnimatorObject;
        public AudioSource AudioSource;
        public BoxCollider BoxCollider;

        public TextController TextController { get; protected set; }

        void Awake()
        {
            TextController = new TextController(AnimatorObject, AudioSource, BoxCollider);
        }

        //public void OnMouseOver()
        //{
        //    TextController.OnMouseOver();
        //}
    }
}
