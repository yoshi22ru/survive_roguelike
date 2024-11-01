using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI battleTimerText;
    [SerializeField] TextMeshProUGUI purchaseTimerText;

    private PhaseControl phaseControl;

    private void Start()
    {
        phaseControl = GameObject.FindFirstObjectByType<PhaseControl>();
    }

    private void Update()
    {
        if (PhaseControl.isInPurchasePhase)
        {
            // 購入フェーズ中のタイマー表示
            purchaseTimerText.text = phaseControl.GetCurrentPurchasePhaseTime().ToString("f2");
            battleTimerText.text = "";
        }
        else
        {
            // バトルフェーズ中のタイマー表示
            battleTimerText.text = phaseControl.GetCurrentPhaseTime().ToString("f2");
            purchaseTimerText.text = "";
        }
    }
}
