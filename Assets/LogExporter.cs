using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// 
/// </summary>
public class LogExporter : MonoBehaviour
{
    private class WriterSet : System.IDisposable
    {
        private FileStream logStream;
        private StreamWriter logWriter;

        public bool Init (string outputPath, bool isAppend)
        {
            try {
                FileMode fileMode = isAppend ? FileMode.OpenOrCreate | FileMode.Append : FileMode.Create;
                logStream = new FileStream (outputPath, fileMode, FileAccess.Write);
                logWriter = new StreamWriter (logStream);
                return true;
            } catch (System.Exception ex) {
                Debug.LogError (ex);
                return false;
            }
        }

        public void WriteLine (string log)
        {
            if (logWriter == null) {
                return;
            }
            logWriter.WriteLine (log);
            logWriter.Flush ();
        }

        public void Dispose ()
        {
            if (logWriter != null) {
                try {
                    logWriter.Dispose ();
                } catch (System.Exception ex) {
                    Debug.LogError (ex);
                }
                logWriter = null;
            }
            if (logStream != null) {
                try {
                    logStream.Dispose ();
                } catch (System.Exception ex) {
                    Debug.LogError (ex);
                }
                logStream = null;
            }
        }
    }

    private Dictionary<System.Type, WriterSet> writers = new Dictionary<System.Type, WriterSet> ();

    public void Setup (System.Type type, bool isAppend = false)
    {
        if (writers.ContainsKey (type)) {
            return;
        }
        var outputPath = Path.Combine (Application.dataPath, type.Name + ".txt");
        var writer = new WriterSet ();
        if (writer.Init (outputPath, isAppend)) {
            writers [type] = writer;
        } else {
            writer.Dispose ();
        }
    }

    void Awake ()
    {
        Application.RegisterLogCallback (Logging);
    }

    void OnDestroy ()
    {
        foreach (var writerSet in writers) {
            if (writerSet.Value != null) {
                writerSet.Value.Dispose ();
            }
        }
        writers.Clear ();
    }

    void OnApplicationQuit ()
    {
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }

    private void Logging (string condition, string stackTrace, LogType logType)
    {
        if (string.IsNullOrEmpty (stackTrace)) {
            return;
        }
        foreach (var writerSet in writers) {
            if (writerSet.Key != null && writerSet.Value != null) {
                if (stackTrace.Contains (writerSet.Key.Name)) {
                    writerSet.Value.WriteLine (condition);
                }
            }
        }
    }
}
