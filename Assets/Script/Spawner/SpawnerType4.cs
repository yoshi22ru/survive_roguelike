using UnityEngine;

public class SpawnerType4 : SpawnerBase
{
    protected override void Start()
    {
        // “Á’è‚Ì“G‚ÌƒvƒŒƒnƒu‚ğİ’è
        enemyPrefab = Resources.Load<GameObject>("Prefabs/EnemyType4");

        base.Start();
    }
}