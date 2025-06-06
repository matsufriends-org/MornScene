#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace MornScene
{
    [CustomPropertyDrawer(typeof(TypeToScene))]
    public class TypeToSceneDrawer : PropertyDrawer
    {
        public override void OnGUI(UnityEngine.Rect position, SerializedProperty property, GUIContent label)
        {
            var sceneType = property.FindPropertyRelative("SceneType");
            var scene = property.FindPropertyRelative("Scene");
            EditorGUI.BeginProperty(position, label, property);
            {
                position = EditorGUI.PrefixLabel(position, label);
                var indent = EditorGUI.indentLevel;
                {
                    EditorGUI.indentLevel = 0;
                    var halfWidth = position.width / 2;
                    const float spacing = 5f;
                    var sceneTypeRect = new Rect(position.x, position.y, halfWidth - spacing, position.height);
                    var sceneRect = new Rect(position.x + halfWidth, position.y, halfWidth, position.height);
                    EditorGUI.PropertyField(sceneTypeRect, sceneType, GUIContent.none);
                    EditorGUI.PropertyField(sceneRect, scene, GUIContent.none);
                    EditorGUI.indentLevel = indent;
                }
            }
            EditorGUI.EndProperty();
        }
    }
}
#endif