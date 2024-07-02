using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
    public Level level;
    public GameManager gameManager;
    public GameObject lockImg;
    public TMP_Text buttonText;

    List<Level> levelsUnlocked;
    bool isLocked;

    void Start()
    {
        buttonText = this.gameObject.GetComponentInChildren<TMP_Text>();
        buttonText.text = level.levelNumber.ToString();

        levelsUnlocked = gameManager.levelsUnlocked;

        CheckCompletion();

        if(isLocked)
        {
            lockImg.SetActive(true);
        }
    }

    public void CheckCompletion()
    {
        if(levelsUnlocked.Contains(level))
        {
            isLocked = false;
        }
        else if(!levelsUnlocked.Contains(level))
        {
            isLocked = true;
        }
    }

    public void UnlockLevel(Level levelUnlock)
    {
        if(level == levelUnlock)
        {
            isLocked = false;
            lockImg.SetActive(false);
        }
    }
}
