using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{

    public GameObject Player;
    

    //Pickup and Level Completion Logic
    public int currentPickups = 0;
    public int maxPickups = 10;
    public bool levelComplete = false;

    public Text pickupText;

    //Audio Proximity Logic
    public AudioSource[] audioSources;
    public float audioProximty = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        LevelCompleteCheck();
        UpdateGUI();
        PlayAudioSamples();
    }

    private void LevelCompleteCheck(){
        if (currentPickups >= maxPickups)
            levelComplete = true;
        else
            levelComplete = false;
    }

    public void UpdateGUI(){
        pickupText.text = "Pickups: " + currentPickups + "/" + maxPickups;
    }

    //Loop for playing audio - AudioSource based
    private void PlayAudioSamples(){
        for (int i = 0; i < audioSources.Length; i++){
            if (audioSources[i] != null){
                if(Vector3.Distance(Player.transform.position, audioSources[i].transform.position) <= audioProximty){
                    if(!audioSources[i].isPlaying){
                            audioSources[i].Play();
                    }
                    
                }
            }
        }
    }
}