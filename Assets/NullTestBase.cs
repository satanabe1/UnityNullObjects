using UnityEngine;
using System.Collections;

public class NullTestBase : MonoBehaviour
{
    void Awake ()
    {
        var logger = GameObject.FindObjectOfType<LogExporter> ();
        if (logger != null) {
            logger.Setup (this.GetType (), false);
        }
    }
}
