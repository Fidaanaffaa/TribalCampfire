using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeManager : MonoBehaviour
{
     public SpriteRenderer sprite;
     [SerializeField] public Color defaultColor;
   
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void  setColor(double Red, double Green,double  Blue, double Alpha)
    {
        Debug.Log("Cube  setColor() ");
        sprite.color = new Color((float) Red, (float)Green, (float)Blue,(float) Alpha);

    }
    
    public void  setColorBackToDeafultColor()
    {
        Debug.Log("Cube setColorBackToDeafultColor() ");
        sprite.color = defaultColor;

    }
    
    
    public void  setDeafultColor(double Red, double Green,double  Blue, double Alpha)
    {
        Debug.Log("Cube setDeafultColor()");
        defaultColor = new Color((float) Red, (float)Green, (float)Blue,(float) Alpha);
        sprite.color = defaultColor;
    }
        
    
}
