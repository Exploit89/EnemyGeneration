using System.Collections;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    private Vector3[] _points = new Vector3[]{
        new Vector3( 0, 0, 0 ),
        new Vector3(-5, 0, 0 ),
        new Vector3(0, 0, 5 ),
        new Vector3(0, 0, -5 ),
        new Vector3(5, 0, 0) };
    private GameObject _enemy;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var waitForTwoSeconds = new WaitForSeconds(2f);

        if (_enemy == null)
        {
            int enemyLastStartPosition = _points.Length - 1;

            for (int i = 0; i < _points.Length; i++)
            {
                _enemy = Instantiate(_enemyPrefab);
                _enemy.transform.position = _points[i];

                if (i == enemyLastStartPosition)
                    i = 0;

                yield return waitForTwoSeconds;
            }
        }
    }
}
