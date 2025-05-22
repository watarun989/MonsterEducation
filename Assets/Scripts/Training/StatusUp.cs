using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class StatusUp : MonoBehaviour
{
    public TextMeshProUGUI mainText; 
    public TalkDatas statusUpTalk; 
    public Animator monsterAnimator; 
    public Animator dummyAnimator; 
    public string statusText; 
    bool statusUpCoroutine; 
    public string currentStatus; 
    public int statusUpPoint;
    public GameObject statusUpText; 

    // Start is called before the first frame update
    void Start()
    {
        statusUpText.SetActive(false); 
        mainText.text = ""; 
        monsterAnimator.SetBool("Idle",true); 
        StartCoroutine(StatusUpStart()); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && statusUpCoroutine){
            SceneManager.LoadScene("Main"); 
        }
    }

    IEnumerator StatusUpStart(){
        Debug.Log("Action"); 
        monsterAnimator.SetTrigger("Action"); 
        // yield return new WaitUntil(() => monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack")); 
        // yield return new WaitUntil(() => !monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack")); 
        yield return new WaitForSeconds(3); 

        switch(currentStatus){
            case "attack":
            StatusController.attackPoint += statusUpPoint; 
            break; 
            case "defence": 
            StatusController.defencePoint += statusUpPoint; 
            break; 
            case "speed": 
            StatusController.speedPoint += statusUpPoint; 
            break; 
        }

        StartCoroutine(StatusUpText()); 

        mainText.text = statusUpTalk.datas[0].text + " " + statusText + " " + statusUpTalk.datas[1].text; 
        Debug.Log("AnimeEnd"); 
        statusUpCoroutine = true; 
    }

    IEnumerator StatusUpText(){
        statusUpText.SetActive(true); 
        yield return new WaitForSeconds(3); 
        statusUpText.SetActive(false); 
    }
}
