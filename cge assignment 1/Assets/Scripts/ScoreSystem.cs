using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int score = 0;

    public void AddScore(int p_score)
    {
        score += p_score;
    }

    public int GetScore()
    {
        return score;
    }
}
