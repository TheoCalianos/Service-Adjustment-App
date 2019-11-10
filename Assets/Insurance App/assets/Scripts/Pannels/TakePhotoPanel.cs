using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakePhotoPanel : MonoBehaviour, IPanel
{
  public RawImage photoTaken;
  public InputField photoNotes;
  public Text caseNumberText;

  public void OnEnable()
  {
    caseNumberText.text =  "CASE NUMBER " + UIManager.Instance.activeCase.CaseId;
  }
  public void ProcessInfo()
  {
      UIManager.Instance.OverviewPanel.gameObject.SetActive(true);
      Debug.LogError("ClientInfoPanel");
  }
}
