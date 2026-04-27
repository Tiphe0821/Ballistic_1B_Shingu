using System.Collections.Generic;
using UnityEngine;

public class CreateNextBall : MonoBehaviour
{

    public List<GameObject> balls;

    public GameObject nextBalls;

    void Start()
    {

    }

    public void BallCollision(GameObject ball)
    {
        balls.Add(ball);

        if(balls.Count == 2)
        {
            Instantiate(nextBalls, balls[0].transform.position, Quaternion.identity);
            balls.Clear();
        }
    }


    void Update()
    {
        
    }
}
