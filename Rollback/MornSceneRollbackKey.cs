using System;
using MornEnum;

namespace MornScene
{
    [Serializable]
    public sealed class MornSceneRollbackKey : MornEnumBase
    {
        protected override string[] Values => MornSceneGlobal.I.RollbackKeys;
    }
}