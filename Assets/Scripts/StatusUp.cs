using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class StatusUp : MonoBehaviour
{
    public TextMeshProUGUI mainText; 
    public TalkDatas statusUpTalk; 
    public Animator monsterAnimator; 
    public Animator dummyAnimator; 
    public string statusText; 

    // Start is called before the first frame update
    void Start()
    {
        mainText.text = ""; 
        monsterAnimator.SetBool("Idle",true); 
        StartCoroutine(StatusUpStart()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StatusUpStart(){
        Debug.Log("Action"); 
        monsterAnimator.SetTrigger("Action"); 
        // yield return new WaitUntil(() => monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack")); 
        // yield return new WaitUntil(() => !monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack")); 
        yield return new WaitForSeconds(3); 
        mainText.text = statusUpTalk.datas[0].text + " " + statusText + " " + statusUpTalk.datas[1].text; 
        Debug.Log("AnimeEnd"); 
    }
}
