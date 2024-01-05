using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
  private void OnCollisionEnter2D(Collision2D collision)
    {
        GameController gameController = FindObjectOfType<GameController>();

        // Kiểm tra xem có một instance của GameController không
        if (gameController != null)
        {
            // Gọi phương thức xử lý va chạm từ GameController
            gameController.HandleCollision(collision);
        }
    }
}
