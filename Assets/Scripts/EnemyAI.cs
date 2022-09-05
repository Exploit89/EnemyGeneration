using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float _enemySpeed = 3.0f;
    private float _obsstacleRange = 5.0f;
    private int _randomTurnAngle = 120;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        transform.Translate(0, 0, _enemySpeed * Time.deltaTime);

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.distance < _obsstacleRange)
            {
                float angle = Random.Range(-_randomTurnAngle, _randomTurnAngle);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}
