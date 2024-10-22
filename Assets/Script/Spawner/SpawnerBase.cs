using System.Collections;
using UnityEngine;

public class SpawnerBase : MonoBehaviour
{
    // 全体で管理するフェーズやタイミング
    public static bool isInPurchasePhase = false;
    public static int currentPhase = 1;

    [SerializeField] protected GameObject enemyPrefab;
    [SerializeField] protected float initialSpawnTime = 5.0f;
    [SerializeField] protected float minSpawnTime = 0.5f;
     float phaseDuration = 30.0f; // フェーズの長さ
    [SerializeField] protected float purchasePhaseDuration = 10.0f; // 購入フェーズの長さ
    [SerializeField] protected float spawnIncreaseRate = 1.1f;
    [SerializeField] protected float spawnTimeReduction = 0.1f;

    protected float currentSpawnTime;
    private float timeSinceLastSpawn = 0.0f;

    // フェーズ管理を行う
    private static float globalPhaseTime = 0.0f;

    protected virtual void Start()
    {
        currentSpawnTime = initialSpawnTime;

        // フェーズ管理を一度だけ開始
        if (currentPhase == 1)
        {
            StartCoroutine(PhaseControl());
        }
    }

    protected virtual void Update()
    {
        if (!isInPurchasePhase)
        {
            // 敵のスポーン管理
            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn >= currentSpawnTime)
            {
                SpawnEnemy();
                timeSinceLastSpawn = 0.0f;

                // スポーン間隔の調整
                currentSpawnTime = Mathf.Max(currentSpawnTime * spawnIncreaseRate, minSpawnTime);
            }
        }
    }

    // 敵のスポーン
    protected virtual void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    // 全スポナー共通のフェーズ管理
    protected virtual IEnumerator PhaseControl()
    {
        while (true)
        {
            // フェーズ時間管理
            globalPhaseTime = 0.0f;

            Debug.Log("Phase " + currentPhase + " started.");

            while (globalPhaseTime < phaseDuration)
            {
                globalPhaseTime += Time.deltaTime;
                yield return null;
            }

            // フェーズ終了後、購入フェーズへ
            StartPurchasePhase();
            yield return new WaitForSecondsRealtime(purchasePhaseDuration);

            EndPurchasePhase();

            // フェーズ更新
            currentPhase++;
            currentSpawnTime = Mathf.Max(currentSpawnTime - spawnTimeReduction, minSpawnTime);
        }
    }

    // 購入フェーズを開始
    protected void StartPurchasePhase()
    {
        isInPurchasePhase = true;
        Time.timeScale = 0; // ゲームを停止

        Debug.Log("Purchase phase started.");
    }

    // 購入フェーズを終了
    protected void EndPurchasePhase()
    {
        isInPurchasePhase = false;
        Time.timeScale = 1; // ゲーム再開

        Debug.Log("Purchase phase finished.");
    }
}
