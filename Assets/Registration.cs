using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Assets.Interfaces;
using Assets.Services;
using HoloToolkit;
using UnityEngine;

namespace Assets
{
    public class Registration : MonoBehaviour
    {
        private static readonly IDictionary<string, string> RegisteredTypes = new Dictionary<string, string>();

        private void Awake()
        {
            RegisterTypes();
        }

        public void RegisterTypes()
        {
            RegisterType<IMovementService, MovementService>();
        }

        public static T Resolve<T>()
        {
            var destinationTypeName = typeof(T).FullName;
            if (!RegisteredTypes.ContainsKey(destinationTypeName))
            {
                throw new Exception(string.Format("Type not registered: {0}", destinationTypeName));
            }

            var sourceTypeName = RegisteredTypes[destinationTypeName];

            var instance = Activator.CreateInstance(Assembly.GetExecutingAssembly().FullName, sourceTypeName).Unwrap();
            // ReSharper disable once AssignNullToNotNullAttribute
            return (T) instance;
        }

        public void RegisterType<TDestination, TSource>() where TSource : TDestination, new()
        {
            var destinationTypeName = typeof(TDestination).FullName;
            var sourceTypeName = typeof(TSource).FullName;
            if (RegisteredTypes.ContainsKey(destinationTypeName))
            {
                RegisteredTypes[typeof(TDestination).FullName] = typeof(TDestination).FullName;
            }
            else
            {
                RegisteredTypes.Add(destinationTypeName, sourceTypeName);
            }
        }
    }
}
