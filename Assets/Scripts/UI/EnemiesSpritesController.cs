using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class EnemiesSpritesController
    {
        private SpritesAssetBundleLoader _spritesLoader;
        private int _currentSpriteIndex;

        public event Action DataLoaded;
        public event Action<Sprite> SpriteUpdated;

        public EnemiesSpritesController(SpritesAssetBundleLoader spritesLoader)
        {
            _spritesLoader = spritesLoader;
            _spritesLoader.DataLoaded += OnDataLoaded;
        }
        
        private void OnDataLoaded()
        {
            _currentSpriteIndex = 0;
            UpdateEnemiesSprites();
            DataLoaded?.Invoke();
        }

        public Sprite GetCurrentSprite()
        {
            if (_sprites.Count > _currentSpriteIndex)
                return _sprites[_currentSpriteIndex];
            
            Debug.Log("[EnemiesSpritesSettings] Current sprite index out of range");
            return null;
        }
        
        public void ChangeToNextSprite()
        {
            if (_sprites == null || _sprites.Count == 0) return;
            
            _currentSpriteIndex++;

            if (_currentSpriteIndex >= _sprites.Count)
                _currentSpriteIndex = 0;

            UpdateEnemiesSprites();
        }

        public void ChangeToPreviousSprite()
        {
            if (_sprites == null || _sprites.Count == 0) return;
            
            _currentSpriteIndex--;

            if (_currentSpriteIndex < 0)
                _currentSpriteIndex = _sprites.Count - 1;

            UpdateEnemiesSprites();
        }
        
        private void UpdateEnemiesSprites() =>
            SpriteUpdated.Invoke(GetCurrentSprite());

        private List<Sprite> _sprites => _spritesLoader.Sprites;
    }
}