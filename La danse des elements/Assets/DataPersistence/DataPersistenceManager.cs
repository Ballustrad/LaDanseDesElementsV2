using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//using System.Diagnostics;
//using Debug = UnityEngine.Debug;

public class DataPersistanceManager : MonoBehaviour
{
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    public static DataPersistanceManager instance {  get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistance Manager in the scene.");
        }
        instance = this;
    }
    public void Start()
    {
        this.dataPersistenceObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //if no data can be loaded, inialize to a new game
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults values");
            NewGame();
        }

        //push the Loaded data to all other scripts that need it
        foreach (IDataPersistence dataPersistenceObjects in dataPersistenceObjects)
        {
            //dans le tuto c'est " dataPersistenceObj "
            dataPersistenceObjects.LoadData(gameData);
        }

        Debug.Log("Loaded FireFragment = " + gameData.deathCount);
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObjects in dataPersistenceObjects)
        {
            //dans le tuto c'est " dataPersistenceObj "
            dataPersistenceObjects.SaveData(ref gameData);
        }

        Debug.Log("Saved FireFragment = " + gameData.deathCount);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
