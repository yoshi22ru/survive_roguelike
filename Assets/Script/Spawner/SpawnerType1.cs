using UnityEngine;

public class SpawnerType1 : SpawnerBase
{
    protected override void Start()
    {
        // 特定の敵のプレハブを設定
        enemyPrefab = Resources.Load<GameObject>("Prefabs/EnemyType1");
        base.Start();
    }
}
