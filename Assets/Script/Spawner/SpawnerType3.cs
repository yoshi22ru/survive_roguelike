using UnityEngine;

public class SpawnerType3 : SpawnerBase
{
    protected override void Start()
    {
        // “Á’è‚Ì“G‚ÌƒvƒŒƒnƒu‚ğİ’è
        enemyPrefab = Resources.Load<GameObject>("Prefabs/EnemyType3");
        base.Start();
    }
}