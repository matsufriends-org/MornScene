using MornGlobal;
using UnityEngine;

namespace MornScene
{
    [CreateAssetMenu(fileName = nameof(MornSceneGlobal), menuName = "Morn/" + nameof(MornSceneGlobal))]
    public sealed class MornSceneGlobal : MornGlobalBase<MornSceneGlobal>
    {
        protected override string ModuleName => nameof(MornScene);
        [SerializeField] private string[] _rollbackKeys;
        public string[] RollbackKeys => _rollbackKeys;

        internal static void Log(string message)
        {
            I.LogInternal(message);
        }

        internal static void LogWarning(string message)
        {
            I.LogWarningInternal(message);
        }

        internal static void LogError(string message)
        {
            I.LogErrorInternal(message);
        }
    }
}