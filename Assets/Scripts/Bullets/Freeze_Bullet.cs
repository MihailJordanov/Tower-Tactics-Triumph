using UnityEngine;

public class Freeze_Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public int damage = 10;
    public float freezedSpeed = 5f;
    public Color freezedEnemyColor;
    public GameObject impactEffect;
    

    public void seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            hitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void hitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);

        damageEnemy(target);
        slow();

        Destroy(gameObject);


    }

    void damageEnemy(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.takeDamage(damage);
        }
    }

    void slow()
    {
        if (target.GetComponent<Enemy>().speed > freezedSpeed) 
        {
            target.GetComponent<Enemy>().speed = freezedSpeed;
            target.GetComponent<Enemy>().startSpeed = freezedSpeed;
            target.GetComponent<EnemyMovement>().rend.material.color = freezedEnemyColor;
        }
    }
}


