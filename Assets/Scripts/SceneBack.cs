/*THIS CODE IS MY OWN WORK. IT WAS WRITTEN WITHOUT CONSULTING CODE WRITTEN BY OTHER STUDENTS OR ANY ONE WHO IS NOT AWARE OF MY REFERENCE. 414430045 Hsin-Yen Chiang and 414430017 LI-Yang Chen*/

using UnityEngine;
using UnityEngine.SceneManagement; 

public class MapTransfer2 : MonoBehaviour
{
    [Header("Scene1")]
    public string sceneToLoad2;


    //Collider觸發
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //是不是Player
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad2);
        }
    }
}
