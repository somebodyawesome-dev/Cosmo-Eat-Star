using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    static T _instance = null;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                T[] result= Resources.LoadAll<T>("");
                if(result.Length == 0)
                {
                    Debug.LogError(_instance.GetType()+" NOT FOUND");
                    return null;
                }
                if (result.Length > 1)
                {
                    Debug.LogError(_instance.GetType()+" FOUND MORE THAN ONE");
                    return null;
                }
                _instance = result[0];
                _instance.hideFlags = HideFlags.DontUnloadUnusedAsset;
                

            }
                
            _instance.hideFlags = HideFlags.DontUnloadUnusedAsset;
            
            return _instance;
        }
    }
}