using System.Collections;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private EnemyAI _enemyPrefab;
    [SerializeField] private Transform _pointsParent;

    private bool isWorking = false;

    private void Start()
    {
        isWorking = true;
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        float waitSecondsCount = 2f;
        var waitForTwoSeconds = new WaitForSeconds(waitSecondsCount);
        int pointCount = 0;

        while (isWorking)
        {
            var _enemy = Instantiate(_enemyPrefab.transform, _pointsParent.GetChild(pointCount));
            pointCount++;

            if (pointCount == _pointsParent.childCount)
                pointCount = 0;

            yield return waitForTwoSeconds;
        }
    }
}
