using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{

    // 移動スピード
    private float speed = 5;
    protected Animator animator;
    private SpriteRenderer sr;
    private UseSkill useSkill;
    [SerializeField] private GameObject useSkillEffect;

    private void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        useSkill = GetComponent<UseSkill>();
        useSkillEffect.SetActive(false); // エフェクトを非表示で開始
    }


    void FixedUpdate()
    {
        // 右・左
        float x = Input.GetAxisRaw("Horizontal");

        // 上・下
        float y = Input.GetAxisRaw("Vertical");


        if (x > 0 || y > 0 || x < 0 || y < 0)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Walk", true);
        }
        else if (x == 0 && y == 0)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Walk", false);
        }

        //キャラの向きを変更
        if (x > 0)
        {
            sr.flipX = false;
        }
        if (x < 0)
        {
            sr.flipX = true;
        }

        // スキル使用判定
        for (int i = 0; i < 4; i++)
        {
            if (useSkill.IsSkillFire(i)) // 各スキルの判定
            {
                animator.SetTrigger("Use");
                useSkillEffect.SetActive(true);
                StartCoroutine(HideUseSkillEffect()); // 一定時間後にエフェクトを非表示
                useSkill.ResetSkillFire(i); // 使用したスキルをリセット
                break; // 一度スキルを発動したらループを抜ける
            }
        }

        // 移動する向きを求める
        Vector2 direction = new Vector2(x, y).normalized;

        // 移動する向きとスピードを代入する
        GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
    }

    // 一定時間後にエフェクトを非表示にするコルーチン
    private IEnumerator HideUseSkillEffect()
    {
        yield return new WaitForSeconds(1f); // 1秒間エフェクトを表示
        useSkillEffect.SetActive(false); // エフェクトを非表示に戻す
    }
}