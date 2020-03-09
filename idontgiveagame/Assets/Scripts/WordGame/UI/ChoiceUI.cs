using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using idgag.GameState;
public class ChoiceUI : MonoBehaviour
{
    int index;

    public void SetOptions(List<string> options, int index) {
        this.index = index;
        Transform dropdown = gameObject.transform.Find("Dropdown");
        TMP_Dropdown dropdownScript = dropdown.gameObject.GetComponent<TMPro.TMP_Dropdown>();

        foreach (string option in options) {
            dropdownScript.options.Add(new TMP_Dropdown.OptionData(option));
        }

        dropdownScript.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdownScript);
        });
    }

    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(TMP_Dropdown change) {
        string key = change.options.ElementAt(change.value).text;

        GameState GSscript = GameState.Singleton.GetComponent<GameState>();
        GSscript.AlterPRStatements(index, key);
    }
}
