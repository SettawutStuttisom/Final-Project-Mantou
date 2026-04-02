using UnityEngine;
using System.Collections; 
public class ItemSpawner : MonoBehaviour
{
    public GameObject pickupPrefab; // ไอเทมที่ต้องการให้เกิด
    public Camera playerCamera; // กล้องที่ใช้ในการคำนวณขอบเขต
    public float spawnInterval = 2f; // เวลาที่ให้ไอเทมเกิด (วินาที)
    public int maxItems = 10; // จำนวนไอเทมสูงสุดที่สามารถอยู่ในฉาก

    private int currentItemCount = 0; // จำนวนไอเทมปัจจุบันในฉาก

    void Start()
    {
        StartCoroutine(SpawnItemRoutine()); // เรียกให้ไอเทมเกิดเป็นรอบๆ
    }

    IEnumerator SpawnItemRoutine()
    {
        while (true)
        {
            if (currentItemCount < maxItems)
            {
                SpawnItem();
            }
            yield return new WaitForSeconds(spawnInterval); // รอเวลาตามที่กำหนด
        }
    }

    void SpawnItem()
    {
        // คำนวณขอบเขตของพื้นที่ที่กล้องมองเห็น
        float cameraHeight = 2f * playerCamera.orthographicSize;
        float cameraWidth = cameraHeight * playerCamera.aspect;

        // คำนวณตำแหน่ง random ในพื้นที่ที่กล้องมองเห็น
        Vector3 spawnPos = new Vector3(
            Random.Range(playerCamera.transform.position.x - cameraWidth / 2, playerCamera.transform.position.x + cameraWidth / 2),
            0.1f, // ปรับให้เกิดใกล้พื้น
            Random.Range(playerCamera.transform.position.z - cameraHeight / 2, playerCamera.transform.position.z + cameraHeight / 2)
        );

        Instantiate(pickupPrefab, spawnPos, Quaternion.identity); // สร้างไอเทม
        currentItemCount++; // เพิ่มจำนวนไอเทมในฉาก
    }

    public void ItemCollected() // เรียกใช้เมื่อเก็บไอเทม
    {
        currentItemCount--; // ลดจำนวนไอเทมในฉาก
    }
}
