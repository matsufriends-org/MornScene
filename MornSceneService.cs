using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornScene
{
    [AddComponentMenu("")]
    internal sealed class MornSceneService : MonoBehaviour
    {
        [SerializeField] private List<string> _rollbackKeys = new();
        [SerializeField] private List<string> _rollbackSceneNames = new();
        private static MornSceneService _instance;
        public static MornSceneService I
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindAnyObjectByType<MornSceneService>(FindObjectsInactive.Include);
                }

                if (_instance == null)
                {
                    var go = new GameObject(nameof(MornSceneService));
                    _instance = go.AddComponent<MornSceneService>();
                }

                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void RegisterRollbackScene(MornSceneRollbackKey key, Scene scene)
        {
            var index = _rollbackKeys.IndexOf(key.Key);
            if (index != -1)
            {
                // 既に登録されている場合は上書き
                _rollbackSceneNames[index] = scene.name;
                return;
            }
            
            _rollbackKeys.Add(key.Key);
            _rollbackSceneNames.Add(scene.name);
        }

        public bool TryGetRollbackScene(MornSceneRollbackKey key, out string sceneName)
        {
            var index = _rollbackKeys.IndexOf(key.Key);
            if (index == -1)
            {
                sceneName = default;
                return false;
            }

            sceneName = _rollbackSceneNames[index];
            return true;
        }
    }
}