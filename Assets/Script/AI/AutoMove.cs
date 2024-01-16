using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float speed = 5f; // Tốc độ di chuyển của tank

    // Hàm di chuyển tank dựa trên vector di chuyển
    public void Move(Vector2 movementVector)
    {
        // Tính toán hướng di chuyển
        Vector3 movement = new Vector3(movementVector.x, 0f, movementVector.y);

        // Di chuyển tank theo hướng đã tính toán
        transform.Translate(movement.normalized * speed * Time.deltaTime);
    }

    void Update()
    {
        // Gọi hàm Move với một vector di chuyển tùy chọn
        // Ví dụ: di chuyển theo trục Ox
        Move(new Vector2(1f, 0f));
    }
}




