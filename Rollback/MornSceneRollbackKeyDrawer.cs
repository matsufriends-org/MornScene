#if UNITY_EDITOR
using MornEnum;
using UnityEditor;

namespace MornScene
{
    [CustomPropertyDrawer(typeof(MornSceneRollbackKey))]
    public class MornSceneRollbackKeyDrawer : MornEnumDrawerBase
    {
        protected override string[] Values => MornSceneGlobal.I.RollbackKeys;
    }
}
#endif