using UnityEngine;
using System.Collections;

/// <summary>
/// 削除済みobjectとキャスト
/// </summary>
public class NullTest06 : NullTestBase
{
    IEnumerator Start ()
    {
        MonoBehaviour destroied = gameObject.AddComponent<MonoBehaviour> ();
        MonoBehaviour destroiedImmediate = gameObject.AddComponent<MonoBehaviour> ();
        MonoBehaviour nullBehaviour = null;
        Destroy (destroied);
        DestroyImmediate (destroiedImmediate);
        yield return null;
        Debug.Log ("EqualsNull");
        Debug.Log ("destroied                 : [" + (destroied == null) + "]");
        Debug.Log ("destroiedImmediate        : [" + (destroiedImmediate == null) + "]");
        Debug.Log ("nullBehaviour             : [" + (nullBehaviour == null) + "]");
        Debug.Log ("(cast) destroied          : [" + (((System.Object)destroied) == null) + "]");
        Debug.Log ("(cast) destroiedImmediate : [" + (((System.Object)destroiedImmediate) == null) + "]");
        Debug.Log ("(cast) nullBehaviour      : [" + (((System.Object)nullBehaviour) == null) + "]");
        yield break;
    }
}
