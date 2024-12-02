using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GenerationState {
    Idle,
    GeneratingRooms,
    GeneratingLights,
    GeneratingSpawnRoom,
    GeneratingExitRoom,
    GeeratingBarrier
}

public class GenerationManager : MonoBehaviour
{
    // parent of the world
    [SerializeField] private Transform WorldGrid;

    // the state of generation
    private GenerationState nowState;
    
    // player and camera
    [SerializeField] private GameObject Player, MainCamera;
    
    // prefabs of the rooms
    [SerializeField] private List<GameObject> RoomTypes;
    [SerializeField] private GameObject EmptyRoom, SpawnRoom, ExitRoom, Barrier;
    [SerializeField] private int GenEmptyChance;
    [SerializeField] private Slider EmptinessSlider;

    // data when generating rooms
    private float nowX = 0, nowY = 0, nowZ = 0;
    private Vector3 nowPos;
    private int nowPosTracker, nowRoom;

    // pos of Spawn room
    private Vector3 SpawnPos = new(0, 0, 0), ExitPos = new(0, 0, 0);
    private int SpawnID = 0, ExitID = 0;
    
    // prefabs of the lights
    [SerializeField] private List<GameObject> LightTypes;
    [SerializeField] private int GenLightChance;
    [SerializeField] private Slider BrightnessSlider;
    
    // size of the map and room
    [SerializeField] private int MapSize, RoomSize;
    private int MapSizeRoot = 0;

    // settings when generating world
    [SerializeField] private Slider MapSizeSlider;
    [SerializeField] private Button GenerateBtn, ReloadBtn, SpwanBtn;

    private void Start() {
        GenerateBtn.interactable  = true;
        ReloadBtn.interactable    = false;
        SpwanBtn.interactable     = false;
    }

    private void Update() {
        MapSize = (int)Mathf.Pow(MapSizeSlider.value, 4);
        GenEmptyChance = (int)EmptinessSlider.value;
        GenLightChance = (int)BrightnessSlider.maxValue - (int)BrightnessSlider.value;
        MapSizeRoot = (int)Mathf.Sqrt(MapSize);
    }

    // spawn a player
    public void SpawnPlayer() {
        Player.SetActive(false);
        SpawnPos.y += 5;
        Player.transform.position = SpawnPos;
        Player.SetActive(true);
        MainCamera.SetActive(false);
    }

    // generate barriers
    public void GenerateBarrier() {
        nowPos = new(nowX, nowY, nowZ);
        Instantiate(Barrier, nowPos, Quaternion.identity, WorldGrid);
    }

    public void GenerateWorld() {

        // Add the empty rooms into the roomtypes
        for (int i = 0; i < GenEmptyChance; i++) {
            RoomTypes.Add(EmptyRoom);
        }

        // determine the pos of the Spawn Room and Exit Room
        SpawnPos = new(0, 0, 0); ExitPos = new(0, 0, RoomSize);
        SpawnID = 0; ExitID = 0;
        do {
            SpawnID = UnityEngine.Random.Range(1, MapSize + 1);
            ExitID  = UnityEngine.Random.Range(1, MapSize + 1);
        } while((SpawnID == ExitID) || OutRangeCheck(SpawnID, ExitID));

        // controll ths bottons when generating world
        GenerateBtn.interactable  = false;
        ReloadBtn.interactable    = true;
        SpwanBtn.interactable     = true;

        int AllState = Enum.GetNames(typeof(GenerationState)).Length;
        for (int StateID = 0; StateID < AllState; StateID++) {

            nowPosTracker = 0; nowRoom = 1;

            for (int i = 1; i <= MapSize; i++) {

                // go to the next row
                if(nowPosTracker == MapSizeRoot) {

                    if(nowState == GenerationState.GeeratingBarrier) {
                        GenerateBarrier();
                    }
                    
                    nowPosTracker = 0;
                    nowX = 0; nowZ += RoomSize;

                    if(nowState == GenerationState.GeeratingBarrier) {
                        GenerateBarrier();
                    }
                }

                // continue when the pos is for the Spawn room or the Exit room
                if (i == SpawnID || i == ExitID) {
                    SpawnPos =  (i == SpawnID) ? new(nowX, nowY, nowZ) : SpawnPos;
                    ExitPos  =  (i == ExitID ) ? new(nowX, nowY, nowZ) : ExitPos;
                    nowRoom ++;
                    nowPosTracker ++;
                    nowX += RoomSize;
                    continue;
                }
                
                nowPos = new(nowX, nowY, nowZ);

                // generating obj
                switch (nowState) {

                    // generate rooms
                    case GenerationState.GeneratingRooms: {
                        Instantiate(RoomTypes[UnityEngine.Random.Range(0, RoomTypes.Count)]
                                    , nowPos, Quaternion.identity, WorldGrid);
                        break;
                    }

                    // generate lights
                    case GenerationState.GeneratingLights: {
                        System.Random rnd = new System.Random();
                        int rand = rnd.Next(0, GenLightChance + 1);
                        if(rand <= 1) {
                            Instantiate(LightTypes[UnityEngine.Random.Range(0, LightTypes.Count)]
                                       , nowPos, Quaternion.identity, WorldGrid);
                        }
                        break;
                    }

                    // generate barriers
                    case GenerationState.GeeratingBarrier: {
                        if(nowRoom <= MapSizeRoot && nowRoom >= 1) {
                            GenerateBarrier();
                        }
                        if(nowRoom <= MapSize && nowRoom >= MapSize - MapSizeRoot + 1) {
                            GenerateBarrier();
                        }
                        break;
                    }
                }
                nowRoom ++;
                nowPosTracker ++;
                nowX += RoomSize;
            }
            GoNextState();

            switch (nowState) {

                // generate Spawn room
                case GenerationState.GeneratingSpawnRoom: {
                    Instantiate(SpawnRoom, SpawnPos, Quaternion.identity, WorldGrid);
                    break;
                }

                // generate Exit room
                case GenerationState.GeneratingExitRoom: {
                    Instantiate(ExitRoom, ExitPos, Quaternion.identity, WorldGrid);
                    break;
                }
            }
        }
        nowX = RoomSize * MapSizeRoot;
        nowZ = RoomSize * (MapSizeRoot - 1);
        GenerateBarrier();
    }

    private bool OutRangeCheck(int id1, int id2) {
        if(((id1 >= 1) && (id1 <= MapSizeRoot)) 
        || ((id1 >= MapSize - MapSizeRoot + 1) && (id1 <= MapSize))) {
            return true;
        }
        if(((id2 >= 1) && (id2 <= MapSizeRoot)) 
        || ((id2 >= MapSize - MapSizeRoot + 1) && (id2 <= MapSize))) {
            return true;
        }
        if((id1 % MapSizeRoot == 0) || (id1 % MapSizeRoot == 1)) {
            return true;
        }
        if((id2 % MapSizeRoot == 0) || (id2 % MapSizeRoot == 1)) {
            return true;
        }
        return false;
    }

    private void GoNextState() {
        nowState ++;
        nowX = 0; nowY = 0; nowZ = 0;
        nowPosTracker = 0; nowRoom = 1;
        nowPos = Vector3.zero;
    }

    // reload the scene
    public void ReloadWorld() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
