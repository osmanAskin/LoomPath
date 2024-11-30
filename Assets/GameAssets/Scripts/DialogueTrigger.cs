using System;
using System.Collections.Generic;
using UnityEngine;
 
[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}
 
[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}
 
[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}
 
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManage dialogueManage;

    private void Start()
    {
        dialogueManage = FindObjectOfType<DialogueManage>();
    }

    public void TriggerDialogue()
    {
        DialogueManage.Instance.StartDialogue(dialogue);
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (dialogueManage.hasSloveQuestion == false)//kullanicinin dogru veya yanlis cevap verdigine degisen bir degisken ata
            {
                TriggerDialogue();    
            }
            
        }
    }
}