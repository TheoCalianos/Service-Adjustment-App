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
    });
  }
}
