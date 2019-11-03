using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClientInfoPanel : MonoBehaviour, IPanel
{
  public Text caseNumberText;
  public InputField firstName, lastName;

  public void OnEnable()
  {
    caseNumberText.text = "CASE NUMBER IS " + UIManager.Instance.activeCase.CaseId;
  }

  public void ProcessInfo()
  {
    if(string.IsNullOrEmpty(firstName.text))
    {
      firstName.placeholder.GetComponent<Text>().text = "First Name Needed";
      firstName.placeholder.GetComponent<Text>().color = Color.red;
    }
    else if(string.IsNullOrEmpty(lastName.text))
    {
      lastName.placeholder.GetComponent<Text>().text = "Last Name Needed";
      lastName.placeholder.GetComponent<Text>().color = Color.red;
    }
    else
    {
      UIManager.Instance.activeCase.name = firstName.text + " " + lastName.text;
      UIManager.Instance.LocationPanel.gameObject.SetActive(true);
    }
  }
}
