#if USE_ARBOR
using Arbor;
using UnityEngine.SceneManagement;

namespace MornScene
{
    public class ReloadSceneState : StateBehaviour
    {
        public override void OnStateBegin()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
#endif