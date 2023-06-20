using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _template;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    [SerializeField] private Transform _spawnPoint; 
    [SerializeField] private float _spawnRate;

    private const float SPAWN_DISPERSION_OFFSET = 1f;
    private float _spawnDispersion;
    private List<T> _pool = new List<T>();
    private float _elapsedTime;

    protected List<T> Pool => _pool;

    public bool IsPaused { private get; set; }

    public virtual void Init()
    {
        _spawnDispersion = (CameraWidth - SPAWN_DISPERSION_OFFSET) / 2;
        IsPaused = true;

        for (int i = 0; i < _capacity; i++)
        {
            T poolObject = Instantiate(_template, _container.transform);
            AfterObjectInstantiated(poolObject);

            _pool.Add(poolObject);
        }
    }
    
    private void Update()
    {
        if (IsPaused) return;
        
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnRate)
        {
            ActivatePoolObject();
        }
    }

    protected virtual void AfterObjectInstantiated(T poolObject)
    {
        poolObject.gameObject.SetActive(false);
    }
    
    private float CameraWidth => Camera.main.orthographicSize * 2 * Camera.main.aspect;

    protected bool TryGetObject(out T result)
    {
        result = null;

        foreach (var poolObject in _pool)
            if (poolObject.gameObject.activeSelf == false)
                result = poolObject;
        
        return result != null;
    }

    private void ActivatePoolObject()
    {
        if (TryGetObject(out T poolObject))
        {
            _elapsedTime = 0;

            poolObject.gameObject.SetActive(true);
            poolObject.transform.position = GetPoolObjectPosition();
        }
    }

    private Vector3 GetPoolObjectPosition()
    {
        return _spawnPoint.position + new Vector3(Random.Range(-_spawnDispersion, _spawnDispersion), 0, 0);
    }
    
    public void RestartPool()
    {
        foreach (var poolObject in _pool)
            RestartPoolObject(poolObject);
    }

    protected virtual void RestartPoolObject(T poolObject)
    {
        poolObject.gameObject.SetActive(false);
    }
}