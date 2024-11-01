using System.Collections;
using UnityEngine;


public class PhaseControl : PanelSwitcher
{
    // �t�F�[�Y��^�C�~���O
    public static bool isInPurchasePhase = false;
    public static int currentPhase = 1;

    float phaseDuration = 30.0f; // �t�F�[�Y�̒���
    [SerializeField] protected float purchasePhaseDuration = 10.0f; // �w���t�F�[�Y�̒���

    //�t�F�[�Y�Ǘ����s��
    private static float globalPhaseTime = 0.0f;

    protected virtual void Start()
    {
        // �t�F�[�Y�Ǘ�����x�����J�n
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
            // �t�F�[�Y���ԊǗ�
            globalPhaseTime = 0.0f;

            Debug.Log("Phase " + currentPhase + " started.");

            while (globalPhaseTime < phaseDuration)
            {
                globalPhaseTime += Time.deltaTime;
                yield return null;
            }

            // �t�F�[�Y�I����A�w���t�F�[�Y��
            StartPurchasePhase();
            yield return new WaitForSecondsRealtime(purchasePhaseDuration);

            EndPurchasePhase();

            // �t�F�[�Y�X�V
            currentPhase++;
        }
    }

    // �w���t�F�[�Y���J�n
    protected void StartPurchasePhase()
    {
        isInPurchasePhase = true;
        Time.timeScale = 0; // �Q�[�����~
        ActivePanel(panel);
        Debug.Log("Purchase phase started.");
    }

    // �w���t�F�[�Y���I��
    protected void EndPurchasePhase()
    {
        isInPurchasePhase = false;
        Time.timeScale = 1; // �Q�[���ĊJ
        NonActivePanel(panel);
        Debug.Log("Purchase phase finished.");
    }
}
