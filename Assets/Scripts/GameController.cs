using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   public string targetLayerName = "anim_1";
    public GameObject newPrefab;
 bool hasCollided = false;
    public void HandleCollision(Collision2D collision)
    {
        // Kiểm tra xem GameObject hiện tại và GameObject va chạm có cùng layer "anim_1" không
        if (collision.gameObject.layer == LayerMask.NameToLayer(targetLayerName) && collision.collider.gameObject.layer == LayerMask.NameToLayer(targetLayerName))
        {
            hasCollided= true;
            Debug.Log("Va chạm với GameObject có layer là anim_1");

            // Hủy bỏ cả hai GameObject
              Destroy(collision.gameObject);
                Destroy(this.gameObject);

            // Thực hiện hành động Instantiate
            Instantiate(newPrefab, collision.collider.transform.position, Quaternion.identity);
        }
    }
}
