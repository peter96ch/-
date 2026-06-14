/*THIS CODE IS MY OWN WORK. IT WAS WRITTEN WITHOUT CONSULTING CODE WRITTEN BY OTHER STUDENTS OR ANY ONE WHO IS NOT AWARE OF MY REFERENCE. 414430045 Hsin-Yen Chiang and 414430017 LI-Yang Chen*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTransfer : MonoBehaviour
{
    [Header("Scene2")]
    public string[] sceneToLoad;


    //Collider觸發
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//是不是Player
        {   
            // 載入特定場景
            int randomIndex = Random.Range(0, sceneToLoad.Length);
            SceneManager.LoadScene(sceneToLoad[randomIndex]);
        }
    }
}
