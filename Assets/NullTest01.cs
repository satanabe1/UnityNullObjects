using UnityEngine;
using System.Collections;

/// <summary>
/// DestroyとDestroyImmediate
/// </summary>
public class NullTest01 : NullTestBase
{
    IEnumerator Start ()
    {
        MonoBehaviour destroied = gameObject.AddComponent<MonoBehaviour> ();
        MonoBehaviour destroiedImmediate = gameObject.AddComponent<MonoBehaviour> ();
        MonoBehaviour nullBehaviour = null;
        Destroy (destroied);
        DestroyImmediate (destroiedImmediate);
        Debug.Log ("destroied          : [" + destroied + "]");
        Debug.Log ("destroiedImmediate : [" + destroiedImmediate + "]");
        Debug.Log ("nullBehaviour      : [" + nullBehaviour + "]");
        yield break;
    }
}
