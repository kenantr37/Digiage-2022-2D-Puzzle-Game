using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ReflectRay : MonoBehaviour
{
    const int Infinity = 999;

    int maxReflections = 100;
    int currentReflections = 0;

    [SerializeField]
    public Vector2 startPoint, direction;
    List<Vector3> Points;
    int defaultRayDistance = 100;
    LineRenderer lr;

    public bool nextLevelActivated;

    [SerializeField] GameObject finishPanel;
    [SerializeField] GameManager gameManager;
    public bool levelIncreased;

    [SerializeField] SoundManager soundManager;

    void Start()
    {
        Points = new List<Vector3>();
        lr = transform.GetComponent<LineRenderer>();
    }
    private void Update()
    {
        var hitData = Physics2D.Raycast(startPoint, (direction - startPoint).normalized, defaultRayDistance);

        currentReflections = 0;
        Points.Clear();
        Points.Add(startPoint);

        if (hitData && !hitData.transform.CompareTag("MirrorBorder"))
        {
            ReflectFurther(startPoint, hitData);
        }
        else
        {
            Points.Add(startPoint + (direction - startPoint).normalized * Infinity);
        }

        lr.positionCount = Points.Count;
        lr.SetPositions(Points.ToArray());

    }
    private void ReflectFurther(Vector2 origin, RaycastHit2D hitData)
    {
        if (currentReflections > maxReflections) return;

        RayCollideObjectdController(hitData);

        Points.Add(hitData.point);
        currentReflections++;

        Vector2 inDirection = (hitData.point - origin).normalized;
        Vector2 newDirection = Vector2.Reflect(inDirection, hitData.normal);

        var newHitData = Physics2D.Raycast(hitData.point + (newDirection * 0.0001f), newDirection * 100, defaultRayDistance);

        if (newHitData && !newHitData.transform.CompareTag("MirrorBorder"))
        {
            ReflectFurther(hitData.point, newHitData);
        }
        else
        {
            Points.Add(hitData.point + newDirection * defaultRayDistance);
        }
    }
    void RayCollideObjectdController(RaycastHit2D hitData)
    {
        if (hitData.collider.gameObject.name == "Finish")
        {
            if (!levelIncreased && gameManager.levelIncreaseController <= 3)
            {
                soundManager.FinishSound();
                gameManager.levelIncreaseController += 1;
                levelIncreased = true;

                gameManager.totalScore += 100;
            }
            //Debug.Log("Finish Game");
            StartCoroutine(MoveToNextLevel());
        }
    }
    IEnumerator MoveToNextLevel()
    {
        while (true)
        {
            if (gameManager.currentLevel <= 3)
            {
                finishPanel.SetActive(true);
            }

            yield return new WaitForSeconds(.75f);
            nextLevelActivated = true;

            if (nextLevelActivated)
            {
                finishPanel.SetActive(false);
                break;
            }
        }
    }
}