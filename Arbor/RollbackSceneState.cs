#if USE_ARBOR
using Arbor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornScene
{
    public class RollbackSceneState : StateBehaviour
    {
        [SerializeField] private MornSceneRollbackKey _key;
        [SerializeField] private LoadSceneMode _loadSceneMode;

        public override void OnStateBegin()
        {
            if (MornSceneService.I.TryGetRollbackScene(_key, out var sceneName))
            {
                SceneManager.LoadSceneAsync(sceneName, _loadSceneMode);
            }
            else
            {
                MornSceneGlobal.LogError($"RollbackSceneAction: Not found scene key: {_key}");
            }
        }
    }
}
#endif