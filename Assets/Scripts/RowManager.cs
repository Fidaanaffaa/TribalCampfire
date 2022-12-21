using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowManager : MonoBehaviour
{
     //[SerializeField] public GameObject cube0;  
     //[SerializeField] public GameObject cube1;  
     //[SerializeField] public GameObject cube2;  
     //[SerializeField] public GameObject cube3;  
     //[SerializeField] public GameObject cube4;  
     //[SerializeField] public GameObject cube5;  
     //[SerializeField] public GameObject cube6;  
     //[SerializeField] public GameObject cube7;

     //[SerializeField] public GameObject[]  cubes2;
     [SerializeField] public List<cubeManager> cubes;


    // Start is called before the first frame update

    void Awake()
    {
        foreach (var cube in GetComponentsInChildren<cubeManager>()) // Adds all the children of the Row (only 8, not the grandchildren)
        {
            cubes.Add(cube);
        }
    }

    public void setColorTo(int index, double Red, double Green, double Blue, double Alpha)
    /// Will set the a color to the indexth cube in the row
    {
        // Debug.Log("setColorTo was called!");

        cubes[index].setColor(Red,Green,Blue,Alpha);
    }
    
    public void setColorToALL(double Red, double Green, double Blue, double Alpha)
    /// Will set the same colore to all cubes in row
    {

        // Debug.Log("setColorToALL was called!");
        foreach (var cubics in cubes)
        { 
            cubics.setColor(Red,Green,Blue,Alpha);
        }
    }
    
    public void setColorToBatch(int[] indexes ,double Red, double Green, double Blue, double Alpha)
        /// Will set the same color to all the indexs cubes in the row 
    {
        // Debug.Log("setColorToBatch was called!");

        foreach (var idx in indexes)
        { 
            cubes[idx].setColor(Red, Green, Blue, Alpha);
        }
    }
    
    
    public void setDeafultColorToBatch(int[] indexes ,double Red, double Green, double Blue, double Alpha)
        /// Will set the same color to all the indexs cubes in the row 
    {
        
        // Debug.Log("setColorToBatch was called!");

        foreach (var idx in indexes)
        { 
            cubes[idx].setDeafultColor(Red, Green, Blue, Alpha);
        }
    }
    
    
    public void setColorBaclToDeafultColorTosBatch(int[] indexes )
        /// Will set the same color to all the indexs cubes in the row 
    {
        // Debug.Log("setColorToBatch was called!");

        foreach (var idx in indexes)
        { 
            cubes[idx].setColorBackToDeafultColor();
        }
    }
}
