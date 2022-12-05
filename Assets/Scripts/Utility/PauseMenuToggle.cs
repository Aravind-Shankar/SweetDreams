using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class PauseMenuToggle : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    
    PlayerManager playerManager;

    private Transform losePanel;
    private Transform winPanel;
    private Transform pausePanel;
    private Transform infoPanel;
    private Transform tutorialPanel;

    private TextMeshProUGUI infoTitleMesh;
    private string _defaultInfoTitle;
    private TextMeshProUGUI infoTextMesh;
    private string _defaultInfoText;

    private TextMeshProUGUI tutorialTitleMesh;
    private TextMeshProUGUI tutorialTextMesh;

    [HideInInspector]
    public bool win; // check for win
    [HideInInspector]
    public bool lose; // check for lose
    [HideInInspector]
    public bool inMarket; // if in market, can't pause

    public bool showedInitialTutorialTip = false;

    void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
        playerManager = FindObjectOfType<PlayerManager>();
        losePanel = transform.Find("LosePanel");
        winPanel = transform.Find("WinPanel");
        pausePanel = transform.Find("PausePanel");
        infoPanel = transform.Find("InfoPanel");

        infoTextMesh = infoPanel.Find("Info Text").GetComponent<TextMeshProUGUI>();
        _defaultInfoText = infoTextMesh.text;
        infoTitleMesh = infoPanel.Find("Info Title Text").GetComponent<TextMeshProUGUI>();
        _defaultInfoTitle = infoTitleMesh.text;

        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            tutorialPanel = transform.Find("TutorialPanel");

            tutorialTextMesh = tutorialPanel.Find("Tutorial Text").GetComponent<TextMeshProUGUI>();
            tutorialTitleMesh = tutorialPanel.Find("Tutorial Title Text").GetComponent<TextMeshProUGUI>();
        }

        if (canvasGroup == null) {
            Debug.LogError("No Canvas Group added!");
        }
        else
        {
            canvasGroup.interactable = false;
        }
    }

    void LateUpdate()
    {
        //if (!showedInitialTutorialTip)
        //{
        //    OpenTutorialTip();
        //    showedInitialTutorialTip = true;
        //}
        if (Input.GetKeyUp(KeyCode.Q) && !(win || lose || inMarket))
        { // if won or lose, can't trigger pause
            if (canvasGroup.interactable)
            {
                CloseMenu();
                pausePanel.gameObject.SetActive(false);
                infoPanel.gameObject.SetActive(false);
                if (SceneManager.GetActiveScene().name == "Tutorial")
                {
                    tutorialPanel.gameObject.SetActive(false);
                }
                Debug.Log("Closed Menu");
            }
            else
            {
                OpenMenu();
                pausePanel.gameObject.SetActive(true);
                infoPanel.gameObject.SetActive(true);
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

    public bool IsPaused()
    {
        return canvasGroup.interactable;
    }

    public void SetInfoText(string infoTitle, string infoText)
    {
        infoTitleMesh.text = infoTitle;
        infoTextMesh.text = infoText;
    }

    public void ResetInfoText()
    {
        infoTitleMesh.text = _defaultInfoTitle;
        infoTextMesh.text = _defaultInfoText;
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
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            textmeshPro.SetText("Ready to Start?\nScore: {0}", MoneySystem.Instance.Money);
        } else
        {
            textmeshPro.SetText("Score: {0}", MoneySystem.Instance.Money);
        }
    }

    public void OpenTutorialTip()
    {
        if (canvasGroup.interactable)
        {
            CloseMenu();
            // center info panel to the middle of the screen
            //infoPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(100, 0, 0);
            tutorialPanel.gameObject.SetActive(false);
            Debug.Log("Closed tutorial tip");
        }
        else
        {
            OpenMenu();
            // center info panel to the middle of the screen
            //infoPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
            //infoPanel.position = new Vector3(0, 0, 0);

            tutorialPanel.gameObject.SetActive(true);
            
        }
    }


    // set tutorial panel text
    public void SetTutorialPanelText(string tutorialTitle, string tutorialText)
    {
        tutorialTitleMesh.text = tutorialTitle;
        tutorialTextMesh.text = tutorialText;
    }
}
