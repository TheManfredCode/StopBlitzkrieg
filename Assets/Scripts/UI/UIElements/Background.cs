using SceneManagement;
using UnityEngine;
using Zenject;

namespace UI.UIElements
{
    public class Background : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        [Inject]
        private void Construct(LevelSceneConfig config) =>
            _spriteRenderer.sprite = config.Background;
    }
}