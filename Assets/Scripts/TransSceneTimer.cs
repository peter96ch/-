using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PersistentTimer : MonoBehaviour
{
    //  單例模式 (Singleton)：確保全遊戲只有「這一個」計時器存在
    public static PersistentTimer Instance;

    [Header("遊戲總時間 (秒)")]
    public float timeRemaining = 120f;
    private bool isGameOver = false;

    //  因為換場景後舊文字會壞掉，我們改成用程式動態去「找」新文字
    private TextMeshProUGUI timerText;

    void Awake()
    {
        //  防複製人結界
        if (Instance == null)
        {
            Instance = this;
            // 🔥 核心魔法：告訴系統這個物件在換場景時不要刪除！
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            // 如果發現早就有人存在了，無情砍掉新生的複製人
            Destroy(gameObject);
            return;
        }
    }

    void OnEnable()
    {
        // 監聽 Unity 的「場景載入完成」事件
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // 斷開監聽，良好的寫程式習慣
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //  每當新場景開好時，Unity 會自動呼叫這個函數
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 如果切換到了 GameOver 場景，就停止計時
        if (scene.name == "GameOver")
        {
            isGameOver = true;
            return;
        }

        //  重大任務：在新場景中，尋找名字叫做 "TimerText" 的物件
        GameObject foundTextObj = GameObject.Find("TimerText");
        
        if (foundTextObj != null)
        {
            timerText = foundTextObj.GetComponent<TextMeshProUGUI>();
            Debug.Log(" 跨場景成功！已自動連接到新場景的 TimerText");
        }
        else
        {
            Debug.LogWarning(" 在新場景找不到名為 'TimerText' 的物件，請確認命名！");
        }
    }

    void Update()
    {
        if (!isGameOver && timerText != null)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining).ToString();
            }
            else
            {
                timeRemaining = 0;
                isGameOver = true;
                timerText.text = "Time: 0";
                TriggerGameOver();
            }
        }
    }

    void TriggerGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}