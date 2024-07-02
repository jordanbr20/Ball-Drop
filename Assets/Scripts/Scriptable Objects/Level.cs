using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

[CreateAssetMenu(fileName = "Level #", menuName = "Game/New Level")]

public class Level : ScriptableObject
{
    public int levelNumber;
    public string levelCreator;
    public int goalNeeded;
    public bool communityMade; // use later
    public List<string> levelTop; // use later
}