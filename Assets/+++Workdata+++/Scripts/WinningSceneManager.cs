using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningSceneManager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("StartMenü");
    }
}
