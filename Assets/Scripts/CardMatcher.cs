using System.Collections;
using UnityEngine;

public class CardMatcher : MonoBehaviour
{
    private Card _firstSelectedCard = null;
    private Card _secondSelectedCard = null;

    private bool _canSelect = true;

    public void SelectCard(Card card)
    {
        if(!_canSelect)
            return;

        card.Switch();

        if(_firstSelectedCard == null)
        {
            _firstSelectedCard = card;
        }
        else
        {
            if(card != _firstSelectedCard)
            {
                _secondSelectedCard = card;
                CheckMatch();
            }
        }
    }

    private void CheckMatch()
    {
        _canSelect = false;

        if (_firstSelectedCard.GetIcon() == _secondSelectedCard.GetIcon())
        {
            _firstSelectedCard.Scuicide();
            _secondSelectedCard.Scuicide();
        }
        else
        {
            _firstSelectedCard.Switch();
            _secondSelectedCard.Switch();
        }

        SetCardsNull();
        StartCoroutine(OnSelecting());
    }

    private void SetCardsNull()
    {
        _firstSelectedCard = null;
        _secondSelectedCard = null;
    }

    private IEnumerator OnSelecting()
    {
        yield return new WaitForSeconds(1);
        _canSelect = true;
    }
}

