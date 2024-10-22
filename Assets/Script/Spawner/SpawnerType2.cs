using UnityEngine;

public class SpawnerType2 : SpawnerBase
{
    protected override void Start()
    {
        // 特定の敵のプレハブを設定
        enemyPrefab = Resources.Load<GameObject>("Prefabs/EnemyType2");
        base.Start();
    }
}