using UnityEngine;

public class SpawnerType2 : SpawnerBase
{
    protected override void Start()
    {
        // “Á’è‚Ì“G‚ÌƒvƒŒƒnƒu‚ğİ’è
        enemyPrefab = Resources.Load<GameObject>("Prefabs/EnemyType2");
        base.Start();
    }
}