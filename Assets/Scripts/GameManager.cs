using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] ReflectRay ray;
    [SerializeField] TextMeshProUGUI currentLevelText;
    [SerializeField] TextMeshProUGUI levelscurrentLevelText;

    [SerializeField] GameObject[] mirrors;
    [SerializeField] Vector2[] mirrorsStartinPositions;

    public int levelIncreaseController;

    public int currentLevel;

    [SerializeField] TextMeshProUGUI Score;
    public int totalScore = 0;

    private void Start()
    {
        levelIncreaseController = 1;
        currentLevel = 1;
        currentLevelText.gameObject.SetActive(true);

        MirrorsFirstPositions();
    }
    private void MirrorsFirstPositions()
    {
        for (int i = 0; i < mirrors.Length; i++)
        {
            mirrorsStartinPositions[i] = mirrors[i].transform.position;
        }
    }
    private void Update()
    {
        NextLevelActivate();
        LevelManager();
        CurrenLevelText();
        ScoreText();
    }
    private void ScoreText()
    {
        Score.text = "Score : " + totalScore.ToString();
    }
    private void CurrenLevelText()
    {
        currentLevelText.text = "Level : " + currentLevel;
        levelscurrentLevelText.text = "Level : " + currentLevel;
    }
    private void LevelManager()
    {
        if (currentLevel == 1)
        {
            ray.startPoint.x = -3.5f;
            ray.startPoint.y = -15f;
            ray.direction.x = 750;
            ray.direction.y = -781.42f;
        }
        else if (currentLevel == 2)
        {
            ray.nextLevelActivated = false;

            ray.startPoint.x = -3.5f;
            ray.startPoint.y = -16.3f;
            ray.direction.x = 750;
            ray.direction.y = -781.42f;

        }
        else if (currentLevel == 3)
        {
            ray.nextLevelActivated = false;

            ray.startPoint.x = 2.7f;
            ray.startPoint.y = -15;
            ray.direction.x = -1020.52f;
            ray.direction.y = -2162.4f;
        }
        else
        {
            StartCoroutine(LastLevelStartGameAgain());
        }
    }
    private void NextLevelActivate()
    {
        if (ray.nextLevelActivated)
        {
            for (int i = 0; i < mirrors.Length; i++)
            {
                mirrors[i].GetComponent<BoxCollider2D>().enabled = false;
                mirrors[i].transform.position = mirrorsStartinPositions[i];
            }

            currentLevel = levelIncreaseController;
            ray.levelIncreased = false;
        }
    }
    IEnumerator LastLevelStartGameAgain()
    {
        yield return new WaitForSeconds(.5f);
        ray.levelIncreased = false;
        currentLevelText.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}