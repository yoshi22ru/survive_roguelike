using UnityEngine;

public class SpawnerType5 : SpawnerBase
{
    protected override void Start()
    {
        // “Á’è‚Ì“G‚ÌƒvƒŒƒnƒu‚ğİ’è
        enemyPrefab = Resources.Load<GameObject>("Prefabs/EnemyType5");

        base.Start();
    }
}