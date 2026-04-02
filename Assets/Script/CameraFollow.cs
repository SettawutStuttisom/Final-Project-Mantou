using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // ตัวละครหลัก
    public float height = 10f; // ความสูงของกล้องจากตัวละคร

    void LateUpdate()
    {
        if (player != null)
        {
            // กำหนดตำแหน่งกล้องให้อยู่เหนือหัวตัวละครในแนวดิ่ง
            transform.position = new Vector3(player.position.x, player.position.y + height, player.position.z);
            
            // ให้กล้องมองตรงลงไปที่ตัวละคร
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }
}
