using System;
using System.Runtime.InteropServices;

namespace PR1ManzanoEscuderoMiquel
{
    public class Program
    {
        // GAME SETTINGS:

        const int MinValor = 1; // Valor minim que el usuari pot insertar.
        const int MaxValor = 6; // Valor maxim que el usuari pot insertar.
        const int ArrayLength = 4; // Longitud maxima de la combinacio.
        const string CombNums = "4444"; // Combinacio secreta.. shhhhh!


        // ASCII SYMBOLS:

        const string Correct = "\u004F";
        const string Incorrect = "\u00D7";
        const string Almost = "\u00D8";


        public static void Main ()
        {
            Menu();
        }



        public static void Menu()
        {
            Console.WriteLine("My Game :3");
            Console.WriteLine("1. Start\n2. Exit");
            int opcio = int.Parse(Console.ReadLine());
            if (opcio == 1)
            {
                DifficultyMenu();
            } else
            {
                Console.WriteLine("Goodbye!!");
            }
        }

        public static void DifficultyMenu()
        {
            Console.WriteLine("1. Dificultat novell: 10 intents\n2. Dificultat aficionat: 6 intents\n3. Dificultat expert: 4 intents\n4. Dificultat Màster: 3 intents\n5. Dificultat personalitzada\n");
            int attempts = int.Parse(Console.ReadLine());
            switch (attempts)
            {
                case 1:
                    attempts = 10;
                    break;
                case 2: 
                    attempts = 6;
                    break;
                case 3:
                    attempts = 4;
                    break;
                case 4:
                    attempts = 3;
                    break;
                case 5:
                    attempts = int.Parse(Console.ReadLine()); // Falta control d'error si posa 0 o inferior
                    break;
                default: 
                    Console.WriteLine("Escriu una opcio valida");
                    break;
            }
            Game(attempts);
        }

        public static void Game(int attempts)
        {
            int[] userNums = new int[ArrayLength]; // Array on emmagatzem els numeros del usuari.
            int[] combNumsArray = new int[ArrayLength]; // Array on emmagatzem la combinacio secreta.
            string[] symbolsArray = new string[ArrayLength]; // Array dels simbols ASCII.
            CombNumsArray(combNumsArray);

            do
            {
                UserNumsArray(userNums);
                GameMechanic(userNums, combNumsArray, symbolsArray);
                ArrayMaker(null, null, symbolsArray, 5, null);
            } while (attempts > 0);

        }

        public static void WinLoseMenu(bool result)
        {

        }

        public static void UserNumsArray(int[] userNums) // Insercio i impres de l'array del jugador.
        {
            ArrayMaker(userNums, null, null, 0, null);
            Console.WriteLine("Numeros escollits:");
            ArrayMaker(userNums, null, null, 1, null);
        }

        public static bool GameMechanic(int[] userNums, int[] combNumsArray, string[] symbolsArray)
        {
            ArrayMaker(userNums, combNumsArray, symbolsArray, 4, null);
            return false;
        }

        public static void CombNumsArray(int[] combNumsArray) // Insercio de la combinacio secreta a una array.
        {
            ArrayMaker(combNumsArray, null, null, 2, CombNums);
        }

        






        // ARRAY THINGS DOWN HERE:

        public static void ArrayMaker(int[] array, int[] array2, string[] symbolsArray, int mode, string varString) // Funció on recorres la array i pots escollir que fer mentre la recorres.
        {
            for (int i = 0; i < array.Length; i++)
            {
                int returnNum = 0;
                switch (mode)
                {
                    case 0: // En aquest mode, inserim nombres a l'array escollits per l'usuari.
                        InsertUserNums(array, i);
                        break;
                    case 1: // En aquest mode, mostrem els nombres d'una array per pantalla.
                        ReadArray(array, i);
                        break;
                    case 2: // En aquest mode, pasem un string a Array.
                        StringToArray(array, i, varString);
                        break;
                    case 3: // En aquest mode, comparem dos Arrays.
                        ArrayComparator(array, array2, symbolsArray, i);
                        break;
                    case 4: // En aquest mode, mirem si un numero es dins de un altra array.
                        NumsValorComparator(array, array2, symbolsArray, i);
                        break;
                    case 5:
                        ReadStringArray(symbolsArray, i);
                        break;
                }
            }
        }

        public static void InsertUserNums(int[] Array, int posicion)
        {
            const string MsgEnunciat = "Introdueix el numero de la posicio:";
            const string MsgTryAgain = "Torna a probar...";
            int userNum;
            bool success;
            do
            {
                Console.WriteLine($"{MsgEnunciat} {1 + posicion}");
                success = int.TryParse(Console.ReadLine(), out userNum);
                if (success && userNum >= MinValor && userNum <= MaxValor)
                {
                    Console.WriteLine($"Felicitats, el numero {userNum} es valid!! \n");
                }
                else
                {
                    Console.WriteLine($"Molt malament, el numero {userNum} no es valid!! \n");
                    Console.WriteLine(MsgTryAgain);
                    success = false;
                }
            } while (!success);
            Array[posicion] = userNum;
        }

        public static void ReadArray(int[] array, int posicion)
        {
            Console.Write(array[posicion]);
        }

        public static void StringToArray(int[] array, int posicion, string varString)
        {
            array[posicion] = varString[posicion] - '0';
        }

        public static void ReadStringArray(string[] array, int posicion)
        {
            Console.Write(array[posicion]);
        }






        public static void ArrayComparator(int[] array, int[] array2, string[] symbolsArray, int posicion)
        {
            if (array[posicion] == array2[posicion])
            {
                symbolsArray[posicion] = Correct;
                //Console.WriteLine($"El numero en posicio: {posicion}, es igual a la combinacio");
            }
            else {
                symbolsArray[posicion] = Incorrect;
                //Console.WriteLine($"El numero en posicio: {posicion}, NO es igual a la combinacio");
            }
        }

        public static void NumsValorComparator(int[] array, int[] array2, string[] symbolsArray, int posicion)
        {
            for (int i = 0; i < array2.Length; i++)
            {
                if (array[posicion] == array2[i])
                {
                    symbolsArray[posicion] = Almost;
                    //Console.WriteLine($"NUMERO IGUAL {array[posicion]} {array2[i]}");
                }
            }
        }
    }
}