using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialogue : MonoBehaviour
{
    //konuskan karakterin sahneye gelmesi icin
    public bool hasDeadOnce = false;

    //animator
    [SerializeField] public Animator CharacterAnimator;

    [SerializeField] public GameObject character;
    public bool hasAnimationPlayed = false;
    public int characterCounter = 0;
    
    
}
