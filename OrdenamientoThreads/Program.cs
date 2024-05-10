using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static void MostrarLista(List<int> numeros){
        foreach (int num in numeros)
            Console.Write(string.Format("{0}, ", num));
        Console.WriteLine("\n");
    }

    static List<int> mergeSort(List<int> num, int a){
        
        List<int> resultado = new List<int>(num.Count);
        int max=num.Count;
        int j = a;
        int n = 0;
        int x = 0;

        for (int i = 0; i<num.Count; i++){
            if (x == a)
                resultado.Add(num[j++]);
            else if (j == max)
                resultado.Add(num[x++]);
            else if (num[x] < num[j])
                resultado.Add(num[x++]);
            else
                resultado.Add(num[j++]);
            n++;
        }
        
        return resultado;
    }

    static List<int> bubbleSort(List<int> num){
        for(int i=0; i<num.Count; i++){
            for(int j=0; j<num.Count; j++){
                if (num[i]<num[j]){
                    int cont = num[j];
                    num[j] = num[i];
                    num[i] = cont;
                }
            }
        }

        return num;
    }

    static void Revolver<T>(List<T> list, int inicio, int fin, Random rand)
    {
        int n = fin - inicio;
        while (n > 1){
            int k = rand.Next(n--);
            T temp = list[inicio + k];
            list[inicio + k] = list[inicio + n];
            list[inicio + n] = temp;
        }
    }

    static void Main(string[] args){
        Random seeder = new Random();
        int seed = seeder.Next();
        Random rand = new Random(seed);
        
        List<int> numeros = Enumerable.Range(1, 20).ToList();

        Revolver(numeros, 0, numeros.Count - 1, rand);

        //Mostramos la lista
        MostrarLista(numeros);

        int dividir = numeros.Count / 2;

        List<int> num1 = numeros.GetRange(0, dividir);
        List<int> num2 = numeros.GetRange(dividir, numeros.Count - dividir);
    
        List<Thread> threads = new List<Thread>();

        // threads.Add(new Thread(() => num1.Sort(0, num1.Count, null)));
        // threads.Add(new Thread(() => num2.Sort(0, num2.Count, null)));

        threads.Add(new Thread(() => bubbleSort(num1)));
        threads.Add(new Thread(() => bubbleSort(num2)));

        foreach (var thread in threads) {
            thread.Start();
        }

        foreach (var thread in threads) {
            thread.Join();
        }
        
        num1.AddRange(num2);
        numeros = num1;

        MostrarLista(numeros);

        numeros = mergeSort(numeros, dividir);

        MostrarLista(numeros);
    }
}