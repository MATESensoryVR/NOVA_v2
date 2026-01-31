using UnityEditor;
using UnityEngine;

public class RemoveMissingScripts
{
    [MenuItem("Tools/Cleanup/Remove Missing Scripts In Scene")]
    private static void RemoveInScene()
    {
        var gos = Object.FindObjectsOfType<GameObject>(true);
        int removed = 0;
        foreach (var go in gos)
            removed += GameObjectUtility.RemoveMonoBehavioursWithMissingScript(go);

        Debug.Log($"[Cleanup] Removed missing scripts in scene objects. Total removed: {removed}");
    }

    [MenuItem("Tools/Cleanup/Remove Missing Scripts In All Prefabs")]
    private static void RemoveInAllPrefabs()
    {
        string[] prefabGuids = AssetDatabase.FindAssets("t:Prefab");
        int removedTotal = 0;
        int prefabsTouched = 0;

        foreach (var guid in prefabGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            var root = PrefabUtility.LoadPrefabContents(path);
            int removed = 0;

            foreach (var t in root.GetComponentsInChildren<Transform>(true))
                removed += GameObjectUtility.RemoveMonoBehavioursWithMissingScript(t.gameObject);

            if (removed > 0)
            {
                prefabsTouched++;
                removedTotal += removed;
                PrefabUtility.SaveAsPrefabAsset(root, path);
                Debug.Log($"[Cleanup] {path}: removed {removed}");
            }

            PrefabUtility.UnloadPrefabContents(root);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log($"[Cleanup] Done. Prefabs touched: {prefabsTouched}, total removed: {removedTotal}");
    }
}
