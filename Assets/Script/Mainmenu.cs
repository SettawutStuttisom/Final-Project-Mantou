using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button sampleSceneButton; // ปุ่มไปยัง Sample Scene
    public Button exitGameButton; // ปุ่มออกจากเกม

    void Start()
    {
        // เชื่อมโยงฟังก์ชันให้กับปุ่ม
        sampleSceneButton.onClick.AddListener(GoToSampleScene);
        exitGameButton.onClick.AddListener(ExitGame);
    }

    // ฟังก์ชันไปยัง Sample Scene
    void GoToSampleScene()
    {
        SceneManager.LoadScene("SampleScene"); // เปลี่ยนเป็นชื่อฉาก SampleScene ที่คุณตั้งไว้
    }

    // ฟังก์ชันออกจากเกม
    void ExitGame()
    {
        // ถ้าอยู่ใน Editor จะหยุดการเล่นเกม
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); // ถ้าเป็นเกมที่สร้างแล้วจะออกจากเกม
        #endif
    }

    void Update()
    {
        // ตรวจสอบว่าเมื่อผู้เล่นกด Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame(); // เรียกฟังก์ชันออกจากเกม
        }
    }
}
