using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] public GameObject row1;  
    [SerializeField] public GameObject row2;  
    [SerializeField] public GameObject row3;  
    [SerializeField] public GameObject row4;  
    [SerializeField] public GameObject row5;  
    [SerializeField] public GameObject row6;  
    [SerializeField] public GameObject row7;  
    [SerializeField] public GameObject row8;  

    [SerializeField] public GameObject[]  rows;

    public HashSet<Tuple<int, int>> playersCoords = new HashSet<Tuple<int, int>> 
        {new Tuple<int, int>(0, 0),
        new Tuple<int, int>(0, 7),
        new Tuple<int, int>(7, 7),
        new Tuple<int, int>(7,0)};

    public (int , int )[] squareCoords = new (int, int)[] {(0, 0), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7), (1, 7), (2, 7), (3, 7), (4, 7), (5, 7), (6, 7), (7, 7), (7, 6), (7, 5), (7, 4), (7, 3), (7, 2), (7, 1), (7, 0), (6, 0), (5, 0), (4, 0), (3, 0), (2, 0), (1, 0)};
    private int currentSquareIdx;
    private double nextUpdate=1;
    
    // Start is called before the first frame update
    void Awake()
    {
        currentSquareIdx = 0;
        rows = new GameObject[8] {row1, row2, row3, row4, row5, row6, row7, row8};
        initPlayersPositionsColor();

        //colorAllCube(); // mostly for testing popurses, color everything in red, 
    }
    
    // Update is called once per frame
    void Update(){
     
        // If the next update is reached
        if(Time.time>=nextUpdate){
            Debug.Log(Time.time+">="+nextUpdate);
            // Change the next update (current second+0.5)
            nextUpdate=(double) Mathf.FloorToInt(Time.time) + 1;
            // Call your fonction
            Next();
        }
     
    }


    public void Next()
    // To Be used as update by the game Manager 
    {
        int lastIndex = currentSquareIdx; 
            
        currentSquareIdx = (currentSquareIdx + 1) % squareCoords.Length;
        Debug.Log("Calling Next");
        (int x, int y) =  squareCoords[currentSquareIdx];
        
        Debug.Log(x.ToString()+","+y.ToString());
        
        // todo add if is player than green
        if (playersCoords.Contains(new Tuple<int, int>(x,y)))
        {
            rows[x].GetComponent<RowManager>().setColorToBatch(new int[]{y}, 0, 1, 0, 1);
        }
        else
        {
            rows[x].GetComponent<RowManager>().setColorToBatch(new int[]{y}, 1, 1, 0, 1);
        }
        
        
        //rows[x].GetComponent<RowManager>().setColorToBatch(new int[]{y}, 1, 1, 0, 1);
        
        
        (x, y) =  squareCoords[lastIndex];
        rows[x].GetComponent<RowManager>().setColorBaclToDeafultColorTosBatch(new int[]{y});
        
    }

    public void initPlayersPositionsColor()
    // currently support only 4 players. later we will figure it out
    {
        rows[0].GetComponent<RowManager>().setDeafultColorToBatch(new int[]{0,7}, 1, 0, 0, 1);
        
        rows[7].GetComponent<RowManager>().setDeafultColorToBatch(new int[]{0,7}, 1, 0, 0, 1);
        
        
    }
    
    
    public void colorAllCube()
        // currently support only 4 players. later we will figure it out
    {
        rows[0].GetComponent<RowManager>().setColorToALL(1, 0, 0, 1);
        rows[1].GetComponent<RowManager>().setColorToALL(1, 0, 0, 1);
        rows[2].GetComponent<RowManager>().setColorToALL(1, 0, 0, 1);
        rows[3].GetComponent<RowManager>().setColorToALL(1, 0, 0, 1);
        rows[4].GetComponent<RowManager>().setColorToALL(1, 0, 0, 1);
        rows[5].GetComponent<RowManager>().setColorToALL(1, 0, 0, 1);
        rows[6].GetComponent<RowManager>().setColorToALL(1, 0, 0, 1);
        rows[7].GetComponent<RowManager>().setColorToALL(1, 0, 0, 1);
        
        
        
    }
    
    // // Update is called once per frame
    // void Update()
    // {
    //     
    // }
}
