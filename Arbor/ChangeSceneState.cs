#if USE_ARBOR
using Arbor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornScene
{
    public class ChangeSceneState : StateBehaviour
    {
        [SerializeField] private MornSceneType _scene;
        
        public override void OnStateBegin()
        {
            if (SceneManager.sceneCount > 1)
            {
                SceneManager.UnloadSceneAsync(gameObject.scene);
                SceneManager.LoadScene(_scene.ToScene(), LoadSceneMode.Additive);
            }
            else
            {
                SceneManager.LoadScene(_scene.ToScene());
            }
        }
    }
}
#endif