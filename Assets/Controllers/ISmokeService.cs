using UnityEngine;

namespace Assets.Controllers
{
    public interface ISmokeService
    {
        void SetSmokeObject(GameObject smoke);

        void PlaySmoke(Vector3 position);
    }
}