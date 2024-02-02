using System.IO;
using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private List<Vector3> destroyedObjectPositions = new List<Vector3>();
    private GameObject newObject;
    public GameObject effObject;
    private GameObject effObjectInstance;
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

    public Text scoreText; // Trường Text để hiển thị điểm hiện tại
    public Text highScoreText; // Trường Text để hiển thị điểm cao nhất
    private int score = 0;
    private int highScore = 0;
    private bool canSpawnNewObject = true; // Biến flag kiểm tra xem có thể sinh ra đối tượng mới không

    public AudioSource spawnSound;


    public AudioSource audioSource;

    public GameObject canvasObject;

   public Scrollbar volumeScrollbar;

   public Scrollbar volumeScrollVaCham;
    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                UnityEngine.Debug.LogError("AudioSource is not assigned to VolumeControl and not found on the GameObject.");
                return;
            }
        }

        // Kiểm tra xem volumeScrollbar đã được gán chưa
        if (volumeScrollbar == null)
        {
            UnityEngine.Debug.LogError("volumeScrollbar is not assigned to VolumeControl.");
            return;
        }

        // Đặt giá trị khởi đầu của slider theo giá trị âm lượng hiện tại
        volumeScrollbar.value = audioSource.volume;
        volumeScrollVaCham.value = spawnSound.volume; 

        volumeScrollbar.onValueChanged.AddListener(OnVolumeChanged);
         volumeScrollVaCham.onValueChanged.AddListener(OnVolumeChangedVaCham);

        canvasObject.SetActive(false);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        // Gọi hàm kiểm tra và sinh ra GameObject mới ở đây nếu cần
        // CheckAndSpawnNewObject();
        scoreText.text = " " + score.ToString();
        highScoreText.text = " " + highScore.ToString();
    }
     private void OnVolumeChanged(float volume)
    {
        // Khi giá trị của Slider thay đổi, cập nhật giá trị âm lượng
        spawnSound.volume = volume;
    }

     private void OnVolumeChangedVaCham(float volume)
    {
        // Khi giá trị của Slider thay đổi, cập nhật giá trị âm lượng
        audioSource.volume = volume;
    }
    public void ToggleCanvas()
    {
        // Đảo ngược trạng thái hiển thị của Canvas
        canvasObject.SetActive(!canvasObject.activeSelf);
        // Time.timeScale = (canvasObject.activeSelf) ? 0 : 1;
    }
    public void ToggleCanvasHide()
    {
        // Đảo ngược trạng thái hiển thị của Canvas
        canvasObject.SetActive(false);

    }
    public void ObjectDestroyed(string objectName, Vector3 objectPosition)
    {
        if (spawnSound != null)
        {
            // AudioSource.PlayClipAtPoint(spawnSound, objectPosition);
            
            spawnSound.Play();
        }
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

            StartCoroutine(SpawnObjectWithDelay(objName, spawnPosition));
        }
    }
    private IEnumerator SpawnObjectWithDelay(string objName, Vector3 spawnPosition)
    {
        canSpawnNewObject = false;

        switch (objName)
        {
            case "animals_1":
                newObject = Instantiate(prefab1, spawnPosition, Quaternion.identity);
                Vector3 prefabSize1 = prefab1.GetComponent<Renderer>().bounds.size;
                effObjectInstance = Instantiate(effObject, spawnPosition, Quaternion.identity);
                effObjectInstance.transform.localScale = prefabSize1;
                score += 20;
                HideDuongKe();
                StartCoroutine(DestroyEffObjectAfterDelay(effObjectInstance, 0.5f));

                UnityEngine.Debug.Log("newObject " + newObject);
                break;
            case "animals_2":
                newObject = Instantiate(prefab2, spawnPosition, Quaternion.identity);
                Vector3 prefabSize2 = prefab2.GetComponent<Renderer>().bounds.size;
                effObjectInstance = Instantiate(effObject, spawnPosition, Quaternion.identity);
                effObjectInstance.transform.localScale = prefabSize2;
                score += 40;
                HideDuongKe();
                StartCoroutine(DestroyEffObjectAfterDelay(effObjectInstance, 0.5f));

                UnityEngine.Debug.Log("newObject " + newObject);
                break;
            case "animals_3":
                newObject = Instantiate(prefab3, spawnPosition, Quaternion.identity);
                Vector3 prefabSize3 = prefab3.GetComponent<Renderer>().bounds.size;
                effObjectInstance = Instantiate(effObject, spawnPosition, Quaternion.identity);
                effObjectInstance.transform.localScale = prefabSize3;
                score += 80;
                HideDuongKe();
                StartCoroutine(DestroyEffObjectAfterDelay(effObjectInstance, 0.5f));

                UnityEngine.Debug.Log("newObject " + newObject);
                break;
            case "animals_4":
                newObject = Instantiate(prefab4, spawnPosition, Quaternion.identity);
                Vector3 prefabSize4 = prefab4.GetComponent<Renderer>().bounds.size;
                effObjectInstance = Instantiate(effObject, spawnPosition, Quaternion.identity);
                effObjectInstance.transform.localScale = prefabSize4;
                score += 128;
                HideDuongKe();
                StartCoroutine(DestroyEffObjectAfterDelay(effObjectInstance, 0.5f));

                UnityEngine.Debug.Log("newObject " + newObject);
                break;
            case "animals_5":
                newObject = Instantiate(prefab5, spawnPosition, Quaternion.identity);
                Vector3 prefabSize5 = prefab5.GetComponent<Renderer>().bounds.size;
                effObjectInstance = Instantiate(effObject, spawnPosition, Quaternion.identity);
                effObjectInstance.transform.localScale = prefabSize5;
                score += 256;
                HideDuongKe();
                StartCoroutine(DestroyEffObjectAfterDelay(effObjectInstance, 0.5f));

                UnityEngine.Debug.Log("newObject " + newObject);
                break;
            case "animals_6":
                newObject = Instantiate(prefab6, spawnPosition, Quaternion.identity);
                Vector3 prefabSize6 = prefab6.GetComponent<Renderer>().bounds.size;
                effObjectInstance = Instantiate(effObject, spawnPosition, Quaternion.identity);
                effObjectInstance.transform.localScale = prefabSize6;
                score += 512;
                HideDuongKe();
                StartCoroutine(DestroyEffObjectAfterDelay(effObjectInstance, 0.5f));

                UnityEngine.Debug.Log("newObject " + newObject);
                break;
            case "animals_7":
                newObject = Instantiate(prefab7, spawnPosition, Quaternion.identity);
                Vector3 prefabSize7 = prefab7.GetComponent<Renderer>().bounds.size;
                effObjectInstance = Instantiate(effObject, spawnPosition, Quaternion.identity);
                effObjectInstance.transform.localScale = prefabSize7;
                score += 810;
                HideDuongKe();
                StartCoroutine(DestroyEffObjectAfterDelay(effObjectInstance, 0.5f));

                UnityEngine.Debug.Log("newObject " + newObject);
                break;
            case "animals_8":
                newObject = Instantiate(prefab8, spawnPosition, Quaternion.identity);
                Vector3 prefabSize8 = prefab8.GetComponent<Renderer>().bounds.size;
                effObjectInstance = Instantiate(effObject, spawnPosition, Quaternion.identity);
                effObjectInstance.transform.localScale = prefabSize8;
                score += 1024;
                HideDuongKe();
                StartCoroutine(DestroyEffObjectAfterDelay(effObjectInstance, 0.5f));

                UnityEngine.Debug.Log("newObject " + newObject);
                break;
            case "animals_9":
                newObject = Instantiate(prefab9, spawnPosition, Quaternion.identity);
                Vector3 prefabSize9 = prefab9.GetComponent<Renderer>().bounds.size;
                effObjectInstance = Instantiate(effObject, spawnPosition, Quaternion.identity);
                effObjectInstance.transform.localScale = prefabSize9;
                score += 2048;
                HideDuongKe();
                StartCoroutine(DestroyEffObjectAfterDelay(effObjectInstance, 0.5f));

                UnityEngine.Debug.Log("newObject " + newObject);
                break;
            default:
                break;
        }
        scoreText.text = "" + score.ToString();
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "" + highScore.ToString();

            // Lưu điểm cao nhất vào PlayerPrefs
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); // Lưu thay đổi
        }
        Rigidbody2D newObjectRb = newObject.GetComponent<Rigidbody2D>();
        if (newObjectRb != null)
        {
            newObjectRb.gravityScale = 1f;
        }

        destroyedObjectPositions.Clear();

        canSpawnNewObject = true; // Đặt thành true ngay sau khi sinh ra quả bóng mới

        yield return null;
        // StartCoroutine(ResetSpawnFlag());



    }

    private System.Collections.IEnumerator ResetSpawnFlag()
    {
        yield return new WaitForSeconds(1f);
        canSpawnNewObject = true;
    }
    void HideDuongKe()
    {
        // Tìm DuongKe trong imageObject và ẩn đi
        Transform duongKeTransform = newObject.transform.Find("DuongKe");
        if (duongKeTransform != null)
        {
            duongKeTransform.gameObject.SetActive(false);
        }
    }
    private IEnumerator DestroyEffObjectAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
}
