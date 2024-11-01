using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI battleTimerText;
    [SerializeField] TextMeshProUGUI purchaseTimerText;

    PhaseControl phaseControl;

    private void Start()
    {
        phaseControl = GameObject.FindFirstObjectByType<PhaseControl>();
    }

    private void Update()
    {
        if (phaseControl.GetCurrentPhase())
        {
            // �w���t�F�[�Y���̃^�C�}�[�\��
            purchaseTimerText.text = phaseControl.GetCurrentPurchasePhaseTime().ToString("f2");
            battleTimerText.text = "";
        }
        else
        {
            // �o�g���t�F�[�Y���̃^�C�}�[�\��
            battleTimerText.text = phaseControl.GetCurrentPhaseTime().ToString("f2");
            purchaseTimerText.text = "";
        }
    }
}
