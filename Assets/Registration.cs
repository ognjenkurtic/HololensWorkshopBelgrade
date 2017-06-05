﻿using System;
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
        private static readonly IDictionary<string, object> RegisteredObjects = new Dictionary<string, object>();

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

            if (RegisteredObjects.ContainsKey(destinationTypeName))
            {
                return (T) RegisteredObjects[destinationTypeName];
            }

            if (RegisteredTypes.ContainsKey(destinationTypeName))
            {
                var sourceTypeName = RegisteredTypes[destinationTypeName];

                // ReSharper disable once AssignNullToNotNullAttribute
                var instance = Activator.CreateInstance(Type.GetType(sourceTypeName));

                // ReSharper disable once AssignNullToNotNullAttribute
                return (T) instance;
            }

            throw new Exception(string.Format("Type not registered: {0}", destinationTypeName));
        }

        public void RegisterType<TDestination, TSource>() where TSource : TDestination, new()
        {
            var destinationTypeName = typeof(TDestination).FullName;
            var sourceTypeName = typeof(TSource).FullName;
            if (RegisteredTypes.ContainsKey(destinationTypeName))
            {
                RegisteredTypes[destinationTypeName] = typeof(TDestination).FullName;
            }
            else
            {
                RegisteredTypes.Add(destinationTypeName, sourceTypeName);
            }
        }

        public void RegisterObjectOfType<TDestination>(object source)
        {
            var destinationTypeName = typeof(TDestination).FullName;

            if (!(source is TDestination))
            {
                throw new Exception(string.Format("Given object is not assignable to {0}.", destinationTypeName));
            }

            if (RegisteredObjects.ContainsKey(destinationTypeName))
            {
                RegisteredObjects[destinationTypeName] = source;
            }
            else
            {
                RegisteredObjects.Add(destinationTypeName, source);
            }
        }
    }
}