using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    //[SerializeField] private GameObject indicator;

    //[SerializeField] private SheepController player;

    //[SerializeField] private ShootingTowersManager towers;

    //[SerializeField] private SceneManager sceneManager;

    //private float waitTimeTowers = -10;

    //private float waitTimeSheep = -10;

    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    [SerializeField] private float songBpm;

    //The number of seconds for each song beat
    [SerializeField] private float secPerBeat;

    //Current song position, in seconds
    [SerializeField] private float songPosition;

    //Current song position, in beats
    [SerializeField] private float songPositionInBeats;

    //How many seconds have passed since the song started
    [SerializeField] private float dspSongTime;

    //The offset to the first beat of the song in seconds
    [SerializeField] private float firstBeatOffset = 0;

    //an AudioSource attached to this GameObject that will play the music.
    [SerializeField] private AudioSource musicSource;



    
    // Start is called before the first frame update
    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;

        float numBeat = songPositionInBeats % 4; // For 4/4 beats




        //sceneManager.UpdateBeat(numBeat);

        //if (((0.7f <= numBeat && numBeat <= 1.3f) || (2.7f <= numBeat && numBeat <= 3.3f)) && waitTimeSheep < songPositionInBeats - 1) 
        //{
        //    //indicator.SetActive(true);
        //    player.OkayMove();
        //    waitTimeSheep = songPositionInBeats;
        //}
        //else if ((0f <= numBeat && numBeat <= 0.3f) || (2f <= numBeat && numBeat <= 2.3f))
        //{
        //    //indicator.SetActive(false);
        //    player.NotOkayMove();
        //}
        //if (towers != null)
        //{
        //    if (((0f <= numBeat && numBeat <= 0.3f) && waitTimeTowers < songPositionInBeats - 1))
        //    {
        //        towers.Shoot();
        //        waitTimeTowers = songPositionInBeats;
        //    }
        //    else if (waitTimeTowers < songPositionInBeats - 1)
        //    {
        //        towers.LoadShot();
        //    }
        //}
       
    }

    public void restartMusic()
    {

        musicSource.Stop();

        dspSongTime = (float)AudioSettings.dspTime;

        musicSource.Play();
    }

}
