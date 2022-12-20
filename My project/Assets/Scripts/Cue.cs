using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cue : MonoBehaviour
{
    // [SerializeField] private GameObject pivot;
    [SerializeField] private Vector3 finalDestination = new Vector3(-0.003922999f, -3.831109f, -0.1788127f);
    [SerializeField] private Vector3 StartPosition = new Vector3(7.1f, -3.831109f);

    [SerializeField] private float duration = 2; // 3 Beats
    private float timeElapsed = 0;
    private float beats = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = StartPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MovePoint(float numBeat)
    {
        if (beats < duration) // duration
        {
            transform.position = Vector3.Lerp(StartPosition, finalDestination, (beats + timeElapsed) / duration);

            if (numBeat % 1 < timeElapsed)
            {
                beats += 1;
            }
            timeElapsed = (numBeat%1);
        }
        else
        {
            transform.position = StartPosition;
            timeElapsed = 0;
            beats = 0;
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }

    }

    public void changeStartPosition(Vector3 newStart)
    {
        StartPosition = newStart;
        transform.position = newStart;
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Indicator")
        {
            //Debug.Log("Yes!");
        }
        //Debug.Log("Trigger");
    }
}
