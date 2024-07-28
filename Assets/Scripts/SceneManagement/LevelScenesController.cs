using System;
using System.Collections.Generic;
using System.Linq;
using SceneManagement;

public class LevelScenesController
{
    private AddressableSceneLoader _sceneLoader;
    private Dictionary<int, string> _sceneKeys = new Dictionary<int, string>();
    private Dictionary<int, string> _unlockedScenes;
    private int _currentSceneKey;

    public event Action<int> SceneKeyUpdateEvent;

    public LevelScenesController(List<string> sceneKeys)
    {
        if (sceneKeys == null || sceneKeys.Count == 0) return;

        _sceneLoader = new AddressableSceneLoader();
        AddSceneKeys(sceneKeys);
        CreateUnlockedScenes();
        
        LoadScene(_unlockedScenes.Last().Key);
    }

    public bool IsSceneLoaded => _sceneLoader.IsLoaded;

    public int CurrentLevel => _currentSceneKey + 1;

    public void UnlockNextLevel()
    {
        var lastUnlockedLevelKey = _unlockedScenes.Last().Key;
        
        if (_unlockedScenes.Count >= _sceneKeys.Count || _currentSceneKey != lastUnlockedLevelKey) 
            return;

        _currentSceneKey = lastUnlockedLevelKey + 1;
        _unlockedScenes.Add(_currentSceneKey, _sceneKeys[_currentSceneKey]);
    }
    
    public void LoadLastScene()
    {
        int lastSceneKey = _unlockedScenes.Last().Key;
        LoadScene(lastSceneKey);
    }

    public void ChangeToNextLevel()
    {
        if (_unlockedScenes == null || _unlockedScenes.Count == 0) return;

        _currentSceneKey++;

        if (_currentSceneKey >= _unlockedScenes.Count)
            _currentSceneKey = 0;

        LoadScene(_currentSceneKey);
    }

    public void ChangeToPreviousLevel()
    {
        if (_unlockedScenes == null || _unlockedScenes.Count == 0) return;

        _currentSceneKey--;

        if (_currentSceneKey < 0)
            _currentSceneKey = _unlockedScenes.Count - 1;

        LoadScene(_currentSceneKey);
    }

    private void LoadScene(int key)
    {
        _sceneLoader.LoadAddressableLevel(_unlockedScenes[key]);
        SceneKeyUpdateEvent?.Invoke(key);
    }

    private void AddSceneKeys(List<string> sceneKeys)
    {
        for (int i = 0; i < sceneKeys.Count; i++)
            _sceneKeys.Add(i, sceneKeys[i]);
    }

    private void CreateUnlockedScenes()
    {
        int firstSceneKey = 0;
        _currentSceneKey = firstSceneKey;
        var firstScene = _sceneKeys[firstSceneKey];
        _unlockedScenes = new Dictionary<int, string>() { { firstSceneKey, firstScene } };
    }
}