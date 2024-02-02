using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    // Danh sách prefab của các quả bóng khác nhau
    public GameObject[] ballPrefabs;

    public Transform spawnPoint;

    // Hàm được gọi khi click vào màn hình
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Gọi hàm sinh ball khi click
            SpawnRandomBall();
        }
    }

    private void SpawnRandomBall()
    {
        // Chọn ngẫu nhiên một prefab từ danh sách
        int randomIndex = Random.Range(0, ballPrefabs.Length);
        GameObject selectedBallPrefab = ballPrefabs[randomIndex];

        // Random vị trí mới
        Vector3 randomPosition = new Vector3(Random.Range(-5f, 5f), spawnPoint.position.y, 0f);

        // Sinh ra quả bóng tại vị trí mới với prefab đã chọn
        GameObject newBall = Instantiate(selectedBallPrefab, randomPosition, Quaternion.identity);

        // Thêm Rigidbody2D nếu không có
        Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = newBall.AddComponent<Rigidbody2D>();
        }

        // Áp dụng lực để làm cho bóng rơi xuống
        rb.gravityScale = 1.0f;

        // Thực hiện các xử lý khác tại đây nếu cần
    }
}
