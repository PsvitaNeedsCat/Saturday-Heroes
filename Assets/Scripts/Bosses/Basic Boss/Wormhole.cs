using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wormhole : MonoBehaviour
{
    [HideInInspector] public BasicBoss m_boss = null;

    private List<Vector3> m_points = new List<Vector3>();
    private List<GameObject> m_pointGameObjects = new List<GameObject>();
    private int m_pointsIndex = 0;
    private const int m_kNumPoints = 5;
    private Projectile m_projectile;
    private const float m_kProjectileDamage = 50.0f;
    [SerializeField] private GameObject m_pointPrefab;
    private EDamageType[] m_projHitTypes = new EDamageType[]
    {
        EDamageType.player,
        EDamageType.wormholePoint,
    };

    public void Init(GameObject _projectilePrefab)
    {
        // Get random points
        List<GameObject> potentialPoints = Grid.Instance.m_tiles.ToList();
        int gridLength = Grid.Instance.m_tiles.Length;

        for (int i = 0; i < m_kNumPoints; i++)
        {
            int randomIndex = Random.Range(0, gridLength - (i + 1));
            Vector3 newPoint = potentialPoints[randomIndex].transform.position;
            newPoint.y = m_boss.transform.position.y;
            m_points.Add(newPoint);
            potentialPoints.RemoveAt(randomIndex);
        }

        StartCoroutine(CreatePoints(_projectilePrefab));
    }

    private IEnumerator CreatePoints(GameObject _projectilePrefab)
    {
        for (int i = 0; i < m_points.Count; i++)
        {
            m_pointGameObjects.Add(Instantiate(m_pointPrefab, m_points[i], Quaternion.identity));

            yield return new WaitForSeconds(0.3f);
        }

        // Create projectile
        Quaternion rotation = Quaternion.LookRotation(m_points[m_pointsIndex] - transform.position);
        m_projectile = Instantiate(_projectilePrefab, transform.position, rotation).GetComponent<Projectile>();
        m_projectile.Init(m_projHitTypes, m_kProjectileDamage, 4.0f, 0.0f, ProjectileHit);
        m_projectile.GetComponentInChildren<Parryable>().m_parryAction = AttackFinished;
    }

    private void ProjectileHit(Hurtbox _hurtbox, Projectile _projectile)
    {
        if (_hurtbox.m_damageType == EDamageType.wormholePoint)
        {
            if (m_pointGameObjects[m_pointsIndex].GetInstanceID() == _hurtbox.gameObject.GetInstanceID())
            {
                ++m_pointsIndex;

                if (m_pointsIndex >= m_points.Count)
                {
                    // Attack finished
                    AttackFinished();
                }
                else
                {
                    MoveTowardsCurrentPoint();
                }
            }
        }

        else if (_hurtbox.m_damageType == EDamageType.player)
        {
            _hurtbox.ApplyDamage(_projectile.m_damage);

            AttackFinished();
        }
    }

    public void UpdateAttack()
    {

    }

    private void AttackFinished()
    {
        if (m_projectile)
        {
            Destroy(m_projectile.gameObject);
        }

        for (int i = 0; i < m_pointGameObjects.Count; i++)
        {
            Destroy(m_pointGameObjects[i]);
        }

        Destroy(gameObject);

        m_boss.NextAttack();
    }

    private void MoveTowardsCurrentPoint()
    {
        Vector3 newDirection = m_points[m_pointsIndex] - m_projectile.transform.position;

        m_projectile.ChangeDirection(newDirection);
    }
}
