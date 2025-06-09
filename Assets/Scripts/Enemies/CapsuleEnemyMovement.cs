using UnityEngine;

[RequireComponent(typeof(CapsuleEnemy))]
public class CapsuleEnemyMovement : MonoBehaviour
{
    public bool isBoss = false;

    [HideInInspector]
    public Renderer rend;
    private Transform target;
    private int wavePointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        rend = GetComponent<Renderer>();
        target = WayPoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWayPoint()
    {
        if (wavePointIndex >= WayPoints.points.Length - 1)
        {
            endPath();
            return;
        }

        wavePointIndex++;
        target = WayPoints.points[wavePointIndex];
    }

    void endPath()
    {
        if (!isBoss)
            PlayerStats.Lives--;
        else
            PlayerStats.Lives -= 100;
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }

}
