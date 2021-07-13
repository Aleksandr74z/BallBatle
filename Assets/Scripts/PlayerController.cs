using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private FocalPoint _focalPoint;
    [SerializeField] private GameObject _powerupIndicator;


    private Rigidbody _playerRb;
    private float _powerupStrength = 15f;

    private bool _hasPowerUp;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _playerRb.AddForce(_focalPoint.transform.forward * forwardInput * _speed);
        _powerupIndicator.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            _hasPowerUp = true;
            _powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine("PowerupCountdownRoutine");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && _hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * _powerupStrength, ForceMode.Impulse);
        }
    }

    private IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(6);
        _hasPowerUp = false;
        _powerupIndicator.gameObject.SetActive(false);
    }
}
