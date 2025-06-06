using System;
using MornEnum;

namespace MornScene
{
    [Serializable]
    public sealed class MornSceneType : MornEnumBase
    {
        protected override string[] Values => MornSceneGlobal.I.RollbackKeys;
    }

    public static class MornSceneTypeEx
    {
        public static MornSceneObject ToScene(this MornSceneType sceneType)
        {
            return MornSceneGlobal.I.ToScene(sceneType);
        }
    }
}