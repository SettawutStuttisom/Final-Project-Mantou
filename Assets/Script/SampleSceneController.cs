using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SampleSceneController : MonoBehaviour
{
    public Button mainMenuButton; // ปุ่มกลับไปยัง Main Menu
    public GameObject pauseMenu; // Canvas ที่มีปุ่ม Main Menu

    void Start()
    {
        // ซ่อนปุ่ม Main Menu ในตอนเริ่ม
        pauseMenu.SetActive(false);
        
        // เพิ่มฟังก์ชันให้กับปุ่ม
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    void Update()
    {
        // ตรวจสอบการกดปุ่ม Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu(); // สลับการแสดงหรือซ่อนปุ่ม Main Menu
        }
    }

    // ฟังก์ชันที่แสดงหรือซ่อนเมนูหยุดเกม
    void TogglePauseMenu()
    {
        if (pauseMenu.activeSelf)
        {
            // ซ่อนเมนูและเริ่มเกมใหม่
            pauseMenu.SetActive(false);
            Time.timeScale = 1; // เริ่มเกมใหม่
        }
        else
        {
            // แสดงเมนูและหยุดเกม
            pauseMenu.SetActive(true);
            Time.timeScale = 0; // หยุดเกม
        }
    }

    // ฟังก์ชันกลับไปยัง Main Menu
    void GoToMainMenu()
    {
        Time.timeScale = 1; // เริ่มเกมใหม่ก่อนที่จะเปลี่ยนฉาก
        SceneManager.LoadScene("MainMenu"); // เปลี่ยนเป็นฉาก MainMenu
    }
}
