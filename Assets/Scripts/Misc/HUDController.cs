using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public static HUDController singleton;

    #region Editor Variables
    [SerializeField]
    [Tooltip("The part of the health that decreases")]
    private RectTransform m_HealthBar;

    [SerializeField]
    [Tooltip("The text component housing the current high score")]
    private Text m_HighScore;
    #endregion

    #region Private Variables
    private float p_HealthBarOrigWidth;
    private string m_DefaultHighScoreText;
    private int p_CurrScore;
    #endregion

    #region Initialization
    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        }
        p_HealthBarOrigWidth = m_HealthBar.sizeDelta.x;
        m_DefaultHighScoreText = m_HighScore.text;
        p_CurrScore = 0;
    }

    private void Start()
    {
        UpdateScoreDisplay(0);
    }
    #endregion

    #region Update Health Bar
    public void UpdateHealth(float percent)
    {
        m_HealthBar.sizeDelta = new Vector2(p_HealthBarOrigWidth * percent, m_HealthBar.sizeDelta.y);
    }
    #endregion

    #region Update Score Display
    public void UpdateScoreDisplay(int currScore)
    {
        m_HighScore.text = m_DefaultHighScoreText.Replace("%S", ""+currScore);
      
    }

    public void IncreaseScore(int amount)
    {
        p_CurrScore += amount;
        UpdateScoreDisplay(p_CurrScore);
    }
    #endregion
}
