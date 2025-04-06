#if USE_ARBOR
using Arbor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornScene
{
    public class ChangeSceneState : StateBehaviour
    {
        [SerializeField] private MornSceneObject _scene;

        public override void OnStateBegin()
        {
            SceneManager.LoadSceneAsync(_scene, LoadSceneMode.Single);
        }
    }
}
#endif