using System.Collections;
using UnityEngine;


public class PhaseControl : PanelSwitcher
{
    // フェーズやタイミング
    public static bool isInPurchasePhase = false;
    public static int currentPhase = 1;

    float phaseDuration = 30.0f; // フェーズの長さ
    [SerializeField] protected float purchasePhaseDuration = 10.0f; // 購入フェーズの長さ

    //フェーズ管理を行う
    private static float globalPhaseTime = 0.0f;

    protected virtual void Start()
    {
        // フェーズ管理を一度だけ開始
        if (currentPhase == 1)
        {
            StartCoroutine(PhaseCon());
        }
    }

    protected virtual void Update()
    {
     
    }

    protected virtual IEnumerator PhaseCon()
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
        }
    }

    // 購入フェーズを開始
    protected void StartPurchasePhase()
    {
        isInPurchasePhase = true;
        Time.timeScale = 0; // ゲームを停止
        ActivePanel(panel);
        Debug.Log("Purchase phase started.");
    }

    // 購入フェーズを終了
    protected void EndPurchasePhase()
    {
        isInPurchasePhase = false;
        Time.timeScale = 1; // ゲーム再開
        NonActivePanel(panel);
        Debug.Log("Purchase phase finished.");
    }
}
