using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowManager : MonoBehaviour
{
     [SerializeField] public GameObject cube0;  
     [SerializeField] public GameObject cube1;  
     [SerializeField] public GameObject cube2;  
     [SerializeField] public GameObject cube3;  
     [SerializeField] public GameObject cube4;  
     [SerializeField] public GameObject cube5;  
     [SerializeField] public GameObject cube6;  
     [SerializeField] public GameObject cube7;

     [SerializeField] public GameObject[]  cubes ;

    // Start is called before the first frame update
    
    void Awake()
    {
        cubes = new GameObject[8] {cube0,cube1,cube2,cube3,cube4,cube5,cube6,cube7};
    }

    public void setColorTo(int index, double Red, double Green, double Blue, double Alpha)
    /// Will set the a color to the indexth cube in the row
    {
        cubes = new GameObject[8] {cube0,cube1,cube2,cube3,cube4,cube5,cube6,cube7}; /// currently this is an ugly bug fix, ither wise it is not init.

        
        Debug.Log("setColorTo was called!");

        cubes[index].GetComponent<cubeManager>().setColor(Red,Green,Blue,Alpha);
    }
    
    public void setColorToALL(double Red, double Green, double Blue, double Alpha)
    /// Will set the same colore to all cubes in row
    {
        cubes = new GameObject[8] {cube0,cube1,cube2,cube3,cube4,cube5,cube6,cube7}; /// currently this is an ugly bug fix, ither wise it is not init.

        Debug.Log("setColorToALL was called!");
        foreach (var cubics in cubes)
        { 
            cubics.GetComponent<cubeManager>().setColor(Red,Green,Blue,Alpha);
        }
    }
    
    public void setColorToBatch(int[] indexes ,double Red, double Green, double Blue, double Alpha)
        /// Will set the same color to all the indexs cubes in the row 
    {
        cubes = new GameObject[8] {cube0,cube1,cube2,cube3,cube4,cube5,cube6,cube7}; /// currently this is an ugly bug fix, ither wise it is not init.
        Debug.Log("setColorToBatch was called!");

        foreach (var idx in indexes)
        { 
            cubes[idx].GetComponent<cubeManager>().setColor(Red, Green, Blue, Alpha);
        }
    }
    
    
    public void setDeafultColorToBatch(int[] indexes ,double Red, double Green, double Blue, double Alpha)
        /// Will set the same color to all the indexs cubes in the row 
    {
        
        cubes = new GameObject[8] {cube0,cube1,cube2,cube3,cube4,cube5,cube6,cube7}; /// currently this is an ugly bug fix, ither wise it is not init.
        Debug.Log("setColorToBatch was called!");

        foreach (var idx in indexes)
        { 
            cubes[idx].GetComponent<cubeManager>().setDeafultColor(Red, Green, Blue, Alpha);
        }
    }
    
    
    public void setColorBaclToDeafultColorTosBatch(int[] indexes )
        /// Will set the same color to all the indexs cubes in the row 
    {
        cubes = new GameObject[8] {cube0,cube1,cube2,cube3,cube4,cube5,cube6,cube7}; /// currently this is an ugly bug fix, ither wise it is not init.
        Debug.Log("setColorToBatch was called!");

        foreach (var idx in indexes)
        { 
            cubes[idx].GetComponent<cubeManager>().setColorBackToDeafultColor();
        }
    }
}
