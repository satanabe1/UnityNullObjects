using UnityEngine;
using System.Collections;

/// <summary>
/// 削除済みobjectへのメソッド呼び出し
/// </summary>
public class NullTest04 : NullTestBase
{
    IEnumerator Start ()
    {
        MonoBehaviour destroied = gameObject.AddComponent<MonoBehaviour> ();
        MonoBehaviour destroiedImmediate = gameObject.AddComponent<MonoBehaviour> ();
        MonoBehaviour nullBehaviour = null;
        Destroy (destroied);
        DestroyImmediate (destroiedImmediate);
        yield return null;
        Debug.Log ("=====  GetType  =====");
        try {
            Debug.Log ("---");
            Debug.Log ("destroied          : [" + destroied.GetType () + "]");
        } catch (System.Exception ex) {
            Debug.LogError (ex);
        }
        try {
            Debug.Log ("---");
            Debug.Log ("destroiedImmediate : [" + destroiedImmediate.GetType () + "]");
        } catch (System.Exception ex) {
            Debug.LogError (ex);
        }
        try {
            Debug.Log ("---");
            Debug.Log ("nullBehaviour      : [" + nullBehaviour.GetType () + "]");
        } catch (System.Exception ex) {
            Debug.LogError (ex);
        }
        Debug.Log ("=====  GetComponentInParent  =====");
        try {
            Debug.Log ("---");
            Debug.Log ("destroied          : [" + destroied.GetComponentInParent<Component> () + "]");
        } catch (System.Exception  nex) {
            Debug.LogError (nex);
        }
        try {
            Debug.Log ("---");
            Debug.Log ("destroiedImmediate : [" + destroiedImmediate.GetComponentInParent<Component> () + "]");
        } catch (System.Exception ex) {
            Debug.LogError (ex);
        }
        try {
            Debug.Log ("---");
            Debug.Log ("nullBehaviour      : [" + nullBehaviour.GetComponentInParent<Component> () + "]");
        } catch (System.Exception ex) {
            Debug.LogError (ex);
        }
        yield break;
    }
}
