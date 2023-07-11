using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] float scoreMultiplier;

    private float score;

    void Update()
    {

        score += Time.deltaTime * scoreMultiplier; // score increase by seconds

        scoreText.text = Mathf.FloorToInt(score).ToString();

    }
}
