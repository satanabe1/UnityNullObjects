using UnityEngine;
using System.Collections;

/// <summary>
/// 削除済みobjectとnull
/// </summary>
public class NullTest03 : NullTestBase
{
    IEnumerator Start ()
    {
        MonoBehaviour destroied = gameObject.AddComponent<MonoBehaviour> ();
        MonoBehaviour destroiedImmediate = gameObject.AddComponent<MonoBehaviour> ();
        MonoBehaviour nullBehaviour = null;
        Destroy (destroied);
        DestroyImmediate (destroiedImmediate);
        Debug.Log ("EqualsNull");
        Debug.Log ("destroied          : [" + (destroied == null) + "]");
        Debug.Log ("destroiedImmediate : [" + (destroiedImmediate == null) + "]");
        Debug.Log ("nullBehaviour      : [" + (nullBehaviour == null) + "]");
        yield return null;
        Debug.Log ("destroied          : [" + (destroied == null) + "]");
        Debug.Log ("destroiedImmediate : [" + (destroiedImmediate == null) + "]");
        Debug.Log ("nullBehaviour      : [" + (nullBehaviour == null) + "]");
        yield break;
    }
}
