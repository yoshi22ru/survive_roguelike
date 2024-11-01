using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{

    // 移動スピード
    [SerializeField] float speed = 5;
    Animator animator;
    SpriteRenderer sr;

    private void Start()
    {
        animator = GetComponent<Animator>();
        this.sr = GetComponent<SpriteRenderer>();
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


        // 移動する向きを求める
        Vector2 direction = new Vector2(x, y).normalized;

        // 移動する向きとスピードを代入する
        GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
    }
}