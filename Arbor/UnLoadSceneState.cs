﻿#if USE_ARBOR
using Arbor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornScene
{
    public class UnLoadSceneState : StateBehaviour
    {
        [SerializeField] private MornSceneType _scene;
        [SerializeField] private StateLink _next;
        private AsyncOperation _task;

        public override void OnStateBegin()
        {
            _task = SceneManager.UnloadSceneAsync(_scene.ToScene());
        }

        public override void OnStateUpdate()
        {
            if (_task == null || _task.isDone)
            {
                Transition(_next);
            }
        }
    }
}
#endif