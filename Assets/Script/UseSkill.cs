using UnityEngine;

public class UseSkill : MonoBehaviour
{
    [SerializeField] private GameObject[] skillButton; // �X�L���{�^���̔z��
    private static bool[] isSkillFire = new bool[4]; // �e�X�L���̔�����Ԃ��Ǘ�
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
            isSkillFire[skillIndex] = true; // �X�L���𔭓���Ԃɐݒ�
            Debug.Log($"Skill {skillIndex} activated"); // �f�o�b�O���O��ǉ�
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
            isSkillFire[skillIndex] = false; // �X�L�������Z�b�g
            Debug.Log($"Skill {skillIndex} reset"); // �f�o�b�O���O��ǉ�
        }
    }
}
