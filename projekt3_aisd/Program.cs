using System;

namespace projekt3_aisd
{
    class Program
    {
        static void Losuj(int[] tablica)
        {
            Random rnd = new Random();
            int maxValue = int.MaxValue;

            for (int i = 0; i < tablica.Length; i++)
            {
                tablica[i] = rnd.Next(maxValue);
            }
        }

        static int[] Liczby(int rozmiar)
        {
            int[] tab = new int[rozmiar];
            Losuj(tab);
            return tab; // zwraca tablicę
        }

        // Insertion Sort
        static void InsertionSort(int[] t)
        {
            for (uint i = 1; i < t.Length; i++)
            {
                uint j = i; // elementy 0 .. i-1 są już posortowane
                int Buf = t[j]; // bierzemy i-ty (j-ty) element
                while ((j > 0) && (t[j - 1] > Buf))
                { // przesuwamy elementy
                    t[j] = t[j - 1];
                    j--;
                }
                t[j] = Buf; // i wpisujemy na docelowe miejsce
            }
        } /* InsertionSort() */

        // Selection Sort
        static void SelectionSort(int[] t)
        {
            uint k;
            for (uint i = 0; i < (t.Length - 1); i++)
            {
                int Buf = t[i]; // bierzemy i-ty element
                k = i; // i jego indeks
                for (uint j = i + 1; j < t.Length; j++)
                    if (t[j] < Buf) // szukamy najmniejszego z prawej
                    {
                        k = j;
                        Buf = t[j];
                    }
                t[k] = t[i]; // zamieniamy i-ty z k-tym
                t[i] = Buf;
            }
        } /* SelectionSort() */

        static void Heapify(int[] t, uint left, uint right)
        { // procedura budowania/naprawiania kopca
            uint i = left,
            j = 2 * i + 1;
            int buf = t[i]; // ojciec
            while (j <= right) // przesiewamy do dna stogu
            {
                if (j < right) // wybieramy większego syna
                    if (t[j] < t[j + 1]) j++;
                if (buf >= t[j]) break;
                t[i] = t[j];
                i = j;
                j = 2 * i + 1; // przechodzimy do dzieci syna
            }
            t[i] = buf;
        } /* Heapify() */

        // Heap Sort
        static void HeapSort(int[] t)
        {
            uint left = ((uint)t.Length / 2),
            right = (uint)t.Length - 1;
            while (left > 0) // budujemy kopiec idąc od połowy tablicy
            {
                left--;
                Heapify(t, left, right);
            }
            while (right > 0) // rozbieramy kopiec
            {
                int buf = t[left];
                t[left] = t[right];
                t[right] = buf; // największy element
                right--; // kopiec jest mniejszy
                Heapify(t, left, right); // ale trzeba go naprawić
            }
        } /* HeapSort() */

        // Cocktail Sort
        static void CocktailSort(int[] t)
        {
            int Left = 1, Right = t.Length - 1, k = t.Length - 1;
            do
            {
                for (int j = Right; j >= Left; j--) // przesiewanie od dołu
                    if (t[j - 1] > t[j])
                    {
                        int Buf = t[j - 1]; t[j - 1] = t[j]; t[j] = Buf;
                        k = j; // zamiana elementów i zapamiętanie indeksu
                    }
                Left = k + 1; // zacieśnienie lewej granicy
                for (int j = Left; j <= Right; j++) // przesiewanie od góry
                    if (t[j - 1] > t[j])
                    {
                        int Buf = t[j - 1]; t[j - 1] = t[j]; t[j] = Buf;
                        k = j; // zamiana elementów i zapamiętanie indeksu
                    }
                Right = k - 1; // zacieśnienie prawej granicy
            }
            while (Left <= Right);
        } /* CocktailSort() */

        // postać rosnąca
        static void GenerateAscendingArray(int[] t)
        {
            Array.Sort(t);
            foreach (int value in t)
            {
                Console.Write(value + ", ");
            }
        }

        // postać malejąca
        static void GenerateDescendingArray(int[] t)
        {
            Array.Reverse(t);
            foreach (int value in t)
            {
                Console.Write(value + ", ");
            }
        }

        // postać losowa
        static void GenerateRandomArray(int[] t)
        {
            for (int i = 0; i < t.Length; ++i)
            {
                Console.Write(t[i] + ", ");
            }
        }

        // postać V-kształtna
        static void GenerateVArray(int[] t)
        {
            Array.Sort(t);

            for (int i = t.Length - 1; i >= t.Length / 2; i--)
                Console.Write(t[i] + ", ");
            for (int i = 0; i < t.Length / 2; i++)
                Console.Write(t[i] + ", ");
        }

        // postać A-kształtna
        static void GenerateAArray(int[] t)
        {
            Array.Sort(t);

            for (int i = 0; i < t.Length / 2; i++)
                Console.Write(t[i] + ", ");
            for (int i = t.Length - 1; i >= t.Length / 2; i--)
                Console.Write(t[i] + ", ");
        }

        // pokaż tablicę
        static void printArray(int[] t)
        {
            for (int i = 0; i < t.Length; ++i)
            {
                Console.Write(t[i] + ", ");
            }
            Console.Write("\n");
        }

        // implementacja rekurencyjna
        static void QuickSortRek(int[] t, int l, int p)
        {
            int i, j, x;
            i = l;
            j = p;
            x = t[(l + p) / 2]; // (pseudo)mediana
            do
            {
                while (t[i] < x) i++; // przesuwamy indeksy z lewej
                while (x < t[j]) j--; // przesuwamy indeksy z prawej
                if (i <= j) // jeśli nie minęliśmy się indeksami (koniec kroku)
                { // zamieniamy elementy
                    int buf = t[i]; t[i] = t[j]; t[j] = buf;
                    i++; j--;
                }
            }
            while (i <= j);
            if (l < j) QuickSortRek(t, l, j); // sortujemy lewą część (jeśli jest)
            if (i < p) QuickSortRek(t, i, p); // sortujemy prawą część (jeśli jest)
        } /* qsort() */

        // implementacja iteracyjna
        static void QuickSortIter(int[] t)
        {
            Random rnd = new Random();
            int i, j, l, p, sp;
            int[] stos_l = new int[t.Length],
            stos_p = new int[t.Length]; // przechowywanie żądań podziału
            sp = 0; stos_l[sp] = 0; stos_p[sp] = t.Length - 1; // rozpoczynamy od całej tablicy
            do
            {
                l = stos_l[sp]; p = stos_p[sp]; sp--; // pobieramy żądanie podziału
                do
                {
                    int x;
                    i = l;
                    j = p;
                    x = t[(l + p) / 2]; // analogicznie do wersji rekurencyjnej

                    //x = t[p]; // prawy klucz

                    //int random = rnd.Next(l, p); // klucz losowy
                    //x = t[random];

                    do
                    {
                        while (t[i] < x) i++;
                        while (x < t[j]) j--;
                        if (i <= j)
                        {
                            int buf = t[i]; t[i] = t[j]; t[j] = buf;
                            i++; j--;
                        }
                    } while (i <= j);
                    if (i < p) { sp++; stos_l[sp] = i; stos_p[sp] = p; } // ewentualnie dodajemy żądanie podziału
                    p = j;
                } while (l < p);
            } while (sp >= 0); // dopóki stos żądań nie będzie pusty
        } /* qsort() */

        // Main
        static void Main(string[] args)
        {
            Console.Write("Podaj ile liczb ma być w tablicy: ");
            int x;
            x = int.Parse(Console.ReadLine());
            int[] arr = Liczby(x); // wywołanie metody

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("MENU");
            Console.WriteLine("1. Insertion Sort");
            Console.WriteLine("2. Selection Sort");
            Console.WriteLine("3. Heap Sort");
            Console.WriteLine("4. Cocktail Sort");
            Console.WriteLine("5. Quick Sort: Rekurencyjnie");
            Console.WriteLine("6. Quick Sort: Iteracyjnie");
            Console.WriteLine();
            int wybor;
            Console.Write("Wybierz, jakiego sortowania chcesz użyć: ");
            wybor = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (; ; )
            {
                switch (wybor)
                {
                    case 1:
                        {
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("1. Postać losowa");
                            Console.WriteLine("2. Postać rosnąca");
                            Console.WriteLine("3. Postać malejąca");
                            Console.WriteLine("4. Postać V-kształtna");
                            Console.WriteLine();
                            int wybor1;
                            Console.Write("W jakiej postaci chcesz wygenerować tablice? ");
                            wybor1 = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            switch (wybor1)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób losowy: ");
                                        GenerateRandomArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Insertion Sort
                                        InsertionSort(arr);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                case 2:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób rosnący: ");
                                        GenerateAscendingArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Insertion Sort
                                        InsertionSort(arr);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                case 3:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób malejący: ");
                                        GenerateDescendingArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Insertion Sort
                                        InsertionSort(arr);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                case 4:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób V-kształtny: ");
                                        GenerateVArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Insertion Sort
                                        InsertionSort(arr);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                default: Console.WriteLine("Niepoprawna opcja"); break;
                            }
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("1. Postać losowa");
                            Console.WriteLine("2. Postać rosnąca");
                            Console.WriteLine("3. Postać malejąca");
                            Console.WriteLine("4. Postać V-kształtna");
                            Console.WriteLine();
                            int wybor1;
                            Console.Write("W jakiej postaci chcesz wygenerować tablice? ");
                            wybor1 = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            switch (wybor1)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób losowy: ");
                                        GenerateRandomArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Selection Sort
                                        SelectionSort(arr);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                case 2:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób rosnący: ");
                                        GenerateAscendingArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Selection Sort
                                        SelectionSort(arr);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                case 3:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób malejący: ");
                                        GenerateDescendingArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Selection Sort
                                        SelectionSort(arr);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                case 4:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób V-kształtny: ");
                                        GenerateVArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Selection Sort
                                        SelectionSort(arr);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                default: Console.WriteLine("Niepoprawna opcja"); break;
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("1. Postać losowa");
                            Console.WriteLine("2. Postać rosnąca");
                            Console.WriteLine("3. Postać malejąca");
                            Console.WriteLine("4. Postać V-kształtna");
                            Console.WriteLine();
                            int wybor1;
                            Console.Write("W jakiej postaci chcesz wygenerować tablice? ");
                            wybor1 = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            switch (wybor1)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób losowy: ");
                                        GenerateRandomArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Heap Sort
                                        HeapSort(arr);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                case 2:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób rosnący: ");
                                        GenerateAscendingArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Heap Sort
                                        HeapSort(arr);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                case 3:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób malejący: ");
                                        GenerateDescendingArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Heap Sort
                                        HeapSort(arr);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                case 4:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób V-kształtny: ");
                                        GenerateVArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Heap Sort
                                        HeapSort(arr);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                default: Console.WriteLine("Niepoprawna opcja"); break;
                            }
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("1. Postać losowa");
                            Console.WriteLine("2. Postać rosnąca");
                            Console.WriteLine("3. Postać malejąca");
                            Console.WriteLine("4. Postać V-kształtna");
                            Console.WriteLine();
                            int wybor1;
                            Console.Write("W jakiej postaci chcesz wygenerować tablice? ");
                            wybor1 = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            switch (wybor1)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób losowy: ");
                                        GenerateRandomArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Cocktail Sort
                                        CocktailSort(arr);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                case 2:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób rosnący: ");
                                        GenerateAscendingArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Cocktail Sort
                                        CocktailSort(arr);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                case 3:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób malejący: ");
                                        GenerateDescendingArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Cocktail Sort
                                        CocktailSort(arr);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                case 4:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób V-kształtny: ");
                                        GenerateVArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Cocktail Sort
                                        CocktailSort(arr);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                default: Console.WriteLine("Niepoprawna opcja"); break;
                            }
                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("1. Postać losowa");
                            Console.WriteLine();
                            int wybor1;
                            Console.Write("W jakiej postaci chcesz wygenerować tablice? ");
                            wybor1 = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            switch (wybor1)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób losowy: ");
                                        GenerateRandomArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Quick Sort rekurencyjnie
                                        QuickSortRek(arr, 0, arr.Length - 1);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                default: Console.WriteLine("Niepoprawna opcja"); break;
                            }
                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("1. Postać losowa");
                            Console.WriteLine("2. Postać A-kształtna");
                            Console.WriteLine();
                            int wybor1;
                            Console.Write("W jakiej postaci chcesz wygenerować tablice? ");
                            wybor1 = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            switch (wybor1)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób losowy: ");
                                        GenerateRandomArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Quick Sort iteracyjnie
                                        QuickSortIter(arr);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                case 2:
                                    {
                                        Console.WriteLine("Generecja tablicy w sposób A-kształtny: ");
                                        GenerateAArray(arr);
                                        Console.WriteLine();

                                        // czas
                                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                                        stopwatch.Start();
                                        // Quick Sort iteracyjnie
                                        QuickSortIter(arr);
                                        stopwatch.Stop();

                                        // po sortowaniu
                                        Console.WriteLine("\n Posortowana tablica: ");
                                        printArray(arr);
                                        Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);
                                        Console.WriteLine();
                                    }
                                    break;
                                default: Console.WriteLine("Niepoprawna opcja"); break;
                            }
                        }
                        break;
                    default: Console.WriteLine("Niepoprawna opcja"); break;
                }
            }
        }
    }
}
