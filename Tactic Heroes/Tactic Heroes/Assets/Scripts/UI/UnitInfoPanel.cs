using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfoPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _image;
    public void SetUnit(BaseUnit unit)
    {
        if(unit == null)
        {            
            gameObject.SetActive(false);
            return;           
        }
        else
        {
            gameObject.SetActive(true);
            _name.text = unit.Name;
            //temporary
            _image.sprite = unit.GetComponent<SpriteRenderer>().sprite;

        }
    }
}
