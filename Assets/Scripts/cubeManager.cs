using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeManager : MonoBehaviour
{
    protected Color GREEN = new Color(0,1,0,1);
    protected Color WHITE = new Color(1,1,1,1);
    protected Color YELLOW = new Color(1,1,0,1);
    public SpriteRenderer sprite;
    [SerializeField] public Color defaultColor;
    protected bool isPlayer = false;
    private Player player;
    void Awake()
    {
        foreach (var playa in GetComponentsInChildren<Player>()) // Adds all the children of the cube (only one)
        {
            player = playa;
        }
        sprite = GetComponent<SpriteRenderer>();
    }

    public void  setColor(double Red, double Green,double  Blue, double Alpha)
    {
        Color temp = new Color((float)Red, (float)Green, (float)Blue, (float)Alpha);
        if (isPlayer && temp == GREEN) // Indicates the player that s/he is vulnerable
        {
            player.PlayerVunerable();
        }
        if (!isPlayer && temp == GREEN)
        {
            sprite.color = new Color(YELLOW[0], YELLOW[1], YELLOW[2], YELLOW[3]); // If not player
            return;
        }
        sprite.color = new Color((float) Red, (float)Green, (float)Blue,(float) Alpha);

    }
    
    public void  setColorBackToDeafultColor()
    {
        // Debug.Log("Cube setColorBackToDeafultColor() ");
        if (isPlayer)
        {
            player.PlayerNotVunerable();
        }
        sprite.color = defaultColor;

    }
    
    
    public void  setDeafultColor(double Red, double Green,double  Blue, double Alpha)
    {
        // Debug.Log("Cube setDeafultColor()");
        defaultColor = new Color((float) Red, (float)Green, (float)Blue,(float) Alpha);
        sprite.color = defaultColor;
    }
    
    public bool isActivePlayer()
    {
        return isPlayer;
    }
    
}
