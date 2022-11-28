using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
public class PauseMenuToggle : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    
    PlayerManager playerManager;

    private Transform losePanel;
    private Transform winPanel;
    private Transform pausePanel;

    public bool win; // check for win
    public bool lose; // check for lose

    void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
        playerManager = FindObjectOfType<PlayerManager>();
        losePanel = transform.Find("LosePanel");
        winPanel = transform.Find("WinPanel");
        pausePanel = transform.Find("PausePanel");
        if (canvasGroup == null) {
            Debug.LogError("No Canvas Group added!");
        }
        else
        {
            canvasGroup.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !(win || lose)) { // if won or lose, can't trigger pause
            if (canvasGroup.interactable) {
                CloseMenu();
                pausePanel.gameObject.SetActive(false);
            } else {
                OpenMenu();
                pausePanel.gameObject.SetActive(true);
            }
        }

        if (win && canvasGroup.alpha != 1)
            Win();
        if (lose && canvasGroup.alpha != 1)
            Lose();
    }

    public void OpenMenu() {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        playerManager.pauseGame += 1;

        Time.timeScale = 0f;
    }

    public void CloseMenu() {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0f;
        playerManager.pauseGame -= 1;

        Time.timeScale = 1f;
    }

    public void Lose() {
        OpenMenu();
        losePanel.gameObject.SetActive(true);
        GameObject score = losePanel.transform.Find("Score").gameObject;
        TextMeshProUGUI textmeshPro = score.GetComponent<TextMeshProUGUI>();
        textmeshPro.SetText("Score: {0}", MoneySystem.Instance.Money);
    }

    public void Win() {
        OpenMenu();
        winPanel.gameObject.SetActive(true);
        GameObject score = winPanel.transform.Find("Score").gameObject;
        TextMeshProUGUI textmeshPro = score.GetComponent<TextMeshProUGUI>();
        textmeshPro.SetText("Score: {0}", MoneySystem.Instance.Money);
    }
}
