using System.Collections;
using UnityEngine;

public class SpawnerBase : MonoBehaviour
{
    [SerializeField] protected GameObject enemyPrefab;
    [SerializeField] protected float initialSpawnTime = 5.0f;
    [SerializeField] protected float minSpawnTime = 0.5f;
    [SerializeField] protected float spawnIncreaseRate = 1.1f;
    [SerializeField] protected float spawnTimeReduction = 0.1f;

    protected float currentSpawnTime;
    private float timeSinceLastSpawn = 0.0f;

    protected virtual void Start()
    {
        currentSpawnTime = initialSpawnTime;
    }

    protected virtual void Update()
    {
        if (PhaseControl.isInPurchasePhase==false)
        {
            // �G�̃X�|�[���Ǘ�
            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn >= currentSpawnTime)
            {
                SpawnEnemy();
                timeSinceLastSpawn = 0.0f;

                // �X�|�[���Ԋu�̒���
                currentSpawnTime = Mathf.Max(currentSpawnTime * spawnIncreaseRate, minSpawnTime);
            }
        }
    }

    // �G�̃X�|�[��
    protected virtual void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
