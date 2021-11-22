using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class DialogueManager : MonoBehaviour
{
    public Text textDisplay;
    private JsonData dialogue;
    private int index;
    private string speaker;
    private bool inDialogue;

    public bool loadDialogue(string path){
        if(!inDialogue){
            index = 0;
            var jsonTextFile = Resources.Load<TextAsset>("Dialogues/" + path);
            dialogue = JsonMapper.ToObject(jsonTextFile.text);
            inDialogue = true;
            return true;
        }

        return false;
    }

    public bool printLine(){
        if(inDialogue){
            JsonData line  = dialogue[index];
            if(line[0].ToString() == "EOD"){
                inDialogue = false;
                textDisplay.text = "";
                return false; 
            }
            
            foreach(JsonData key in line.Keys){
                speaker = key.ToString();
            }

            textDisplay.text = speaker + ": " + line[0].ToString();
            index++;
        }
        return true;
    }
}
