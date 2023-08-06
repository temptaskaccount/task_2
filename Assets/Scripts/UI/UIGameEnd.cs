using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameEnd : MonoBehaviour
{
    public GameObject SuccesPanel,FailPanel;
    public void Initilaize(bool IsSucces)
    {
        StartCoroutine(WaitABit());
        IEnumerator WaitABit()
        {
                
            yield return new WaitForSeconds(1f);
            if (IsSucces)
            {
                SuccesPanel.gameObject.SetActive(true);
                
            }
            else
            {
                FailPanel.gameObject.SetActive(true);
            }
        }
    }


    public void OnClickNextLevel()
    {


        DataManager.LevelIndex++;
        GamePlayManager.instance.LevelStart();
        SuccesPanel.gameObject.SetActive(false);
        
    }

    public void OnClickFail()
    {
        SceneManager.LoadScene(0);
    }
}
