using UnityEngine;

public class UseSkill : MonoBehaviour
{
    [SerializeField] GameObject skillButton;
    private static bool isSkillFire = false;
    PhaseControl phaseControl;

    private void Update()
    {
        if (PhaseControl.isInPurchasePhase)
        {
            skillButton.SetActive(false);
        }
        else
        {
            skillButton.SetActive(true);
        }
    }

    public void SkillFire()
    {
        isSkillFire = true;
        Debug.Log("Use Skill");
    }

    public bool IsSkillFire()
    {
        return isSkillFire;
    }

    public void ResetSkillFire()
    {
        isSkillFire = false;
    }
}
