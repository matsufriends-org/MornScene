﻿#if USE_ARBOR
using Arbor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornScene
{
    public class WaitSceneCloseState : StateBehaviour
    {
        [SerializeField] private MornSceneType _scene;
        [SerializeField] private StateLink _next;
        private Scene _loadScene;

        public override void OnStateBegin()
        {
            _loadScene = SceneManager.GetSceneByName(_scene.ToScene());
        }

        public override void OnStateUpdate()
        {
            if (!_loadScene.isLoaded)
            {
                Transition(_next);
            }
        }
    }
}
#endif