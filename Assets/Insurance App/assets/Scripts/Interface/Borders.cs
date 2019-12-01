using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Borders : MonoBehaviour
{
  public void GoHome()
  {
    SceneManager.LoadScene(0);
    UIManager.Instance.couter = 0;
    UIManager.Instance.listObjects.Clear();
  }
  public void backButton()
  {
    UIManager.Instance.listObjects[UIManager.Instance.couter-1].SetActive(false);
    if(UIManager.Instance.couter > 0)
    {
      UIManager.Instance.couter --;
    }
    Debug.Log(UIManager.Instance.couter);
  }
  public void forwardButton()
  {
    Debug.Log(UIManager.Instance.couter);
    if (UIManager.Instance.couter < UIManager.Instance.listObjects.Count)
    {
      UIManager.Instance.listObjects[UIManager.Instance.couter].SetActive(true);
      UIManager.Instance.couter ++;
    }
  }
}
