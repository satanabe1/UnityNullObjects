using UnityEngine;
using System.Collections;

/// <summary>
/// 削除済みobjectと is 演算
/// </summary>
public class NullTest05 : NullTestBase
{
    IEnumerator Start ()
    {
        MonoBehaviour destroied = gameObject.AddComponent<MonoBehaviour> ();
        MonoBehaviour destroiedImmediate = gameObject.AddComponent<MonoBehaviour> ();
        MonoBehaviour nullBehaviour = null;
        Destroy (destroied);
        DestroyImmediate (destroiedImmediate);
        yield return null;
        Debug.Log("is a UnityObject");
        Debug.Log ("destroied          : [" + (destroied is UnityEngine.Object) + "]");
        Debug.Log ("destroiedImmediate : [" + (destroiedImmediate is UnityEngine.Object) + "]");
        Debug.Log ("nullBehaviour      : [" + (nullBehaviour is UnityEngine.Object) + "]");
        yield break;
    }
}
