using UnityEngine;

public class UseSkill : MonoBehaviour
{
    [SerializeField] private GameObject[] skillButton; // スキルボタンの配列
    private static bool[] isSkillFire = new bool[4]; // 各スキルの発動状態を管理
    PhaseControl phaseControl;

    private void Update()
    {
        if (PhaseControl.isInPurchasePhase)
        {
            foreach (var button in skillButton)
            {
                button.SetActive(false);
            }
        }
        else
        {
            foreach (var button in skillButton)
            {
                button.SetActive(true);
            }
        }
    }

    public void SkillFire(int skillIndex)
    {
        if (skillIndex >= 0 && skillIndex < isSkillFire.Length)
        {
            isSkillFire[skillIndex] = true; // スキルを発動状態に設定
            Debug.Log($"Skill {skillIndex} activated"); // デバッグログを追加
        }
    }

    public bool IsSkillFire(int skillIndex)
    {
        return skillIndex >= 0 && skillIndex < isSkillFire.Length && isSkillFire[skillIndex];
    }

    public void ResetSkillFire(int skillIndex)
    {
        if (skillIndex >= 0 && skillIndex < isSkillFire.Length)
        {
            isSkillFire[skillIndex] = false; // スキルをリセット
            Debug.Log($"Skill {skillIndex} reset"); // デバッグログを追加
        }
    }
}
