using System.Collections;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [Range(0,5)]
    public float speed;
    
    [Range(0,2)]
    public float waitDuration;
    Vector3 targetPos;
    
    public GameObject ways;
    public Transform[] WayPoints;
    private int pointIndex;
    private int pointCount;
    int direction = 1;
    
    
    int speedMultiplier = 1;

    void Awake()
    {
        WayPoints =new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.transform.childCount; i++)
        {
            WayPoints[i] = ways.transform.GetChild(i);
        }
    }

    void Start()
    {
        pointCount = WayPoints.Length;
        pointIndex = 1;
        targetPos = WayPoints[pointIndex].transform.position;
    }

    void Update()
    {
        var step = speedMultiplier*speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        if (transform.position == targetPos)
        {
            NextPoint();
        }
    }

    void NextPoint()
    {
        if (pointIndex == WayPoints.Length - 1)
        {
            direction = -1;
        }

        if (pointIndex == 0)
        {
            direction = 1;
        }
        
        pointIndex += direction;
        targetPos = WayPoints[pointIndex].transform.position;
        StartCoroutine(WaitNextPoint());
    }

    IEnumerator WaitNextPoint()
    {
        speedMultiplier = 0;
        yield return new WaitForSeconds(waitDuration);
        speedMultiplier = 1;
    }
}
