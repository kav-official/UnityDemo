#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class AutoSave
{
    static double lastSaveTime = 0;
    static double saveInterval = 10;

    static AutoSave()
    {
        EditorApplication.update += Update;
    }

    static void Update()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode || EditorApplication.isCompiling)
            return;

        double time = EditorApplication.timeSinceStartup;
        if (time - lastSaveTime > saveInterval)
        {
            lastSaveTime = time;
            Debug.Log("Auto-saving scene...");
            EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();
        }
    }
}
#endif
