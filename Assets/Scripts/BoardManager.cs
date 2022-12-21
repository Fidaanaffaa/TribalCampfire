using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    //[SerializeField] public GameObject row1;  
    //[SerializeField] public GameObject row2;  
    //[SerializeField] public GameObject row3;  
    //[SerializeField] public GameObject row4;  
    //[SerializeField] public GameObject row5;  
    //[SerializeField] public GameObject row6;  
    //[SerializeField] public GameObject row7;  
    //[SerializeField] public GameObject row8;  
    //[SerializeField] public RowManager[] rows2;

    [SerializeField] private List<RowManager> rows;




    public HashSet<Tuple<int, int>> playersCoords = new HashSet<Tuple<int, int>>
        {new Tuple<int, int>(0, 0),
        new Tuple<int, int>(0, 7),
        new Tuple<int, int>(7, 7),
        new Tuple<int, int>(7,0)};

    public (int, int)[] squareCoords = new (int, int)[] { 
        (0, 0), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), 
        (0, 7),  (1, 7), (2, 7), (3, 7), (4, 7), (5, 7), (6, 7), 
        (7, 7), (7, 6), (7, 5), (7, 4), (7, 3), (7, 2), (7, 1), 
        (7, 0), (6, 0), (5, 0), (4, 0), (3, 0), (2, 0), (1, 0) };
    private int currentSquareIdx;

    // Beat Section
    //[(0,0), (0,7), (7, 7), (7,0)]

    // Player Section
    private int player_list_index = 0;
    //private List<Tuple<Player, int>> players = new List<Tuple<Player, int>>();
    private List<Player> players = new List<Player>();
    private List<int> player_steps = new List<int> { 6, 6, 6, 6 }; 
    [SerializeField] private List<Tuple<int, int>> playerCoords = new List<Tuple<int, int>> { 
        new Tuple<int, int>(0, 0),
        new Tuple<int, int>(0, 7),
        new Tuple<int, int>(7, 7),
        new Tuple<int, int>(7, 0),
            };

    // Beat Section
    private int beat_list_index = 0;
    private float[] beats_list = new float[]{1, 0.9f, 0.8f, 0.7f, 0.6f, 0.5f, 0.4f, 0.4f, 0.4f,
        0.3f, 0.3f, 0.3f, 0.3f, 0.2f, 0.2f, 0.2f, 0.2f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f,0.1f,0.1f,0.1f }; // Changes beat per player
    private float BeatTakenInLastStep = 0;
    private float nextBeatUpdate = 1;
    
    // Start is called before the first frame update
    void Awake()
    {
        // Adds all the children of the Board (only 8, not the grandchildren)
        foreach (var row in GetComponentsInChildren<RowManager>()) 
        {
            rows.Add(row);
        }
        foreach(var player in GetComponentsInChildren<Player>())
        {
            players.Add(player); // Need to make Modular
        }
        Player temp_player = players[3];
        players[3] = players[2];
        players[2] = temp_player;
        currentSquareIdx = 0;
        initPlayersPositionsColor();

        //colorAllCube(); // mostly for testing popurses, color everything in red, 
    }
    
    // Update is called once per frame
    void Update(){
     
        // If the next update is reached
        //if(Time.time>=nextUpdate){
        //    // Debug.Log(Time.time+">="+nextUpdate);
        //    // Change the next update (current second+0.5)
        //    nextUpdate=(double) Mathf.FloorToInt(Time.time) + 1;
        //    // Call your fonction
        //    Next();
        //}
     
    }
    
    public void UpdateBeat(float SongPosition)
    {
        if (players.Count == 1)
        {
            Debug.Log("YOU_WIN");
        }
        else if (SongPosition - BeatTakenInLastStep >= nextBeatUpdate)
        {
            Next();
            nextBeatUpdate = ((beats_list[beat_list_index]*6) / player_steps[player_list_index]); // Taken Every beat
            BeatTakenInLastStep = SongPosition;
        }
        //nextBeatUpdate = (1 / cur_steps);
    }

    public void Next()
    // To Be used as update by the game Manager 
    {
        int lastIndex = currentSquareIdx; 
            
        currentSquareIdx = (currentSquareIdx + 1) % squareCoords.Length;
        // Debug.Log("Calling Next");
        (int x, int y) =  squareCoords[currentSquareIdx];
        
        // Debug.Log(x.ToString()+","+y.ToString());
        
        // todo add if is player than green
        if (playerCoords.Contains(new Tuple<int, int>(x,y)))
        {
            rows[x].setColorToBatch(new int[] { y }, 0, 1, 0, 1);
            beat_list_index = (beat_list_index +  1) % beats_list.Length;
            //player_list_index = (player_list_index + 1) % players.Count;


        }
        else
        {
            rows[x].setColorToBatch(new int[]{y}, 1, 1, 0, 1);
        }
        
        
        //rows[x].GetComponent<RowManager>().setColorToBatch(new int[]{y}, 1, 1, 0, 1);
        
        
        (x, y) =  squareCoords[lastIndex];
        //         rows[x].GetComponent<RowManager>().setColorBaclToDeafultColorTosBatch(new int[]{y});

        rows[x].setColorBaclToDeafultColorTosBatch(new int[]{y});
        
    }

    public void initPlayersPositionsColor()
    // currently support only 4 players. later we will figure it out
    {
        //rows[0].GetComponent<RowManager>().setDeafultColorToBatch(new int[]{0,7}, 1, 0, 0, 1);

        //rows[7].GetComponent<RowManager>().setDeafultColorToBatch(new int[]{0,7}, 1, 0, 0, 1);
        rows[0].setDeafultColorToBatch(new int[] { 0, 7 }, 1, 0, 0, 1);

        rows[7].setDeafultColorToBatch(new int[] { 0, 7 }, 1, 0, 0, 1);


    }


    public void colorAllCube()
        // currently support only 4 players. later we will figure it out
    {

        for (int i = 0; i < 8; i++) // Only 8 rows, should make modular?
        {
            rows[i].setColorToALL(1, 0, 0, 1);
        }
        //rows[0].GetComponent<RowManager>().setColorToALL(1, 0, 0, 1);
        //rows[1].GetComponent<RowManager>().setColorToALL(1, 0, 0, 1);
        //rows[2].GetComponent<RowManager>().setColorToALL(1, 0, 0, 1);
        //rows[3].GetComponent<RowManager>().setColorToALL(1, 0, 0, 1);
        //rows[4].GetComponent<RowManager>().setColorToALL(1, 0, 0, 1);
        //rows[5].GetComponent<RowManager>().setColorToALL(1, 0, 0, 1);
        //rows[6].GetComponent<RowManager>().setColorToALL(1, 0, 0, 1);
        //rows[7].GetComponent<RowManager>().setColorToALL(1, 0, 0, 1);
        

        
        
    }


    public void PlayerDown()
    {
        // For loop, finding the player that's down.
        //Debug.Log("PlayerDown");
        for (int i = 0; i < playerCoords.Count; i++)
        {
            if (!players[i].isActivePlayer())
            {
                int new_len;
                if (i == 0)
                {
                    player_steps[playerCoords.Count - 1] = player_steps[playerCoords.Count - 1] + player_steps[i] + 1;

                }
                else
                {
                    player_steps[i - 1] = player_steps[i - 1] + player_steps[i] + 1;
                }

                players.Remove(players[i]);
                playerCoords.RemoveAt(i);
                player_steps.RemoveAt(i);
                Debug.Log(players.Count);
            }
        }
        player_list_index = player_list_index % players.Count;
        Debug.Log(player_list_index);
    }

    public void PlayerSuccess()
    {
        player_list_index = (player_list_index + 1) % players.Count;

    }
    // // Update is called once per frame
    // void Update()
    // {
    //     
    // }
}
