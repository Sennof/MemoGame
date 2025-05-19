using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    [Tooltip("CardMatcher Instance to throw reference")]
    [SerializeField] private CardMatcher _cardMatcher;

    [Tooltip("Prefab of a match card")]
    [SerializeField] private GameObject _cardPrefab;
    [Tooltip("Folder used for storing objs")]
    [SerializeField] private Transform _folder;

    private CardsGenerator _cardsGenerator = new();
    private List<GameObject> _generatedCards = new();
    

    private void Awake()
    {
        GenerateCards();
    }

    private void GenerateCards()
    {
        int[] indexArray = _cardsGenerator.GenerateCardsArray("cards");
        Sprite[] icons = Resources.LoadAll<Sprite>("cards/");

        foreach(int index in indexArray)
        {
            GameObject genCard = Instantiate(_cardPrefab, _folder);
            genCard.GetComponent<Card>().Initialize(icons[index], _cardMatcher);
            _generatedCards.Add(genCard);
        }
    }
}
