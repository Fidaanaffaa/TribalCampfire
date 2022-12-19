using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueManager : MonoBehaviour
{
    [SerializeField] private Cue cue;
    private float _currBeat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBeat(float currBeat)
    {
        if (currBeat < _currBeat)
        {
            cue.gameObject.SetActive(true);
        }
        
        if (cue.gameObject.activeSelf)
        {
            cue.MovePoint(currBeat);
        }
    }

    public void SetBeat(float currBeat)
    {
        _currBeat = currBeat;
    }
}
