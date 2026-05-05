using UnityEngine;

public class BallGame : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public float[] ballSizes = { 0.5f, 0.7f, 0.9f, 1.1f, 1.3f, 1.5f, 1.7f, 1.9f };

    public GameObject currentBall;
    public int currentBallType;

    public bool isGameOver = false;
    public Camera mainCamera;

    public float ballTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        SpawnNewBall();
        ballTimer = -3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
            return;

        if (ballTimer >= 0)
        {
            ballTimer -= Time.deltaTime;
        }

        if (ballTimer < 0 && ballTimer > -2)
        {
            SpawnNewBall();
            ballTimer = -3.0f;
        }

        if (currentBall != null)
        {

            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            Vector3 newPosition = currentBall.transform.position;
            newPosition.x = worldPosition.x;

            float halfFruitSize = ballSizes[currentBallType] / 2f;

            currentBall.transform.position = newPosition;
        }

        if (Input.GetMouseButton(0) && ballTimer == -3.0f)
        {
            DropBall();
        }
    }

    void SpawnNewBall()
    {
        if (!isGameOver)
        {
            currentBallType = UnityEngine.Random.Range(0, 3);

            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);       // 마우스 2D 위치를 월드 3D 좌표로 변환

            Vector3 spawnPosition = new Vector3(worldPosition.x, worldPosition.y, 0);

            float halfBallSize = ballSizes[currentBallType] / 2f;

            currentBall = Instantiate(fruitPrefabs[currentBallType], spawnPosition, Quaternion.identity);
            currentBall.transform.localScale = new Vector3(ballSizes[currentBallType], ballSizes[currentBallType], 1);

            Rigidbody2D rb = currentBall.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.gravityScale = 0f;
            }
        }
    }

    void DropBall()
    {
        Rigidbody2D rb = currentBall.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 1f;
            currentBall = null;
            ballTimer = 1.0f;
        }
    }

    public void SpawnNextBall(Vector3 position)
    {
        
    }
}