using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryMenu : MonoBehaviour
{
    public Button mainMenuButton; // ปุ่มไปยัง Main Menu
    public Button sampleSceneButton; // ปุ่มไปยัง Sample Scene

    void Start()
    {
        // เชื่อมโยงฟังก์ชันให้กับปุ่ม
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        sampleSceneButton.onClick.AddListener(GoToSampleScene);
    }

    // ฟังก์ชันไปยัง Main Menu
    void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // เปลี่ยนเป็นชื่อฉาก MainMenu ที่คุณตั้งไว้
    }

    // ฟังก์ชันไปยัง Sample Scene
    void GoToSampleScene()
    {
        SceneManager.LoadScene("SampleScene"); // เปลี่ยนเป็นชื่อฉาก SampleScene ที่คุณตั้งไว้
    }
}
