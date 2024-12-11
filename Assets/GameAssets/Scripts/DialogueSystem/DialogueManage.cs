using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class DialogueManage : MonoBehaviour
{
    //class
    private CameraShake cameraShake;
    private AudioManager _audioManager;
    
    //singelton
    public static DialogueManage Instance;

    //dialouge
    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;

    public float typingSpeed = 0.0010f;//suanlik kullanılmıyor

    public Animator animator;
    public Animator TrueAnswerPlatformAnimator;
    public Animator FalseAnswerPlatformAnimator;
    public Animator CharacterAnimator;
    
    //check slove question
    public bool hasSloveQuestion = false;
    
    //mathf
    private int correctAnswer;
    public TMP_InputField mathInputField;
    public Button submitAnswerButton;
    public Button ContiuneButton;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLine>();
        submitAnswerButton.onClick.AddListener(CheckMathAnswer);
    }

    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
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
            yield return new WaitForSeconds(0.001f);
        }
    }

    public void EndDialogue()
    {
        isDialogueActive = false;
        animator.Play("StopDialogue");
    }
    
    void AskMathQuestion()
    {
        // Rastgele bir yuvarlama türü seçiyoruz (0 = onluğa, 1 = yüzlüğe)
        int roundingType = Random.Range(0, 2);

        float randomFloat;

        if (roundingType == 0)
        {
            // Onluğa yuvarlama (10 ile 100 arasında)
            randomFloat = Random.Range(10.5f, 99.9f); // 100'den küçük
            int roundedAnswer = Mathf.RoundToInt(randomFloat / 10) * 10; // Onluğa yuvarlama işlemi
            correctAnswer = roundedAnswer;

            // Kullanıcıya soru
            dialogueArea.text = $"{Mathf.Floor(randomFloat)} Sayısını En Yakın Onluğa yuvarlayın\nEn yakın onlu nedir?";
        }
        else
        {
            // Yüzlüğe yuvarlama (100 ile 1000 arasında)
            randomFloat = Random.Range(100.5f, 999.9f); // 100 ile 1000 arasında
            int roundedAnswer = Mathf.RoundToInt(randomFloat / 100) * 100; // Yüzlüğe yuvarlama işlemi
            correctAnswer = roundedAnswer;

            // Kullanıcıya soru
            dialogueArea.text = $"{Mathf.Floor(randomFloat)} Sayısını En Yakın Yüzlüğe yuvarlayın\nEn yakın yüzlük nedir?";
        }

        // Giriş alanını ve butonları aktif et
        mathInputField.gameObject.SetActive(true);
        submitAnswerButton.gameObject.SetActive(true);
        ContiuneButton.gameObject.SetActive(false);
    }





    void CheckMathAnswer()
    {
        string userInput = mathInputField.text;
        
        if (string.IsNullOrEmpty(userInput))
        {
            Debug.Log("Lütfen bir cevap girin.");
            return;
        }
        
        if (int.TryParse(userInput, out int userAnswer))
        {
            if (userAnswer == correctAnswer)
            {
                Debug.Log("Doğru!");
                TrueAnswerPlatformAnimator.SetTrigger("CorrectAnswer");
                StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(0.3f, 0.2f));
                CharacterAnimator.SetBool("CharacterCome", false);
                CharacterAnimator.SetBool("CharacterExit", true);
                hasSloveQuestion = true;
                
                //audio
                _audioManager.Play(SoundType.TrueAnswerQuestion);
            }
            
            else
            {
                Debug.Log("Yanlış!");
                FalseAnswerPlatformAnimator.SetTrigger("WrongAnswer");
                StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(0.3f, 0.2f));
                CharacterAnimator.SetBool("CharacterCome", false);
                CharacterAnimator.SetBool("CharacterExit", true);
                hasSloveQuestion = true;

                //audio
                _audioManager.Play(SoundType.FalseAnswerQuestion);
            }

        }

        else
        {
            Debug.Log("InputField is Null");    
            return;
        }
        
        mathInputField.gameObject.SetActive(false);
        submitAnswerButton.gameObject.SetActive(false);
        ContiuneButton.gameObject.SetActive(true);
        
        EndDialogue();
    }
}