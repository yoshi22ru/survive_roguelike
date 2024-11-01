using System.Collections;
using UnityEngine;

public class PhaseControl : PanelSwitcher
{
    // フェーズやタイミング
    public static bool isInPurchasePhase = false;
    public static int currentPhase = 1;

    [SerializeField] protected float phaseDuration = 30.0f; // バトルフェーズの長さ
    [SerializeField] protected float purchasePhaseDuration = 10.0f; // 購入フェーズの長さ

    private float currentPhaseTime; // バトルフェーズ用の残り時間
    private float currentPurchasePhaseTime; // 購入フェーズ用の残り時間

    protected virtual void Start()
    {
        currentPhaseTime = phaseDuration;
        currentPurchasePhaseTime = purchasePhaseDuration;

        // フェーズ管理を一度だけ開始
        if (currentPhase == 1)
        {
            StartCoroutine(PhaseCon());
        }
    }

    protected virtual IEnumerator PhaseCon()
    {
        while (true)
        {
            currentPhaseTime = phaseDuration;
            Debug.Log("Phase " + currentPhase + " started.");

            // バトルフェーズ
            while (currentPhaseTime > 0)
            {
                currentPhaseTime -= Time.deltaTime;
                yield return null;
            }

            // 購入フェーズへ
            StartPurchasePhase();
            currentPurchasePhaseTime = purchasePhaseDuration;
            while (currentPurchasePhaseTime > 0)
            {
                currentPurchasePhaseTime -= Time.unscaledDeltaTime;
                yield return null;
            }

            EndPurchasePhase();
            currentPhase++;
        }
    }

    // 購入フェーズを開始
    protected void StartPurchasePhase()
    {
        isInPurchasePhase = true;
        Time.timeScale = 0; // ゲームを停止
        ActivePanel(panel); // 購入フェーズパネルを表示
        Debug.Log("Purchase phase started.");
    }

    // 購入フェーズを終了
    protected void EndPurchasePhase()
    {
        isInPurchasePhase = false;
        Time.timeScale = 1; // ゲーム再開
        NonActivePanel(panel); // 購入フェーズパネルを非表示
        Debug.Log("Purchase phase finished.");
    }

    // 現在のフェーズ時間を取得
    public float GetCurrentPhaseTime()
    {
        return currentPhaseTime;
    }

    // 現在の購入フェーズ時間を取得
    public float GetCurrentPurchasePhaseTime()
    {
        return currentPurchasePhaseTime;
    }
}
