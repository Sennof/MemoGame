using UnityEngine;

public class CardsGenerator
{
    public int[] GenerateCardsArray(string path)
    {
        int amount = Resources.LoadAll<Sprite>(path).Length;
        int[] indexes = new int[(amount-1) * 2];

        int n = 0;
        for(int i = 0; i < (amount-1)*2; i += 2)
        {
            indexes[i] = n;
            indexes[i + 1] = n;
            n++;
        }

        Shuffle(indexes);
        return indexes;
    }

    private void Shuffle(int[] arr)
    {
        System.Random rand = new System.Random();
        for (int i = arr.Length - 1; i >= 1; i--)
        {
            int j = rand.Next(i + 1);
            int tmp = arr[j];
            arr[j] = arr[i];
            arr[i] = tmp;
        }
    }
}
