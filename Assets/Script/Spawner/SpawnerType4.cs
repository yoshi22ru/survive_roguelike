using UnityEngine;

public class SpawnerType4 : SpawnerBase
{
    protected override void Start()
    {
        // 特定の敵のプレハブを設定
        enemyPrefab = Resources.Load<GameObject>("Prefabs/EnemyType4");

        base.Start();
    }
}