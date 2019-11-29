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

  }
}
