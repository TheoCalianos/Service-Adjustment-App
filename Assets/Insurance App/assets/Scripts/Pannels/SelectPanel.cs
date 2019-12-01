using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPanel : MonoBehaviour, IPanel
{
  public Text informationText;
  public void OnEnable()
  {
    informationText.text = UIManager.Instance.activeCase.name + "\nCase Number: "+ UIManager.Instance.activeCase.CaseId;
  }
  public void ProcessInfo()
  {
    UIManager.Instance.OverviewPanel.gameObject.SetActive(true);
    if(UIManager.Instance.listObjects.Contains(UIManager.Instance.OverviewPanel.gameObject))
    {}
    else
    {
      UIManager.Instance.listObjects.Add(UIManager.Instance.OverviewPanel.gameObject);
      UIManager.Instance.couter ++;
    }
  }
}
