using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text TheText;
    public float TypingSpeed;
    public string Sentence;

    IEnumerator Type()
    {
        foreach (var letters in Sentence.ToCharArray())
        {
            TheText.text += letters;
            yield return new WaitForSeconds(TypingSpeed);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
