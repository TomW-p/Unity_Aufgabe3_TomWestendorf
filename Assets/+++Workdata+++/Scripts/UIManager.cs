using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] private TMP_Text coinCountText;
    [SerializeField] private GameObject panelLost;
    [SerializeField] Button retryButton;
    
    [SerializeField] private TMP_Text timerText;
    [SerializeField] float remainingTime;
    public int countDownTime;
    [SerializeField] private TMP_Text countDownText;
    
    bool gameActive = false;
    


    void Start()
    {
        StartCoroutine(CountDownToStart());
        panelLost.SetActive(false);
        retryButton.onClick.AddListener(ReloadLevel);
    }

    void Update()
    {
        if (gameActive == true)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }else if (remainingTime < 0)
            {
                remainingTime = 0;
                timerText.color = Color.red;
            }
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
            
    }

    public void GameSetAktiv()
    {
        gameActive = true;
    }

    IEnumerator CountDownToStart()
    {
        while (countDownTime > 0)
        {
            countDownText.text = countDownTime.ToString();
            yield return new WaitForSeconds(1f);
            countDownTime--;
        }

        countDownText.text = "Go";
        characterController.SetMovementTrue();
        GameSetAktiv();
        yield return new WaitForSeconds(1f);
        countDownText.gameObject.SetActive(false);
    }
    
    

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowPanelLost()
    {
        panelLost.SetActive(true);
    }
    
    public void UpdateCoinText(int newCoinCount)
    {
        coinCountText.text = newCoinCount.ToString();
    }
}
