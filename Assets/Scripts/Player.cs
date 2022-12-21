using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : cubeManager
{
    [SerializeField] private UnityEngine.KeyCode inputKey;
    [SerializeField] private BoardManager OurBoard;
    private bool pressed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        isPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(inputKey) && isPlayer) // Added this to fix a bug
        {
            if(sprite.color == GREEN && isPlayer)
            {
                pressed = false;
            }
            else
            {
                PlayerEliminated();
            }
        }

    }

    public void PlayerVunerable()
    {
        pressed = true;
    }

    public void PlayerNotVunerable()
    {
        if (pressed)
        {
            PlayerEliminated();
        }
    }
    void PlayerEliminated()
    {
        isPlayer = false;
        setDeafultColor(WHITE[0], WHITE[1], WHITE[2], WHITE[3]);
        setColor(WHITE[0], WHITE[1], WHITE[2], WHITE[3]);
        OurBoard.PlayerDown();
        // TODO - Add message to board
    }
}
