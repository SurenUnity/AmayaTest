using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enums;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.U2D;
using Object = UnityEngine.Object;

namespace Controllers
{
    public class ResourceManager : BaseController
    {
        private readonly Dictionary<GroupTypes, IList<Object>> groups = new Dictionary<GroupTypes, IList<Object>>();

        public Action ResourcesLoaded { get; set; }

        public T InstantiatePrefabByName<T>(string name, Transform parent = null, GroupTypes groupTypes = GroupTypes.Core)
        {
            var gameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>(name), parent);
            var neededComponent = gameObject.GetComponent<T>();

            if (neededComponent == null)
            {
                string txt = $"нет такого компонента/объекта  {name} {typeof(T)}";
                Debug.LogWarning(txt);
                throw new NullReferenceException(txt);
            }
            return neededComponent;
        }

        public T InstantiateScriptableObjectByName<T>(string name, GroupTypes groupTypes = GroupTypes.ScriptableObject) where T : ScriptableObject
        {
            var gameObject = Object.Instantiate(Resources.Load<T>(name));

            if (gameObject == null)
            {
                string txt = $"нет такого компонента/объекта  {name} {typeof(T)}";
                Debug.LogWarning(txt);
                throw new NullReferenceException(txt);
            }
            return gameObject;
        }

        public async void LoadGroups()
        {
            string[] groupNames = Enum.GetNames(typeof(GroupTypes));

            for (int i = 0; i < groupNames.Length; i++)
            {
                var asyncOperationHandle = Addressables.LoadAssetsAsync<Object>(groupNames[i], null);
                while (asyncOperationHandle.Status != AsyncOperationStatus.Succeeded)
                {
                    await Task.Yield();
                }
                var enumValue = (GroupTypes) Enum.Parse(typeof(GroupTypes), groupNames[i]);
                groups.Add(enumValue, asyncOperationHandle.Result);
            }
            ResourcesLoaded?.Invoke();
        }
    }
}
