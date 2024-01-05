using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemBallAnimals : MonoBehaviour
{
  GameManager gameManager;

private void Start()
{
    gameManager = FindObjectOfType<GameManager>();
}
    private bool hasCollided = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string currentPrefabName = gameObject.name.Replace("(Clone)", "");
        string collidedPrefabName = collision.gameObject.name.Replace("(Clone)", "");

     if (currentPrefabName.Equals(collidedPrefabName))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

            hasCollided = true; // Set the collision flag to true

            // Thông báo cho GameManager khi một đối tượng đã bị hủy
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.ObjectDestroyed(currentPrefabName, transform.position);
            }
        }
    }
 
}