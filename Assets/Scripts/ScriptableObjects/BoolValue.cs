using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
[CreateAssetMenu]
public class BoolValue : ScriptableObject, ISerializationCallbackReceiver
{
    [Header("In Game Value")]
    public bool initialValue;

    //[HideInInspector]
    public bool runTimeValue;

    public void OnAfterDeserialize() { initialValue = runTimeValue; }

    public void OnBeforeSerialize() { }
}
*/


[CreateAssetMenu]
[System.Serializable]
public class BoolValue : ScriptableObject
{
    [Header("In Game Value")]
    public bool initialValue;

    public bool runTimeValue;
}