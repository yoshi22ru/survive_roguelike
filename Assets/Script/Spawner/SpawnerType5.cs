using UnityEngine;

public class SpawnerType5 : SpawnerBase
{
    protected override void Start()
    {
        // 特定の敵のプレハブを設定
        enemyPrefab = Resources.Load<GameObject>("Prefabs/EnemyType5");

        base.Start();
    }
}