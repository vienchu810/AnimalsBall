using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<Vector3> destroyedObjectPositions = new List<Vector3>();
    private GameObject newObject;
    public GameObject prefab;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;
    public GameObject prefab7;
    public GameObject prefab8;
    public GameObject prefab9;

    // Đặt prefab mới mà bạn muốn sinh ra tại đây
    private bool canSpawnNewObject = true; // Biến flag kiểm tra xem có thể sinh ra đối tượng mới không

    private void Start()
    {
        // Gọi hàm kiểm tra và sinh ra GameObject mới ở đây nếu cần
        // CheckAndSpawnNewObject();
    }

    public void ObjectDestroyed(string objectName, Vector3 objectPosition)
    {
        // Thêm vị trí của đối tượng vào danh sách khi bị hủy
        destroyedObjectPositions.Add(objectPosition);

        // Gọi hàm kiểm tra và sinh ra GameObject mới
        CheckAndSpawnNewObject(objectName);
    }

    private void CheckAndSpawnNewObject(string objName)
    {
        if (destroyedObjectPositions.Count >= 2 && canSpawnNewObject)
        {
            Vector3 position1 = destroyedObjectPositions[0];
            Vector3 position2 = destroyedObjectPositions[1];
          
            Vector3 spawnPosition = (position1 + position2) / 2f;

             UnityEngine.Debug.Log(""+ position1 + " + " + position2 +" = "+ objName);
            // if (objName=="animals_1")  {
            //     newObject = Instantiate(prefab1, spawnPosition, Quaternion.identity);
            // } else if (objName=="animals_2"){
            //     newObject = Instantiate(prefab2, spawnPosition, Quaternion.identity);
            // } else if (objName=="animals_3"){
            //     newObject = Instantiate(prefab3, spawnPosition, Quaternion.identity);
            // } else if (objName=="animals_4"){
            //     newObject = Instantiate(prefab4, spawnPosition, Quaternion.identity);
            // } else if (objName=="animals_5"){
            //     newObject = Instantiate(prefab5, spawnPosition, Quaternion.identity);
            // } else if (objName=="animals_6"){
            //     newObject = Instantiate(prefab6, spawnPosition, Quaternion.identity);
            // } else if (objName=="animals_7"){
            //     newObject = Instantiate(prefab7, spawnPosition, Quaternion.identity);
            // } else if (objName=="animals_8"){
            //     newObject = Instantiate(prefab8, spawnPosition, Quaternion.identity);
            // } else if (objName=="animals_9"){
            //     newObject = Instantiate(prefab9, spawnPosition, Quaternion.identity);
            // }
            // print("objName ___ "+ objName);
            switch (objName)
            {
                case "animals_1":
                    newObject = Instantiate(prefab1, spawnPosition, Quaternion.identity);
                    break;
                case "animals_2":
                    newObject = Instantiate(prefab2, spawnPosition, Quaternion.identity);
                    break;
                case "animals_3":
                    newObject = Instantiate(prefab3, spawnPosition, Quaternion.identity);
                    break;
                case "animals_4":
                    newObject = Instantiate(prefab4, spawnPosition, Quaternion.identity);
                    break;
                case "animals_5":
                    newObject = Instantiate(prefab5, spawnPosition, Quaternion.identity);
                    break;
                case "animals_6":
                    newObject = Instantiate(prefab6, spawnPosition, Quaternion.identity);
                    break;
                case "animals_7":
                    newObject = Instantiate(prefab7, spawnPosition, Quaternion.identity);
                    break;
                case "animals_8":
                    newObject = Instantiate(prefab8, spawnPosition, Quaternion.identity);
                    break;
                case "animals_9":
                    newObject = Instantiate(prefab9, spawnPosition, Quaternion.identity);
                    break;
                default:
                    break;
            }
            Rigidbody2D newObjectRb = newObject.GetComponent<Rigidbody2D>();
            if (newObjectRb != null)
            {
                newObjectRb.gravityScale = 1f;
            }

            destroyedObjectPositions.Clear();

            canSpawnNewObject = false;

            StartCoroutine(ResetSpawnFlag());
        }
    }

    private System.Collections.IEnumerator ResetSpawnFlag()
    {
        yield return new WaitForSeconds(1f);
        canSpawnNewObject = true;
    }
}
