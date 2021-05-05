using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class ScoreText : MonoBehaviour
{
    [SerializeField] private Player _player;

    private TMP_Text _score;

    private void Awake()
    {
        _score = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _player.ScoreHasChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreHasChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
    }
}
