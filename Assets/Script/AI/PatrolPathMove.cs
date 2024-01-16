using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PatrolPathMove : MonoBehaviour
{
    public PatrolPath patrolPath;
    private PatrolPath.PathPoint currentTarget;

    PatrolPath.PathPoint StartcurrentTarget;

    public float moveSpeed = 2f;
    public float arriveDistance = 0.1f;
    Vector2 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
        StartcurrentTarget = currentTarget;
        SetNextTarget();
    }

    void Update()
    {
        MoveAlongPath();
    }

    void MoveAlongPath()
    {
        //Nếu không có patrolPath hoặc là độ dài patrolPath = 0 thì xuất ra màn hình console
        if (patrolPath == null || patrolPath.Length == 0)
        {
            Debug.LogWarning("Patrol Path is not set or has no points.");
            return;
        }

        // Di chuyển đến điểm tiếp theo trên đường tuần tiện
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.Position, moveSpeed * Time.deltaTime);

        // Kiểm tra xem đã đến gần điểm đích chưa
        if (Vector2.Distance(transform.position, currentTarget.Position) < arriveDistance)
        {
            SetNextTarget();
        }
    }

    void SetNextTarget()
    {
        // Lấy điểm tiếp theo trên đường tuần tiện
        currentTarget = patrolPath.GetNextPathPoint(currentTarget.Index);

        // Đặt hướng di chuyển mới
        //Xác định hướng di chuyển mới từ vị trí hiện tại đến điểm tiếp theo trên đường tuần tiện
        //Tính toán hướng di chuyển bằng cách lấy hiệu 2 vector
        Vector2 directionToGo = currentTarget.Position - (Vector2)transform.position;
        //Tính toán góc quay cần thiết để hướng đối tượng về huống đi mới
        float angle = Mathf.Atan2(directionToGo.y, directionToGo.x) * Mathf.Rad2Deg;
        //Đặt quay của đối tượng theo góc vừa tính toán được
        //angle là góc quay còn Vector3.forward là trục quay
        //Ở đây mặc định trục quay là trục hướng tới phía trước
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void SetStartPatrolPoint()
    {
        currentTarget = StartcurrentTarget;
        transform.position = StartPosition;
        SetNextTarget();
    }
}
