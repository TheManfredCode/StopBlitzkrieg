using UnityEngine;
using Sirenix.OdinInspector;

namespace SceneManagement
{
    [CreateAssetMenu(menuName = "LevelConfig")]
    public class LevelSceneConfig : ScriptableObject
    {
        // [InlineButton("SetSpawnerCapacity60", "60")]
        // [InlineButton("SetSpawnerCapacity30", "30")]
        // [InlineButton("SetSpawnerCapacity5", "5")]
        
        [SerializeField, PreviewField(75), HorizontalGroup("Split", 75)]
        private Sprite _background;
        [SerializeField, VerticalGroup("Split/Right"), LabelWidth(150)] 
        private Enemy _enemyObjectTemplate;
        [SerializeField, VerticalGroup("Split/Right"), LabelWidth(150)]
        [HorizontalGroup("Split/Right/SpawnerCapacityGroup")]
        private uint _spawnerCapacity;
        [SerializeField, VerticalGroup("Split/Right"), LabelWidth(150)] 
        [Range(0, 5)]
        private float _spawnRate;
        [SerializeField, VerticalGroup("Split/Right"), LabelWidth(150)] 
        private int _killsToWinCount;

        public Sprite Background => _background;
        
        public Enemy EnemyObjectTemplate => _enemyObjectTemplate;
        
        public uint SpawnerCapacity => _spawnerCapacity;
        
        public float SpawnRate => _spawnRate;
        
        public int KillsToWinCount => _killsToWinCount;
        
        [HorizontalGroup("Split/Right/SpawnerCapacityGroup", Width = 50)]
        [Button("5")]
        private void SetSpawnerCapacity5() => _spawnerCapacity = 5;
        
        [HorizontalGroup("Split/Right/SpawnerCapacityGroup", Width = 50)]
        [Button("30")]
        private void SetSpawnerCapacity30() => _spawnerCapacity = 30;

        [HorizontalGroup("Split/Right/SpawnerCapacityGroup", Width = 50)]
        [Button("60")]
        private void SetSpawnerCapacity60() => _spawnerCapacity = 60;
        
    }
}