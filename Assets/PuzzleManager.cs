using System.Collections;
using System.Collections.Generic;
using PowerScript;
using PowerTools.Quest;
using UnityEditor;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject PiecesHolder;
    public GameObject[] Pieces;


    [SerializeField]
    public GameObject PopItem_key;  //make object available

    [SerializeField]
    public int totalPieces =0;

    [SerializeField]
    public int numCompleted =0;


    // Start is called before the first frame update
    void Start()
    {   
        //Make count of how many pieces we drag into the scen as "pieces" in the holder
        totalPieces=PiecesHolder.transform.childCount;

        Pieces= new GameObject[totalPieces]; // will autofill on play

        for( int i=0; i <Pieces.Length; i++)
        {
            Pieces[i]= PiecesHolder.transform.GetChild(i).gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {

        //Check win condition
        if (numCompleted>=totalPieces)
        {
            QuestScript.Globals.m_runePuzzleFinishedBedRoom = true;
            //C.Player.Room = R.Bedroom;
            for( int i=0; i <Pieces.Length; i++)
            {
                Pieces[i].SetActive(false); //should hide every rotating piece and showing background, the correct whole image
            }
            
                ; //key reward appear at Pop layer
        }
        else
        {
            PopItem_key.SetActive(false); //revert automatically hide key
        }
            
    }
}
