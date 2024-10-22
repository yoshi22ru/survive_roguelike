using UnityEngine;

public class EnemyCon : MonoBehaviour
{

    // プレイヤーオブジェクトを取得
    [SerializeField] GameObject playerObj;

    // エネミーの追従スピード
    [SerializeField] float speed = 2.0f;

    // Rigidbody2Dへの参照
    private Rigidbody2D rb;

    private void Start()
    {
        // プレイヤーオブジェクトを探す
        if (playerObj == null)
        {
            playerObj = GameObject.Find("Player");
        }

        // Rigidbody2Dを取得
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // プレイヤーの位置を取得
        Vector2 playerPosition = playerObj.transform.position;

        // 現在のエネミーの位置
        Vector2 enemyPosition = rb.position;

        // プレイヤーとエネミーの位置の差を計算
        Vector2 direction = playerPosition - enemyPosition;

        // スムーズに追従するようにLerpを使用（差をゆっくり補間する）
        Vector2 newPosition = Vector2.Lerp(enemyPosition, playerPosition, speed * Time.deltaTime);

        // Rigidbody2Dを使ってエネミーの位置を更新
        rb.MovePosition(newPosition);
    }
}
