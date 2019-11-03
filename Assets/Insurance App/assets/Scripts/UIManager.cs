using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  private static UIManager _instance;
  public static UIManager Instance
  {
    get
    {
      if(_instance == null)
      {
        Debug.LogError("The UI Manager is NULL");
      }

      return _instance;
    }
  }
  public Case activeCase;
  public ClientInfoPanel clientInfoPanel;
  public GameObject borderPanel;
  public LocationPanel LocationPanel;
  private void Awake()
  {
    _instance = this;
  }

  public void CreateNewCase()
  {
    activeCase = new Case();
    int caseId = Random.Range(0,1000);
    string stringCaseID = caseId.ToString();
    activeCase.CaseId = stringCaseID;

    clientInfoPanel.gameObject.SetActive(true);
    borderPanel.gameObject.SetActive(true);
  }
}
