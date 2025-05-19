using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image _icon;
    private bool _isSwitched = false;

    private CardMatcher _matcher;

    private Image _parentImage;

    public void Initialize(Sprite icon, CardMatcher matcher)
    {
        _icon.sprite = icon;
        _matcher = matcher;
        _parentImage = _icon.transform.parent.GetComponent<Image>();    
    }

    public void SelectCard()
    {
        _matcher.SelectCard(this);
    }

    public string GetIcon()
    {
        return _icon.sprite.name;
    }

    public void Scuicide()
    {
        StartCoroutine(Killing());
    }

    public void Switch()
    {
        _isSwitched = !_isSwitched;

        if (_isSwitched == false)
            StartCoroutine(SetOff());
        else
            _icon.transform.parent.gameObject.SetActive(_isSwitched);
    }

    private IEnumerator Killing()
    {
        _parentImage.color = new Color(0.8627451f, 0.9843137f, 0.854902f);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private IEnumerator SetOff()
    {
        _parentImage.color = new Color(0.9843137f, 0.854902f, 0.9058824f);
        yield return new WaitForSeconds(1f);
        _icon.transform.parent.gameObject.SetActive(false);
        _parentImage.color = new Color(1, 1, 1);
    }

}
