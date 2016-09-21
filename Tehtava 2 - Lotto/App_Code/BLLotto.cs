using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BLLotto
{
    int type;
    int smallestNumber;
    int largestNumber;
    int totalNumbers;
    public List<List<int>> drawnNumbers = new List<List<int>>();

    public void ArvoRivi(int type, int drawns)
    {
        switch(type) {
            // Suomi Lotto
            case 1:
                ArvoSuomiLotto(drawns);
                break;
            // Viking Lotto
            case 2:
                ArvoVikingLotto(drawns);
                break;
        }
    }

    public void tulostaRivit() {
        if (this.drawnNumbers.Count != 0)
        {
            foreach (var list in this.drawnNumbers)
            {
                foreach(var number in list) {
                    System.Diagnostics.Debug.Write(number + " ");
                }
                System.Diagnostics.Debug.WriteLine("");
            }
        }
    }

    private void ArvoSuomiLotto(int drawns) {
        Random rnd = new Random();

        for (int i = 0; i < drawns; i++)
        {
            List<int> numbers = new List<int>();
            for (int j = 0; j < 7; j++)
            {
                int number = rnd.Next(1, 39);

                // Check if number exists in List
                if (!numbers.Contains(number))
                {
                    numbers.Add(number);
                } else
                {
                    j--;
                }
            }
            this.drawnNumbers.Add(numbers);
        }
    }

    private void ArvoVikingLotto(int drawns)
    {
        Random rnd = new Random();

        for (int i = 0; i < drawns; i++)
        {
            List<int> numbers = new List<int>();
            for (int j = 0; j < 6; j++)
            {
                int number = rnd.Next(1, 48);

                // Check if number exists in List
                if (!numbers.Contains(number))
                {
                    numbers.Add(number);
                }
                else
                {
                    j--;
                }
            }
            this.drawnNumbers.Add(numbers);
        }
    }
}