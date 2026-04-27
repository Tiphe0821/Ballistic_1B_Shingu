using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public CreateNextBall createNextBall;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌했음 OnCollitionEnter2D");

        if(collision.gameObject.CompareTag(gameObject.tag))
        {
            Destroy(gameObject);
            createNextBall.BallCollision(this.gameObject);
        }
    }
}
