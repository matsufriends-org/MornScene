#if UNITY_EDITOR
using MornEnum;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace MornScene
{
    [CustomPropertyDrawer(typeof(MornSceneType))]
    public class MornSceneTypeDrawer : MornEnumDrawerBase
    {
        protected override string[] Values => MornSceneGlobal.I.SceneKeys;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // ボタンの幅を定義
            const float buttonWidth = 50f;
            const float spacing = 5f;
            
            // プロパティフィールドの領域を計算
            var fieldRect = new Rect(position.x, position.y, position.width - buttonWidth - spacing, position.height);
            
            // 基底クラスのOnGUIを呼び出してドロップダウンを描画
            base.OnGUI(fieldRect, property, label);
            
            // ボタンの領域を計算
            var buttonRect = new Rect(position.x + position.width - buttonWidth, position.y, buttonWidth, position.height);
            
            // Openボタンを描画
            if (GUI.Button(buttonRect, "開く"))
            {
                var keyProperty = property.FindPropertyRelative("_key");
                if (keyProperty == null || string.IsNullOrEmpty(keyProperty.stringValue))
                {
                    return;
                }

                var sceneType = new MornSceneType();
                sceneType.Key = keyProperty.stringValue;
                var sceneObject = sceneType.ToScene();
                if (sceneObject == null)
                {
                    return;
                }

                string sceneName = sceneObject;
                if (string.IsNullOrEmpty(sceneName))
                {
                    return;
                }

                // シーンを開く処理を遅延実行
                EditorApplication.delayCall += () =>
                {
                    // 現在のシーンが変更されている場合は保存確認
                    if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                    {
                        return;
                    }
                    
                    // Build Settingsからシーンパスを検索
                    string scenePath = null;
                    foreach (var scene in EditorBuildSettings.scenes)
                    {
                        if (scene.path.Contains($"/{sceneName}.unity"))
                        {
                            scenePath = scene.path;
                            break;
                        }
                    }
                    
                    // Build Settingsに見つからない場合は、プロジェクト内を検索
                    if (string.IsNullOrEmpty(scenePath))
                    {
                        var guids = AssetDatabase.FindAssets($"t:Scene {sceneName}");
                        if (guids.Length > 0)
                        {
                            scenePath = AssetDatabase.GUIDToAssetPath(guids[0]);
                        }
                    }
                    
                    // シーンを開く
                    if (!string.IsNullOrEmpty(scenePath))
                    {
                        EditorSceneManager.OpenScene(scenePath);
                    }
                    else
                    {
                        Debug.LogError($"Scene '{sceneName}' not found in project.");
                    }
                };
            }
        }
    }
}
#endif