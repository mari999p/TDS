using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace TDS.Infrastructure.Locator
{
    public class ServicesLocator : MonoBehaviour
    {
        #region Variables

        private static ServicesLocator _instance;
        private readonly Dictionary<Type, IService> _services = new();

        #endregion

        #region Properties

        public static ServicesLocator Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new(nameof(ServicesLocator));
                    DontDestroyOnLoad(go);
                    _instance = go.AddComponent<ServicesLocator>();
                }

                return _instance;
            }
        }

        #endregion

        #region Public methods

        public T Get<T>() where T : class, IService
        {
            Assert.IsTrue(_services.ContainsKey(typeof(T)), $"Service {typeof(T).Name} not registered");
            return _services[typeof(T)] as T;
        }

        public void Register<T>(T service) where T : class, IService
        {
            Assert.IsFalse(_services.ContainsKey(typeof(T)),
                $"Can't register service  {typeof(T).Name} because it is  registered");

            _services.Add(typeof(T), service);
        }

        public T RegisterMono<T>() where T : IService
        {
            return default;
        }

        public void UnRegister<T>() where T : IService
        {
            _services.Remove(typeof(T));
        }

        #endregion
    }
}