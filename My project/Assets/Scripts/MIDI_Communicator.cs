using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Midi;

public class MIDI_Communicator : MonoBehaviour
{
    private InputDevice LaunchPadIn;
    private OutputDevice LaunchPadOut;
    private Clock clock = new Clock(120);
    bool trying = false;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(OutputDevice.InstalledDevices);
        //Debug.Log(InputDevice.InstalledDevices);
        //foreach (InputDevice device in InputDevice.InstalledDevices)
        //{
        //    Debug.Log("Input Device: " + device.Name);
        //    if (device.Name == "LPProMK3 MIDI")
        //    {
        //        LaunchPadIn = device;
        //    }
        //}
        //foreach (OutputDevice device in OutputDevice.InstalledDevices)
        //{
        //    Debug.Log("OutputDevice: "+device.Name);
        //    if (device.Name == "LPProMK3 MIDI")
        //    {
        //        LaunchPadOut = device;
        //    }
        //}
        //Debug.Log(LaunchPadIn.Name);
        //Debug.Log(LaunchPadOut.Name);
        //LaunchPadIn.Open();
        //LaunchPadIn.StartReceiving(clock);

    }

    // Update is called once per frame
    void Update()
    {

    }
}

