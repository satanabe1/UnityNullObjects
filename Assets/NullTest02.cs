using UnityEngine;
using System.Collections;

/// <summary>
/// DestroyとDestroyImmediateとフレーム跨ぎ
/// </summary>
public class NullTest02 : NullTestBase
{
    IEnumerator Start ()
    {
        MonoBehaviour destroied = gameObject.AddComponent<MonoBehaviour> ();
        MonoBehaviour destroiedImmediate = gameObject.AddComponent<MonoBehaviour> ();
        MonoBehaviour nullBehaviour = null;
        Destroy (destroied);
        DestroyImmediate (destroiedImmediate);
        yield return null;
        Debug.Log ("destroied          : [" + destroied + "]");
        Debug.Log ("destroiedImmediate : [" + destroiedImmediate + "]");
        Debug.Log ("nullBehaviour      : [" + nullBehaviour + "]");
        yield break;
    }
}
