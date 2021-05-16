using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;

    public float RuntimeValue;

    public void OnBeforeSerialize() {
        RuntimeValue = initialValue;
    }

    public void OnAfterDeserialize() { }
}
*/

[CreateAssetMenu]
[System.Serializable]
public class FloatValue : ScriptableObject
{
    public float initialValue;

    public float RuntimeValue;
}