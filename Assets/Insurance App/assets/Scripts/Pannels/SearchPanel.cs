using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchPanel : MonoBehaviour, IPanel
{
  public SelectPanel SelectPanel;
  public InputField caseNumberInput;
  public void ProcessInfo()
  {
    AWSManager.Instance.GetList(caseNumberInput.text, () =>
    {
      SelectPanel.gameObject.SetActive(true);
      if(UIManager.Instance.listObjects.Contains(SelectPanel.gameObject)){}
      else
      {
        UIManager.Instance.listObjects.Add(SelectPanel.gameObject);
        UIManager.Instance.couter ++;
      }
    });
  }
}
