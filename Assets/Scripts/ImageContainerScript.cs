using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageContainerScript : MonoBehaviour
{
    public List<GameObject> prefabList = new List<GameObject>();
    public int numberOfObjectsToSpawn = 10;
    public GameObject tilePrefab;
    private GameObject imageObject;
    public Rigidbody2D rb;
    private bool mouseClicked = false;
    private bool isMousePressed = false;

    public GameObject checkLost;


    public List<GameObject> GetPrefabList()

    {
        return prefabList;
    }
    void Start()
    {
        StartCoroutine(SpawnPrefabs(0f));

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (imageObject != null)
            {
                rb = imageObject.GetComponent<Rigidbody2D>();
                if (rb == null)
                {
                    if (imageObject != null)
                    {
                        rb = imageObject.AddComponent<Rigidbody2D>();
                    }
                }
                isMousePressed = true; // Đặt biến cờ thành true khi chuột được giữ
            }

        }

        // Kiểm tra nếu chuột được nhả ra
        if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false; // Đặt biến cờ thành false khi chuột được nhả ra
            if (rb != null)
            {
                rb.gravityScale = 1.5f;
            }
            // Khi nhả chuột, đặt gravityScale thành 1f
            StartCoroutine(SpawnPrefabs(0.7f));
            // InstantiatePrefab();
        }

        // Nếu chuột được giữ
        if (isMousePressed)
        {
            if (imageObject != null)
            {
                // Lấy vị trí của chuột trên màn hình
                Vector3 mousePos = Input.mousePosition;

                // Chuyển đổi vị trí chuột từ màn hình sang thế giới game
                Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

                // Chỉ thay đổi giá trị x của vị trí instantiate, giữ nguyên giá trị y
                worldMousePos.z = 0.01707233f; // Đặt giá trị z tùy thuộc vào kịch bản của bạn
                worldMousePos.y = imageObject.transform.position.y; // Giữ nguyên giá trị y
                imageObject.transform.position = worldMousePos;

               if (imageObject.transform.position.x > checkLost.transform.position.x)
                {
                
                    Debug.Log("Vượt quá biên - Kết thúc trò chơi");
                   
                }
            }
        }
    }

    IEnumerator SpawnPrefabs(float delay)
    {
        yield return new WaitForSeconds(delay);

        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            GameObject selectedPrefab = prefabList[Random.Range(0, prefabList.Count)];
            imageObject = Instantiate(selectedPrefab, new Vector3(-0.04f, 2.00f, 0.01707233f), Quaternion.identity, transform);
            SpriteRenderer spriteRenderer = imageObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                spriteRenderer = imageObject.AddComponent<SpriteRenderer>();
            }
        }
    }
    void InstantiatePrefab()
    {
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            GameObject selectedPrefab = prefabList[Random.Range(0, prefabList.Count)];
            imageObject = Instantiate(selectedPrefab, new Vector3(-0.04f, 2.00f, 0.01707233f), Quaternion.identity, transform);
            SpriteRenderer spriteRenderer = imageObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                spriteRenderer = imageObject.AddComponent<SpriteRenderer>();
            }
        }
    }


}
