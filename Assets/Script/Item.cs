using UnityEngine;

public class Item : MonoBehaviour
{
    public int requiredPointsToCollect = 50; // พ้อยที่ต้องการเก็บไอเทมได้
    public int pointsReward = 10;            // พ้อยที่ได้รับเมื่อเก็บไอเทม
    private ItemSpawner itemSpawner;         // อ้างอิงถึง ItemSpawner ที่สร้างไอเทม

    void Start()
    {
        itemSpawner = FindObjectOfType<ItemSpawner>(); // หา ItemSpawner ในฉาก
    }

    // ฟังก์ชันที่จะถูกเรียกเมื่อผู้เล่นเก็บไอเทม
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null && playerController.score >= requiredPointsToCollect)
            {
                // เรียกฟังก์ชันให้คะแนนจากการเก็บไอเทม
                playerController.AddScore(pointsReward);
                itemSpawner.ItemCollected(); // แจ้งให้ ItemSpawner ลดจำนวนไอเทม
                Destroy(gameObject); // ลบไอเทมออกจากฉากหลังเก็บ
            }
        }
    }

    // ฟังก์ชัน Setup() ที่จะกำหนดค่าต่างๆ ให้กับไอเทม
    public void Setup(int requiredPoints, int rewardPoints)
    {
        requiredPointsToCollect = requiredPoints;
        pointsReward = rewardPoints;
    }
}
