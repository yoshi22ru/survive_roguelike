using System.Collections;
using UnityEngine;

public class PhaseControl : PanelSwitcher
{
    // �t�F�[�Y��^�C�~���O
    public static bool isInPurchasePhase = false;
    public static int currentPhase = 1;

    [SerializeField] protected float phaseDuration = 30.0f; // �o�g���t�F�[�Y�̒���
    [SerializeField] protected float purchasePhaseDuration = 10.0f; // �w���t�F�[�Y�̒���

    private float currentPhaseTime; // �o�g���t�F�[�Y�p�̎c�莞��
    private float currentPurchasePhaseTime; // �w���t�F�[�Y�p�̎c�莞��

    protected virtual void Start()
    {
        currentPhaseTime = phaseDuration;
        currentPurchasePhaseTime = purchasePhaseDuration;

        // �t�F�[�Y�Ǘ�����x�����J�n
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

            // �o�g���t�F�[�Y
            while (currentPhaseTime > 0)
            {
                currentPhaseTime -= Time.deltaTime;
                yield return null;
            }

            // �w���t�F�[�Y��
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

    // �w���t�F�[�Y���J�n
    protected void StartPurchasePhase()
    {
        isInPurchasePhase = true;
        Time.timeScale = 0; // �Q�[�����~
        ActivePanel(panel); // �w���t�F�[�Y�p�l����\��
        Debug.Log("Purchase phase started.");
    }

    // �w���t�F�[�Y���I��
    protected void EndPurchasePhase()
    {
        isInPurchasePhase = false;
        Time.timeScale = 1; // �Q�[���ĊJ
        NonActivePanel(panel); // �w���t�F�[�Y�p�l�����\��
        Debug.Log("Purchase phase finished.");
    }

    // ���݂̃t�F�[�Y���Ԃ��擾
    public float GetCurrentPhaseTime()
    {
        return currentPhaseTime;
    }

    // ���݂̍w���t�F�[�Y���Ԃ��擾
    public float GetCurrentPurchasePhaseTime()
    {
        return currentPurchasePhaseTime;
    }
}
