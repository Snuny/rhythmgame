using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource trackOne;
    public bool startPlaying;
    public BeatScroller scroller;
    public static GameManager instance;

    public int currentScore;
    public int scorePerNote, scorePerGoodNote, scorePerPerfectNote;

    public TextMeshProUGUI scoreText, multiplier;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public float totalNotes, normalHits, goodHits, perfectHits, missedHits;

    public GameObject notesSummary, results;
    public Text normalHitsText, goodHitsText, perfectHitsText, missedText, rankText, percentageText, finalScoreText;
    private string rankValue;
    private int scoreBonus;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;
        scorePerNote = 100;
        scorePerGoodNote = 150;
        scorePerPerfectNote = 200;
        currentScore = 0;
        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                startPlaying = true;
                scroller.hasStarted = true;
                trackOne.time = 0;
                trackOne.Play();
                Debug.Log(trackOne.clip.length);
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) && startPlaying == true)
            {
                if (trackOne.isPlaying)
                {
                    trackOne.Pause();
                }
                else
                {
                    trackOne.Play();
                }
            }
            if (trackOne.isPlaying && !results.activeInHierarchy && !notesSummary.activeInHierarchy && trackOne.time > 180.0f
                && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameScene"))
            {
                results.SetActive(true);
                notesSummary.SetActive(true);
                normalHitsText.text = "" + normalHits;
                goodHitsText.text = goodHits.ToString();
                perfectHitsText.text = perfectHits.ToString();
                missedText.text = "" + missedHits;

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100;
                percentageText.text = percentHit.ToString("F1") + "%";

                rankValue = "F";
                if (percentHit > 40)
                {
                    rankValue = "D";
                    scoreBonus = 10000;
                    if (percentHit > 50)
                    {
                        rankValue = "C";
                        scoreBonus = 20000;
                        if (percentHit > 65)
                        {
                            rankValue = "B";
                            scoreBonus = 30000;
                            if (percentHit > 75)
                            {
                                rankValue = "A";
                                scoreBonus = 40000;
                                if (percentHit > 90)
                                {
                                    rankValue = "S";
                                    scoreBonus = 50000;
                                }
                            }
                        }
                    }
                }

                rankText.text = rankValue;
                currentScore += scoreBonus;
                finalScoreText.text = currentScore.ToString();
                startPlaying = false;
            }

            if (trackOne.isPlaying && !results.activeInHierarchy && !notesSummary.activeInHierarchy && trackOne.time > 189.0f
                && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("TutorialScene"))
            {
                results.SetActive(true);
                notesSummary.SetActive(true);
                normalHitsText.text = "" + normalHits;
                goodHitsText.text = goodHits.ToString();
                perfectHitsText.text = perfectHits.ToString();
                missedText.text = "" + missedHits;

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100;
                percentageText.text = percentHit.ToString("F1") + "%";

                rankValue = "F";
                if (percentHit > 40)
                {
                    rankValue = "D";
                    scoreBonus = 10000;
                    if (percentHit > 50)
                    {
                        rankValue = "C";
                        scoreBonus = 20000;
                        if (percentHit > 65)
                        {
                            rankValue = "B";
                            scoreBonus = 30000;
                            if (percentHit > 75)
                            {
                                rankValue = "A";
                                scoreBonus = 40000;
                                if (percentHit > 90)
                                {
                                    rankValue = "S";
                                    scoreBonus = 50000;
                                }
                            }
                        }
                    }
                }

                rankText.text = rankValue;
                currentScore += scoreBonus;
                finalScoreText.text = currentScore.ToString();
                startPlaying = false;
            }
        }
    }

    public void NoteHit()
    {
        //Debug.Log("Hit");
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;
            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiplier.text = "Multiplier: x" + currentMultiplier;
        scoreText.text = "Score: " + currentScore;
        //currentScore += scorePerNote * currentMultiplier;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
        perfectHits++;
    }

    public void NoteMissed()
    {
        Debug.Log("Miss");
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiplier.text = "Multiplier: x" + currentMultiplier;
        missedHits++;
    }
}
