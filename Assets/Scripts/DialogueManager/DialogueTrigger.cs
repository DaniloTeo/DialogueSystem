using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public GameObject player;
    public string path;
    
/*


For your objects to receive the OnTriggerEnter, at least one of them has to have the Is Trigger property checked and at least one of them has to have a Rigid Body. If neither of your objects is a Trigger, you can use OnCollisionEnter instead.

Once that's all set, you should check the Layers (not Tags) on your objects. To edit which Layers collide with each other, you can look at Edit -> Project Settings -> Physics.

By default Unity sets all layers to collide with all layers. That's a good works-by-default setup, but you may want to play with it to optimize later on.

*/

    private bool inTrigger = false; // debug - pq n ta setando pra true nunca?
    private bool dialogueLoaded = false;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("player: " + player.name);
        Debug.Log("ok");
        // Debug.Log(dialogueManager == null);
       if(dialogueManager == null){
           dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
       } 
    }

    private void OnTriggerEnter(Collider collision){
        if(collision.gameObject == player){
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider collision){
        if(collision.gameObject == player){
            inTrigger = false;
        }
    }

    private void runDialogue(bool keyTrigger){
        if(keyTrigger){
        Debug.Log("keyTrigger");
        Debug.Log("inTrigger: " + inTrigger);
            if(inTrigger && !dialogueLoaded){
                dialogueLoaded = dialogueManager.loadDialogue(path);
            }

            if(dialogueLoaded){
                dialogueLoaded = dialogueManager.printLine();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        runDialogue(Input.GetMouseButtonDown(0));
    }
}
