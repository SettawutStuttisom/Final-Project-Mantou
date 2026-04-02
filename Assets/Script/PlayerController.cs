using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float sizeIncreaseFactor = 0.1f; // ตัวแปรเพิ่มขนาดตัวละคร
    public int score = 0; // คะแนนของผู้เล่น
    public Text scoreText; // UI สำหรับแสดงคะแนน
    public Camera playerCamera; // กล้องของตัวละคร
    public float zoomOutFOV = 90f; // ค่าการซูมออกของกล้อง
    public float normalFOV = 50f; // ค่าของ FOV ปกติ
    public float zoomSpeed = 5f; // ความเร็วในการซูมออก
    private float currentZoomFOV;
    private float lastZoomTime = 0.1f; // เวลาล่าสุดที่ซูมออก

    // ตัวแปรสำหรับการเปลี่ยนฉาก Victory
    public int victoryScore = 500; // คะแนนที่ต้องการเพื่อไปยังฉาก Victory

    // การเพิ่มเสียง
    public AudioSource audioSource; // AudioSource ที่จะใช้เล่นเสียง
    public AudioClip pickupSound; // เสียงเมื่อเก็บ item

    void Start()
    {
        // กำหนดกล้องเริ่มต้น (ถ้ายังไม่ตั้งค่า)
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }

        currentZoomFOV = normalFOV; // เริ่มต้นที่ FOV ปกติ

        // เช็คว่า AudioSource ถูกกำหนดหรือยัง
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>(); // หาตัว AudioSource ในตัวละคร
        }
    }

    void Update()
    {
        // การเคลื่อนที่ของตัวละคร
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;
        transform.position += move;

        // เช็คคะแนนและปรับการซูม
        CheckZoomBasedOnScore();

        // ป้องกันไม่ให้ตัวละครหมุน
        transform.rotation = Quaternion.identity; // รีเซ็ตการหมุนให้เป็นการหมุนเริ่มต้น

        // เมื่อคะแนนถึง 500 จะไปฉาก Victory
        if (score >= victoryScore)
        {
            LoadVictoryScene(); // ฟังก์ชันที่จะพาผู้เล่นไปยังฉาก Victory
        }

        // ปรับขนาดตัวละครตามคะแนนที่ได้
        UpdatePlayerSize();
    }

    // เพิ่มคะแนน
    public void AddScore(int amount)
    {
        score += amount; // เพิ่มคะแนน
        UpdateScoreUI(); // อัพเดต UI
        CheckVictoryCondition(); // ตรวจสอบเงื่อนไขการไปฉาก Victory

        // เล่นเสียงเมื่อเก็บ Item
        if (audioSource != null && pickupSound != null)
        {
            audioSource.PlayOneShot(pickupSound); // เล่นเสียง
        }
    }

    // อัพเดต UI ของคะแนน
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    // ฟังก์ชันซูมกล้องออก
    void CheckZoomBasedOnScore()
    {
        // ค่อยๆ ซูมออกทุกๆ 200 คะแนน
        if (score >= 200)
        {
            float targetZoomFOV = Mathf.Lerp(normalFOV, zoomOutFOV, (score / 200f)); // คำนวณ FOV ที่จะซูม
            currentZoomFOV = Mathf.Lerp(currentZoomFOV, targetZoomFOV, zoomSpeed * Time.deltaTime); // ค่อยๆ ซูมออก

            playerCamera.fieldOfView = currentZoomFOV; // อัปเดตค่า FOV ของกล้อง
        }
        else
        {
            currentZoomFOV = normalFOV; // รีเซ็ต FOV เมื่อคะแนนต่ำกว่า 200
            playerCamera.fieldOfView = currentZoomFOV;
        }
    }

    // ฟังก์ชันที่จะโหลดฉาก Victory เมื่อคะแนนถึง 500
    void LoadVictoryScene()
    {
        // ใช้ SceneManager เพื่อโหลดฉาก Victory
        SceneManager.LoadScene("VictoryScene"); // ปรับชื่อ "Victory" ตามที่ตั้งไว้ใน Unity
    }

    // ฟังก์ชันปรับขนาดตัวละครตามคะแนน
    void UpdatePlayerSize()
    {
        // ขยายขนาดตัวละครตามคะแนนที่ได้
        float sizeMultiplier = 1 + (score * sizeIncreaseFactor / 100); // คำนวณขนาดตัวละคร
        transform.localScale = new Vector3(sizeMultiplier, sizeMultiplier, sizeMultiplier); // ปรับขนาดของตัวละคร
    }

    // ฟังก์ชันตรวจสอบคะแนนและพาไปที่ฉาก Victory
    void CheckVictoryCondition()
    {
        if (score >= victoryScore) // เมื่อคะแนนถึงค่าที่ตั้งไว้
        {
            GoToVictoryScene(); // พาไปฉาก Victory
        }
    }

    // ฟังก์ชันพาไปยังฉาก Victory
    void GoToVictoryScene()
    {
        SceneManager.LoadScene("VictoryScene"); // เปลี่ยนฉากเป็น Victory
    }
}
