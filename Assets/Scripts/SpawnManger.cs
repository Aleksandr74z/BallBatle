using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    [SerializeField] GameObject _enemyPreab;
    private void Start()
    {
        SpawnEnemyWave();
    }

    private void SpawnEnemyWave()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(_enemyPreab, new Vector3(0, 5, 0), transform.rotation);
        }
    }

    
}
