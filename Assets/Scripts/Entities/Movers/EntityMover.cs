using UnityEngine;

public class EntityMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    protected float CurrentSpeed;
    protected float Speed => _speed;

    private void Start()
    {
        CurrentSpeed = _speed;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.down * CurrentSpeed * Time.deltaTime);
    }
}