using System;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PR1ManzanoEscuderoMiquel
{
    public class Program
    {
        // GAME SETTINGS:

        const int CombMinValor = 1; // Valor minim de la combinacio.
        const int CombMaxValor = 6; // Valor maxim de la combinacio.
        const int CombArrayLength = 4; // Longitud de la combinacio.
        const string CombNums = "4545"; // Combinacio secreta.. shhhhh!

        // DIFFICULTY SETTINGS - for each mode:

        const int NovellAttempts = 10;
        const int AficionatAttempts = 6;
        const int ExpertAttempts = 4;
        const int MasterAttempts = 3;

        // CUSTOM ATTEMPTS SETTINGS - rang:

        const int MinCustomAttempts = 1;
        const int MaxCustomAttempts = 99;


        // ASCII SYMBOLS:

        const string Correct = "\u004F";
        const string Incorrect = "\u00D7";
        const string Almost = "\u00D8";



        // ARRAYMAKER MODES:

        const int InsertNumsArray = 0;
        const int ReadNumsArray = 1;
        const int StringArray = 2;
        const int CompareArrays = 3;



        public static void Main () // Iniciem el Programa jeje
        {
            TitleMenu();
        }


        public static void TitleMenu() // Funcio amb el menu principal del joc
        {
            const string MsgTitle = @"                                                                                                        
 _____ _          _____         _      _____         _                 _       _    _____               
|_   _| |_ ___   | __  |___ ___| |_   |     |___ ___| |_ ___ ___ _____|_|___ _| |  |   __|___ _____ ___ 
  | | |   | -_|  | __ -| -_|_ -|  _|  | | | | .'|_ -|  _| -_|  _|     | |   | . |  |  |  | .'|     | -_|
  |_| |_|_|___|  |_____|___|___|_|    |_|_|_|__,|___|_| |___|_| |_|_|_|_|_|_|___|  |_____|__,|_|_|_|___|
                                                                                                        
-----------------------------------------------------------------------------------------------------------------

   |\      _,,,---,,_                                                   
   /,`.-'`'    -.  ;-;;,_                                                        )\._.,--....,'``.
  |,4-  ) )-,_..;\ (  `'-'                                                      /,   _.. \   _\  ;`._ ,.
 '---''(_/--'  `-'\_)                    Created by Miquel Manzano..           `._.-(,_..'--(,_..'`-.;.'

-----------------------------------------------------------------------------------------------------------------";
            const string MsgOptions = "1. Start\n2. Exit";

            int optionOne = 1;
            int optionTwo = 2;

            Console.WriteLine(MsgTitle);
            Console.WriteLine(MsgOptions);
            if (UserNumInput(optionOne, optionTwo) == optionOne)
            {
                Console.Clear();
                DifficultyMenu();
            } else
            {
                Exit();
            }
        }

        public static void DifficultyMenu() // Menu on seleccionem la dificultat
        {
            const int MinOptions = 1;
            const int MaxOptions = 5;
            const string MsgDifficultyTitle = "Choose the difficulty:";

            string msgCustomAttemps = $"Write the number of attempts you want ({MinCustomAttempts} - {MaxCustomAttempts}):";
            string msgDifficultyOptions = $"1. Dificultat novell: {NovellAttempts} intents\n2. Dificultat aficionat: {AficionatAttempts} intents\n3. Dificultat expert: {ExpertAttempts} intents\n4. Dificultat Màster: {MasterAttempts} intents\n5. Dificultat personalitzada\n";

            Console.WriteLine(MsgDifficultyTitle);
            Console.WriteLine(msgDifficultyOptions);
            int attempts = UserNumInput(MinOptions, MaxOptions);
            switch (attempts)
            {
                case 1:
                    attempts = NovellAttempts;
                    break;
                case 2: 
                    attempts = AficionatAttempts;
                    break;
                case 3:
                    attempts = ExpertAttempts;
                    break;
                case 4:
                    attempts = MasterAttempts;
                    break;
                case 5:
                    Console.WriteLine(msgCustomAttemps);
                    attempts = UserNumInput(MinCustomAttempts, MaxCustomAttempts);
                    break;
                default: 
                    Console.WriteLine("ERROR 404");
                    break;
            }
            Console.Clear();
            GameMenu(attempts);
        }

        public static void GameMenu(int attempts) // Menu on juguem el joc
        {
            int[] userNums = new int[CombArrayLength]; // Array on emmagatzem els numeros del usuari.
            int[] combNumsArray = new int[CombArrayLength]; // Array on emmagatzem la combinacio secreta.

            bool flag = false;

            GameCore(userNums, combNumsArray, attempts, ref flag);
            WinLoseMenu(flag);
        }

        public static void GameCore(int[] userNums, int[] combNumsArray, int attempts, ref bool flag) // Funcio amb la logica del joc
        {
            const string MsgUserComb = "Selected Numbers:";
            const string MsgResultComb = "Result:";
            
            ArrayMaker(combNumsArray, StringArray, CombNums);
            do
            {
                ArrayMaker(userNums, InsertNumsArray);
                Console.Clear();
                Console.WriteLine(MsgUserComb);
                ArrayMaker(userNums, ReadNumsArray);
                Console.Write("\n\n");
                Console.WriteLine(MsgResultComb);
                flag = ArrayMaker(userNums, combNumsArray, CompareArrays);
                Console.Write("\n\n");
                --attempts;
            } while (attempts > 0 && !flag);
        }

        public static void WinLoseMenu(bool flag) // Menu de resultat del joc
        {
            const string MsgWin = "CONGRATS!! YOU WON THE GAME!";
            const string MsgLose = "SKILL ISSUE, YOU LOSE THE GAME...";
            const string MsgTitleOption = "0. Go title menu.";
            const string MsgExitOption = "1. Exit";

            if (flag)
            {
                Console.Clear();
                Console.WriteLine(MsgWin);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(MsgLose);
            }
            Console.WriteLine("\n\n");
            Console.WriteLine(MsgTitleOption);
            Console.WriteLine(MsgExitOption);
            switch (UserNumInput(0,1))
            {
                case 0:
                    Console.Clear();
                    TitleMenu();
                    break;
                case 1:
                    Exit();
                    break;
            }
        }

        public static int UserNumInput(int min, int max) // SUPERMEGA UTIL FUNCIO ñam
        {
            const string MsgInvalidNum = "Invalid Number, Try again..";
            int userNum;
            Console.Write("> ");
            bool chekUserNum = int.TryParse(Console.ReadLine(), out userNum);

            while (!chekUserNum || (userNum < min || userNum > max))
            {
                Console.WriteLine(MsgInvalidNum);
                chekUserNum = int.TryParse(Console.ReadLine(), out userNum);
            }
            return userNum;
        }

        public static void Exit()
        {
            const string MsgGoodbye = "Goodbye!!";
            Console.Clear();
            Console.WriteLine(MsgGoodbye);
        }





        // ARRAY THINGS DOWN HERE:

        public static bool ArrayMaker(int[] array, int mode)
        {
            ArrayMaker(array, [], mode, "");
            return false;
        }

        public static bool ArrayMaker(int[] array, int mode, string varString)
        {
            ArrayMaker(array, [], mode, varString);
            return false;
        }

        public static bool ArrayMaker(int[] array, int[] array2, int mode)
        {
            return ArrayMaker(array, array2, mode, "");
        }

        public static bool ArrayMaker(int[] array, int[] array2, int mode, string varString) // Funció on recorres la array i pots escollir que fer mentre la recorres.
        {
            int SameNumbers = 0;
            for (int i = 0; i < CombArrayLength; i++)
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
            Console.Write("\n");
            return SameNumbers >= CombArrayLength;
        }

        public static void InsertUserNums(int[] Array, int posicion)
        {
            const string MsgEnunciat = "Enter number:";

            Console.WriteLine($"{MsgEnunciat} {1 + posicion}");
            Array[posicion] = UserNumInput(CombMinValor, CombMaxValor);
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
                // Si el valor i la posició són iguals, imprimim Correct
                Console.Write(Correct);
                return 1;
            }
            else if (array2.Contains(array[posicion]))
            {
                // Si el valor existeix a Array2 però en una altra posició, imprimim Almost
                Console.Write(Almost);
                return 0;
            }
            else
            {
                // Si el valor no existeix a Array2, imprimim Incorrect
                Console.Write(Incorrect);
                return 0;
            }
        }
    }
}