#if USE_ARBOR
using Arbor;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornScene
{
    public class AddAndWaitCloseSceneState : StateBehaviour
    {
        [SerializeField] private MornSceneObject _scene;
        [SerializeField] private StateLink _next;

        public override async void OnStateBegin()
        {
            await SceneManager.LoadSceneAsync(_scene, LoadSceneMode.Additive);
            var scene = SceneManager.GetSceneByName(_scene);
            while (scene.isLoaded)
            {
                await UniTask.Yield(CancellationTokenOnEnd);
            }

            Transition(_next);
        }
    }
}
#endif