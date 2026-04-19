using System.Collections.Generic;
using UnityEngine;

public class EnemyShadow : MonoBehaviour
{
    public Transform playerTransform;
    
    public float delaySeconds = 2f; 

    private struct PathPoint
    {
        public Vector2 position;
        public float rotation;
        public float timeRecorded;

        public PathPoint(Vector2 pos, float rot, float time)
        {
            position = pos;
            rotation = rot;
            timeRecorded = time;
        }
    }

    private List<PathPoint> pathHistory = new List<PathPoint>();
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        
        rb.bodyType = RigidbodyType2D.Kinematic;

        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void FixedUpdate()
    {
        if (playerTransform == null || GameController.gameOver) return;

        pathHistory.Add(new PathPoint(playerTransform.position, playerTransform.eulerAngles.z, Time.time));

        if (pathHistory.Count > 0)
        {
            if (Time.time - pathHistory[0].timeRecorded >= delaySeconds)
            {
                PathPoint pointToFollow = pathHistory[0];
                pathHistory.RemoveAt(0);

                rb.MovePosition(pointToFollow.position);
                rb.MoveRotation(pointToFollow.rotation);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.timeLeft = 0;
        }
    }
}