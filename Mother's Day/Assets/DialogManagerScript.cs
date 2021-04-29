using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogManagerScript : MonoBehaviour
{
    public TextMeshProUGUI DickonsText;
    public TextMeshProUGUI DevilText;
    public string[] DickonsSentences;
    public string[] DevilSentences;
    public int DickonsIndex;
    public int DevilIndex;
    public float TypingSpeed;
    public SpriteRenderer DVSR;
    public SpriteRenderer DKSR;
    
    

    IEnumerator DickonsSpeaks()
    {
        foreach (var letters in DickonsSentences[DickonsIndex].ToCharArray())
        {
            DickonsText.text += letters;
            yield return new WaitForSeconds(TypingSpeed);
        }
    }


    IEnumerator DevilSpeaks()
    {
        foreach (var letters in DevilSentences[DevilIndex].ToCharArray())
        {
            DevilText.text += letters;
            yield return new WaitForSeconds(TypingSpeed);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(DevilSpeaks());
        //StartCoroutine(DickonsSpeaks());
        DVSR.enabled = false;
        DKSR.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        DickonsNextSentence();
        DevilNextSentence();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
            {
                SceneManager.LoadScene(1);
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
            {
                SceneManager.LoadScene(2);
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
            {
                SceneManager.LoadScene(3);
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
            {
                SceneManager.LoadScene(4);
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(4))
            {
                SceneManager.LoadScene(5);
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(6))
            {
                SceneManager.LoadScene(7);
            }

        }

    }

    public void DickonsNextSentence()
    {
        if (DickonsIndex <= DickonsSentences.Length - 1 && Input.GetKeyDown(KeyCode.Z))
        {
            DKSR.enabled = true;
            DVSR.enabled = false;
            DevilText.text = "";
            DickonsIndex++;
            DickonsText.text = "";
            StartCoroutine(DickonsSpeaks());
        }

    }

    public void DevilNextSentence()
    {
        if (DevilIndex < DevilSentences.Length - 1 && Input.GetKeyDown(KeyCode.X))
        {
            DVSR.enabled = true;
            DKSR.enabled = false;
            DickonsText.text = "";
            DevilIndex++;
            DevilText.text = "";
            StartCoroutine(DevilSpeaks());
        }

    }
}
