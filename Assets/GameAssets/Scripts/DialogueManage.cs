using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
 
public class DialogueManage : MonoBehaviour
{
    //class
    private CameraShake cameraShake;
    
    //singelton
    public static DialogueManage Instance;

    //dialouge
    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;

    public float typingSpeed = 0.2f;

    public Animator animator;
    public Animator TrueAnswerPlatformAnimator;
    public Animator FalseAnswerPlatformAnimator;
    

    //mathf
    private int correctAnswer;
    public TMP_InputField mathInputField;
    public Button submitAnswerButton;
    public Button ContiuneButton;
    public Button RejectButton;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLine>();
        submitAnswerButton.onClick.AddListener(CheckMathAnswer);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;

        animator.Play("StartDialogue");

        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            AskMathQuestion();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        //characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        animator.Play("StopDialogue");
    }
    
    void AskMathQuestion()
    {
        int num1 = Random.Range(1, 11);
        int num2 = Random.Range(1, 11);
        
        correctAnswer = num1 + num2;
        
        dialogueArea.text = $"Hadi biraz matematik yapalım! {num1} + {num2} = ?";
        
        mathInputField.gameObject.SetActive(true);
        submitAnswerButton.gameObject.SetActive(true);
        ContiuneButton.gameObject.SetActive(false);
        RejectButton.gameObject.SetActive(false);
    }
    
    void CheckMathAnswer()
    {
        string userInput = mathInputField.text;
        
        if (int.TryParse(userInput, out int userAnswer))
        {
            if (userAnswer == correctAnswer)
            {
                Debug.Log("Doğru!");
                TrueAnswerPlatformAnimator.SetTrigger("CorrectAnswer");
                StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(0.3f, 0.2f));
            }
            else
            {
                Debug.Log("Yanlış!");
                FalseAnswerPlatformAnimator.SetTrigger("WrongAnswer");
                StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(0.3f, 0.2f));
                //burada eger yanlis bilirse daha da zorlassin
                
            }
        }
        else
        {
            Debug.Log("Lütfen geçerli bir sayı girin.");
        }
        
        mathInputField.gameObject.SetActive(false);
        submitAnswerButton.gameObject.SetActive(false);
        ContiuneButton.gameObject.SetActive(true);
        RejectButton.gameObject.SetActive(true);
        
        EndDialogue();
    }
}