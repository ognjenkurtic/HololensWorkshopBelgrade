using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.VR.WSA;

namespace Assets.Scripts
{
    public class SphereDragScript : MonoBehaviour, IInputHandler
    {
        private bool _anchorCreated;
        private bool _anchorLoaded;

        void Start()
        {
            if (!_anchorLoaded)
            {
                var anchor = gameObject.GetComponent<WorldAnchor>();
                if (anchor != null)
                {
                    InitializeObjectFromAnchor(anchor);
                }

                if (WorldAnchorManager.Instance != null && WorldAnchorManager.Instance.AnchorStore != null)
                {
                    var anchor2 = WorldAnchorManager.Instance.AnchorStore.Load("Sphere", gameObject);
                    if (anchor2 != null)
                    {
                        InitializeObjectFromAnchor(anchor2);
                    }
                }
            }
        }

        private void InitializeObjectFromAnchor(WorldAnchor anchor)
        {
            gameObject.transform.position = anchor.transform.position;
            gameObject.GetComponent<HandDraggable>().IsDraggingEnabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            _anchorLoaded = true;
        }

        void Update()
        {
            if (_anchorLoaded)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }

            if (!_anchorLoaded && WorldAnchorManager.Instance.AnchorStore != null)
            {
                var anchor = gameObject.GetComponent<WorldAnchor>();
                if (anchor != null)
                {
                    _anchorLoaded = true;
                }

                var anchor2 = WorldAnchorManager.Instance.AnchorStore.Load("Sphere", gameObject);
                if (anchor2 != null)
                {
                    _anchorLoaded = true;
                }
            }
        }

        public void OnInputDown(InputEventData eventData)
        {
        }

        public void OnInputUp(InputEventData eventData)
        {
            if (!_anchorCreated && !_anchorLoaded)
            {
                _anchorCreated = true;
                WorldAnchorManager.Instance.AttachAnchor(gameObject, "Sphere");
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }

        public void ResetSphere()
        {
            if (WorldAnchorManager.Instance.AnchorStore != null)
            {
                WorldAnchorManager.Instance.RemoveAnchor(gameObject);
            }

            _anchorLoaded = false;
            _anchorCreated = false;
        }
    }
}
