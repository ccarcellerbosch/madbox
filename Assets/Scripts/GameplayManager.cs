using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Linq;

public class GameplayManager : MonoBehaviour
{
    static GameplayManager _singleton;
	public static GameplayManager get{
		get {
			if (!_singleton)
				_singleton = FindObjectOfType<GameplayManager> ();
			return _singleton;
		}
	}

    //General information
    [HideInInspector]
    public GameState currentState = GameState.Menu;
    int currentLevel = 0;
    static bool showMainMenu = true;
    
    public GameObject goalPrefab;

    [Header("Manager references")]
    public LevelManager levelManager;
    public MainCharacterController characterPrefab;
    public UIManager uiManager;

    [Header("Object references")]
    public Transform levelElementsContainer;
    public CameraFollow currentCamera;

    [HideInInspector]
    public MainCharacterController charController;

    public List<Transform> allPathPositions;

    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("currentLevel", 0);
        uiManager.ShowMainMenu(showMainMenu);
        if(!showMainMenu)
            StartLevel();
        showMainMenu = false;
    }

    public void StartLevel()
    {
        currentState = GameState.Playing;
        levelManager.LoadLevel(currentLevel);
        SpawnCharacter();
    }

    public void EndLevel(bool win)
    {
        currentState = GameState.Results;
        if(win){
            currentLevel++;
            if(currentLevel >= levelManager.levels.Count)
                currentLevel = 0;
            PlayerPrefs.SetInt("currentLevel", currentLevel);
        }
        uiManager.ShowFinalResults(win);
        
    }

    void SpawnCharacter()
    {
        MainCharacterController character = Instantiate(characterPrefab, levelElementsContainer);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GoHome(){
        showMainMenu = true;
        ReloadScene();
    }


}


public enum GameState{
	Menu,
	Playing,
    Paused,
	Results
}
