using UnityEngine;
using UnityEngine.SceneManagement; //  必須引入這個命名空間才能控制場景切換

public class MapTransfer2 : MonoBehaviour
{
    [Header("Scene1")]
    public string sceneToLoad2;


    // 當有帶有 Collider 2D 的物件進入觸發範圍時，Unity 會自動呼叫這個方法
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 檢查走進來的物件，它的 Tag 是不是 "Player"
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad2);
        }
    }
}
