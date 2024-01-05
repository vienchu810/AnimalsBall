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
                // Kiểm tra imageObject không null trước khi truy cập thành phần của nó
                rb = imageObject.GetComponent<Rigidbody2D>();
                if (rb == null)
                {
                    rb = imageObject.AddComponent<Rigidbody2D>();
                }

                rb.gravityScale = 1f;
            }
            StartCoroutine(SpawnPrefabs(0.7f));
        }
    }

    IEnumerator SpawnPrefabs(float delay)
    {
        yield return new WaitForSeconds(delay);

        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            // Chọn một prefab ngẫu nhiên từ danh sách
            GameObject selectedPrefab = prefabList[Random.Range(0, prefabList.Count)];

            // Sử dụng prefab đã chọn thay vì tạo mới từ tilePrefab
            imageObject = Instantiate(selectedPrefab, new Vector3(-0.04f, 2.61f, 0.01707233f), Quaternion.identity, transform);


            SpriteRenderer spriteRenderer = imageObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                spriteRenderer = imageObject.AddComponent<SpriteRenderer>();
            }

            // Thay đổi SpriteRenderer nếu cần
        }
    }

}
