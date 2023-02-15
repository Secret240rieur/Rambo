using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : ScriptableObject
{
    public string sceneName;
#if UNITY_EDITOR    
    UnityEditor.SceneAsset sceneAsset;    
    public UnityEditor.SceneAsset Scene   
    {        get => sceneAsset;       
        set       
        {           
            sceneAsset = value; 
            sceneName = sceneAsset.name;  
        }  
    }
    #endif
}
