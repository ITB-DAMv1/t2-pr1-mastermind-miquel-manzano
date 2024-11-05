using System;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PR1ManzanoEscuderoMiquel
{
    public class Program
    {
        // GAME SETTINGS: QUIERO PONER UNA VARIABLE QUE SEA TAMAÑO DE COMBINACION Y ASI REALACIONARLA CON EL DE LAS ARRAY

        const int MinValor = 1; // Valor minim que el usuari pot insertar.
        const int MaxValor = 6; // Valor maxim que el usuari pot insertar.
        const int ArrayLength = 4; // Longitud maxima de la combinacio.
        const string CombNums = "4545"; // Combinacio secreta.. shhhhh!


        // ASCII SYMBOLS:

        const string Correct = "\u004F";
        const string Incorrect = "\u00D7";
        const string Almost = "\u00D8";


        public static void Main ()
        {
            TitleMenu();
        }



        public static void TitleMenu()
        {
            Console.WriteLine("My Game :3");
            Console.WriteLine("1. Start\n2. Exit");
            int opcio = int.Parse(Console.ReadLine());
            if (opcio == 1)
            {
                Console.Clear();
                DifficultyMenu();
            } else
            {
                Console.Clear();
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
            Console.Clear();
            Game(attempts);
        }

        public static void Game(int attempts)
        {
            int[] userNums = new int[ArrayLength]; // Array on emmagatzem els numeros del usuari.
            int[] combNumsArray = new int[ArrayLength]; // Array on emmagatzem la combinacio secreta.
            CombNumsArray(combNumsArray);
            bool result;

            do
            {
                UserNumsArray(userNums);
                Console.WriteLine("Numeros escollits:");
                ArrayMaker(userNums, null, 1, null);
                Console.Write("\n");
                Console.WriteLine("Resultat:");
                result = ArrayMaker(userNums, combNumsArray, 3, null);
                Console.Write("\n");
                -- attempts;
            } while (attempts > 0 && !result);
            WinLoseMenu(result);
        }

        public static void WinLoseMenu(bool result)
        {
            if (result)
            {
                Console.Clear();
                Console.WriteLine("U WON");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("U LOSE");
            }
        }

        public static void UserNumsArray(int[] userNums) // Insercio i impres de l'array del jugador.
        {
            ArrayMaker(userNums, null, 0, null);
            Console.Clear();
        }

        public static void CombNumsArray(int[] combNumsArray) // Insercio de la combinacio secreta, string, a una array.
        {
            ArrayMaker(combNumsArray, null, 2, CombNums);
        }

        






        // ARRAY THINGS DOWN HERE:

        public static bool ArrayMaker(int[] array, int[] array2, int mode, string varString) // Funció on recorres la array i pots escollir que fer mentre la recorres.
        {
            int SameNumbers = 0;
            for (int i = 0; i < 4; i++)// CCAMBIAR COÑOO
            {
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
                        SameNumbers = SameNumbers + ArrayComparator(array, array2, i);
                        break;
                }
            }
            return SameNumbers >= 4;
            Console.Write("\n");
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






        public static int ArrayComparator(int[] array, int[] array2, int posicion)
        {
            if (array[posicion] == array2[posicion])
            {
                // Si el valor y posición son iguales, imprimimos "0"
                Console.Write(Correct);
                return 1;
            }
            else if (array2.Contains(array[posicion]))
            {
                // Si el valor existe en Array2 pero en otra posición, imprimimos "N"
                Console.Write(Almost);
                return 0;
            }
            else
            {
                // Si el valor no existe en Array2, imprimimos "X"
                Console.Write(Incorrect);
                return 0;
            }
        }
    }
}