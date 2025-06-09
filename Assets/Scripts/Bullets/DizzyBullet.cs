using UnityEngine;
using System.Collections;

public class DizzyBullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public int damage = 50;
    public float exposionRadius = 0f;
    public float dizzyEffectTime = 1f;
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
        transform.LookAt(target);
    }

    void hitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (exposionRadius > 0f)
        {
            Explode();
        }
        else
        {
            damageEnemy(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, exposionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                damageEnemy(collider.transform);
                dizzyEffect(collider.transform);
            }
        }
    }

    void damageEnemy(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();


        if (e != null)
        {
            e.takeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, exposionRadius);
    }

    //IEnumerator dizzyEffect(Enemy enemy)
    //{
    //    enemy.speed = -enemy.speed;
    //    yield return new WaitForSeconds(dizzyEffectTime);
    //    enemy.speed = -enemy.speed;
    //}

    void dizzyEffect(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        Debug.Log("1111111111111111111111");
        if (e != null)
        {
            e.slow(0.5f);
            Debug.Log(e.speed.ToString());
        }
    }
}
