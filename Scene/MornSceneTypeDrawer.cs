#if UNITY_EDITOR
using MornEnum;
using UnityEditor;

namespace MornScene
{
    [CustomPropertyDrawer(typeof(MornSceneType))]
    public class MornSceneTypeDrawer : MornEnumDrawerBase
    {
        protected override string[] Values => MornSceneGlobal.I.SceneKeys;
    }
}
#endif