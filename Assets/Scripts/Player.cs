using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : cubeManager
{
    [SerializeField] private UnityEngine.KeyCode inputKey;

    
    // Start is called before the first frame update
    void Start()
    {
        isPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(inputKey))
        {
            if(sprite.color == GREEN && isPlayer)
            {
                Debug.Log("Success!");
            }
            else
            {
                isPlayer = false;
                setDeafultColor(WHITE[0], WHITE[1], WHITE[2], WHITE[3]);
                setColor(WHITE[0], WHITE[1], WHITE[2], WHITE[3]);
            }
        }

    }
}
