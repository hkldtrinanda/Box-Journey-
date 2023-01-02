using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [Header("Counter Needed & Game Manager")]
    public int counterNeeded;
    public GameManager gameManager;
    
    [Header("Boolean")]
    public bool isDone;
    
    [Header("Door")]
    public GameObject doorOpen, doorClosed;
    
        void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    
        // Update is called once per frame
        void Update()
        {
            if (gameManager.counter == counterNeeded)
            {
                isDone = true;
                
                doorOpen.SetActive(true);
                doorClosed.SetActive(false);
            }
            else
            {
                isDone = false;
                doorOpen.SetActive(false);
                doorClosed.SetActive(true);
            }
        }
}
