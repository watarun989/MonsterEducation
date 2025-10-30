using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class Ending1 : MonoBehaviour
{
    public MovieTextData movieTextData; 
    public TextMeshProUGUI talkText; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndingTalk1()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EndingTalk1(){
        for(int i = 0;i < movieTextData.talkDatas.Length;i++){
            talkText.text = movieTextData.talkDatas[i].talk; 
            
            while(!Input.GetKeyDown(KeyCode.Space)){
                yield return null; 
            }

            yield return new WaitForSeconds(0.1f); 
        }

        yield return new WaitForSeconds(5.0f); 

        SceneManager.LoadScene("Main"); 
    }
}
