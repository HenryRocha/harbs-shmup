using UnityEngine;
using UnityEngine.SceneManagement;

public class WinVerify : MonoBehaviour
{
    private void Update()
    {
        GameObject[] enemiesAlive = GameObject.FindGameObjectsWithTag("Enemies");

        if (enemiesAlive.Length == 0)
        {
            SceneManager.LoadScene("YouWinMenu");
        }
    }
}
