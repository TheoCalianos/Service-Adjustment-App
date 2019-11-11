using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class OverviewPanel : MonoBehaviour, IPanel
{
  public Text caseNumberTitle;
  public Text nameTitle;
  public Text dateTitle;
  public Text location;
  public Text locationNotes;
  public RawImage photoTaken;
  public Text photoNotes;

  public void OnEnable()
  {
      caseNumberTitle.text = "CASE NUMBER " + UIManager.Instance.activeCase.CaseId;
      nameTitle.text = UIManager.Instance.activeCase.name;
      dateTitle.text = DateTime.Today.ToString();
      location.text = UIManager.Instance.activeCase.location;
      locationNotes.text = "LOCATION NOTES: \n" + UIManager.Instance.activeCase.locationNotes;
      photoTaken.texture = UIManager.Instance.activeCase.photoTaken;
      photoNotes.text = "PHOTO NOTES: \n" + UIManager.Instance.activeCase.photoNotes;

  }
  public void ProcessInfo()
  {

  }
}
