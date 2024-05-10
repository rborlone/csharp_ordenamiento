using System;
using System.Security.Cryptography.X509Certificates;
public class Program{
    static public int Main(){
        List<int> numeros = Enumerable.Range(0, 5).ToList();
         
        Random seeder = new Random();
        int seed = seeder.Next();
        Random engine = new Random(seed);

        //ciudades = new List<int>(){0,48,31,44,18,40,7,8,9,42,32,50,10,51,13,12,46,25,26,27,11,24,3,5,14,4,23,47,37,36,39,38,35,34,33,43,45,15,28,49,19,22,29,1,6,41,20,16,2,17,30,21,0};
        Revolver(numeros, 0, numeros.Count - 1, engine);

        foreach(int i in numeros){
            Console.Write(string.Format("{0},", i));
        }

        Ordenar(numeros);

        Console.WriteLine("");

        foreach(int i in numeros){
            Console.Write(string.Format("{0},", i));
        }


        int dividir = numeros.Count / 2;

        List<int> num1 = numeros.GetRange(0, dividir);
        List<int> num2 = numeros.GetRange(dividir + 1.env, numeros.Count);







        return 1;
    }

    public static void Ordenar(List<int> a){
        for(int i=0; i<a.Count; i++){
            for(int j=1; j<a.Count; j++){
                if (a[i]<a[j]){
                    int cont = a[j];
                    a[j] = a[i];
                    a[i] = cont;
                }
            }
        }
    }

        /***
        Metodo para barajar las ciudades.
    */
    private static void Revolver<T>(List<T> list, int start, int end, Random rng)
    {
        int n = end - start;
        while (n > 1)
        {
            int k = rng.Next(n--);
            T temp = list[start + k];
            list[start + k] = list[start + n];
            list[start + n] = temp;
        }
    }

}