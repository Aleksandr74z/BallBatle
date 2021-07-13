using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    private GameObject _player; 

    private Rigidbody _enemyRb;


    void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 lookDirection = ((_player.transform.position - transform.position).normalized);

        _enemyRb.AddForce(lookDirection * _speed);
    }
}
