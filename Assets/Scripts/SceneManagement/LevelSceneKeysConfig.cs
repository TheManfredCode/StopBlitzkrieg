using System.Collections.Generic;
using UnityEngine;

namespace SceneManagement
{
    [CreateAssetMenu(menuName = "LevelSceneKeysConfig")]
    public class LevelSceneKeysConfig : ScriptableObject
    {
        [SerializeField] private List<string> _sceneKeys;

        public List<string> SceneKeys => _sceneKeys;
    }
}