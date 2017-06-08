using System;
using Assets.Controllers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Services
{
    public class SmokeService : ISmokeService
    {
        private GameObject _smoke;

        public void SetSmokeObject(GameObject smoke)
        {
            _smoke = smoke;
        }

        public void PlaySmoke(Vector3 position)
        {
            if (_smoke == null)
            {
                throw new Exception("Smoke sample not set.");    
            }

            Object.Instantiate(_smoke, position, Quaternion.identity);
        }
    }
}
