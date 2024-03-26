using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed = 5f; // Tốc độ di chuyển

    private bool isMoving = false; // Biến kiểm tra xem đối tượng có đang di chuyển không
    private Vector3 targetPosition; // Vị trí đích của di chuyển

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;

            if (!isMoving)
            {
                targetPosition = touchPosition;
                isMoving = true;
            }
        }

        if (isMoving)
        {
            float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

            if (distanceToTarget > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
            else
            {
                isMoving = false;
            }
        }
    }
}
