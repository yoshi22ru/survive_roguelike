using UnityEngine;

public class SpawnerType1 : SpawnerBase
{
    protected override void Start()
    {
        // “Á’è‚Ì“G‚ÌƒvƒŒƒnƒu‚ğİ’è
        enemyPrefab = Resources.Load<GameObject>("Prefabs/EnemyType1");
        base.Start();
    }
}
