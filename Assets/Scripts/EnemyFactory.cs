using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyAI))]

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _pointsParent;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var waitForTwoSeconds = new WaitForSeconds(2f);
        int enemyLastStartPosition = _pointsParent.childCount - 1;

        for (int i = 0; i < _pointsParent.childCount; i++)
        {
            var _enemy = Instantiate(_enemyPrefab, _pointsParent.GetChild(i));

            if (i == enemyLastStartPosition)
                i = -1;

            yield return waitForTwoSeconds;
        }
    }
}
