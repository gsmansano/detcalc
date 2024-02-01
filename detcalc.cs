using System;

public class MatrixCalculator
{


    public static void Main()
    {

        Console.WriteLine("\n*** Welcome to Geo's Matrix Determinant Calculator ***");
        Console.WriteLine("\nThe first step is to set the matrix size.");
        do
        {



            int matrixSize = MatrixSize();

            Console.WriteLine("\nYou choose a {0}x{0} matrix.", matrixSize);
            Console.WriteLine("\nNow, for the next step, we will look into your specific matrix.");
            double[,] matrixCalc;
            switch (matrixSize)
            {

                case 2:

                    matrixCalc = SetMatrix(matrixSize);

                    Console.WriteLine("\nThis is your {0}x{0} Matrix.", matrixSize);

                    ShowMatrix(matrixCalc);

                    Console.WriteLine("\nCalculating your 2x2 determinant.");

                    Console.WriteLine("\nThe dertminant of this matrix is {0}.", Calculate2(matrixCalc));

                    break;

                case 3:

                    matrixCalc = SetMatrix(matrixSize);

                    Console.WriteLine("\nThis is your {0}x{0} Matrix.", matrixSize);

                    ShowMatrix(matrixCalc);

                    Console.WriteLine("\nCalculating your 3x3 determinant.");

                    Console.WriteLine("\nThe dertminant of this matrix is {0}.", Calculate3(matrixCalc));

                    break;

                case 4:

                    matrixCalc = SetMatrix(matrixSize);

                    Console.WriteLine("\nThis is your {0}x{0} Matrix.", matrixSize);

                    ShowMatrix(matrixCalc);

                    Console.WriteLine("\nCalculating your 4x4 determinant.");

                    Console.WriteLine("\nThe dertminant of this matrix is {0}.", Calculate4(matrixCalc));

                    break;

                case 5:

                    matrixCalc = SetMatrix(matrixSize);

                    Console.WriteLine("\nThis is your {0}x{0} Matrix.", matrixSize);

                    ShowMatrix(matrixCalc);

                    Console.WriteLine("\nCalculating your 5x5 determinant.");

                    Console.WriteLine("\nThe dertminant of this matrix is {0}.", Calculate5(matrixCalc));

                    break;

                default:
                    Console.WriteLine("\nI don't know how you managed to get here... but this is not a valid matrix size.");
                    break;



            }

        } while (RestartCalculator());

        Console.WriteLine("\n** Thank you for using this calculator. Exiting program now...");
        Console.WriteLine("");


    }


    public static int MatrixSize()
    {

        int size = 0;
        string userChoice = "";
        bool validation = false;


        Console.WriteLine("\n* Bare in mind that this calculator only works for 2x2, 3x3, 4x4 and 5x5.*");
        Console.WriteLine("\nAt this time, pick a number between 2 and 5 to set the matrix size.");


        while (!validation)
        {

            Console.WriteLine("\nPlease choose the matrix size you want to calculate:");
            userChoice = Console.ReadLine();

            if (int.TryParse(userChoice, out size))
            {

                if (size >= 2 && size <= 5)
                {

                    validation = true;

                }
                else
                {

                    Console.WriteLine("\n* Invalid choice. Please pick a number between 2 and 5. *");

                }

            }
            else
            {

                Console.WriteLine("\n* That's not a number. Please pick a number between 2 and 5. *");

            }



        }

        return size;

    }

    public static double[,] SetMatrix(int size)
    {

        double[,] matrix = new double[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = MatrixValidation("\nEnter the value for matrix[{0},{1}]: ", i + 1, j + 1);

            }
        }

        return matrix;

    }

    public static double MatrixValidation(string numbPrompt, int row, int colm)
    {

        double value = 0;
        bool validation = false;

        while (!validation)
        {

            Console.WriteLine(numbPrompt, row, colm);
            string userInput = Console.ReadLine();

            if (double.TryParse(userInput, out value))
            {
                validation = true;
            }
            else
            {
                Console.WriteLine("That is not a valid input. Please enter a valid number.");
            }

        }

        return value;



    }

    public static void ShowMatrix(double[,] matX)
    {

        int row = matX.GetLength(0);
        int colm = matX.GetLength(1);

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < colm; j++)
            {
                if (j == colm - 1)
                {
                    Console.Write(string.Format("|{0, 5}|", matX[i, j]));
                }
                else
                {

                    Console.Write(string.Format("|{0, 5}", matX[i, j]));
                }


            }

            Console.WriteLine();

        }



    }

    public static bool RestartCalculator()

    {

        Console.WriteLine("\nWould you like to calculate a different determinant? (y for YES, n for NO.)");

        bool restartChoice = false;
        bool isValid = false;

        while (!isValid)
        {

            Console.Write("\nPlease enter your choice:");

            string userInput = Console.ReadLine();

            if (userInput.Length == 1)
            {
                char userAnswer = char.ToUpper(userInput[0]);

                if (userAnswer == 'Y')
                {

                    restartChoice = true;
                    isValid = true;
                }
                else if (userAnswer == 'N')
                {
                    restartChoice = false;
                    isValid = true;
                }
                else

                {
                    Console.WriteLine("Invalid Input. Please enter a valid character (y for YES, n for NO)");
                    isValid = false;

                }

            }
            else
            {

                Console.WriteLine("Invalid Input. Please enter a valid character (y for YES, n for NO)");
                isValid = false;
            }




        }

        return restartChoice;

    }

    public static double Calculate2(double[,] matrix)
    {



        double det2 = 0;

        det2 = (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);

        return det2;

    }

    public static double Calculate3(double[,] matrix)
    {



        double det3 = 0;

        det3 = matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1])
          - matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0])
          + matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);

        return det3;

    }

    public static double Calculate4(double[,] matrix)
    {


        double det4 = 0;

        for (int i = 0; i < 4; i++)
        {
            det4 += matrix[0, i] * Cofactor(matrix, 0, i);
        }

        return det4;
    }

    public static double Cofactor(double[,] matrix, int row, int col)
    {
        return Math.Pow(-1, row + col) * Minor(matrix, row, col);
    }

    public static double Minor(double[,] matrix, int row, int col)
    {
        double[,] submatrix = new double[3, 3];
        int subRow = 0, subCol = 0;

        for (int i = 0; i < 4; i++)
        {
            if (i != row)
            {
                subCol = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (j != col)
                    {
                        submatrix[subRow, subCol] = matrix[i, j];
                        subCol++;
                    }
                }
                subRow++;
            }
        }

        return Calculate3(submatrix);
    }

    public static double Calculate5(double[,] matrix)
    {

        double det5 = 0;

        for (int i = 0; i < 5; i++)
        {
            det5 += matrix[0, i] * Cofactor5(matrix, 0, i);
        }

        return det5;
    }

    public static double Cofactor5(double[,] matrix, int row, int col)
    {
        return Math.Pow(-1, row + col) * Minor5(matrix, row, col);
    }

    public static double Minor5(double[,] matrix, int row, int col)
    {
        double[,] submatrix = new double[4, 4];
        int subRow = 0, subCol = 0;

        for (int i = 0; i < 5; i++)
        {
            if (i != row)
            {
                subCol = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (j != col)
                    {
                        submatrix[subRow, subCol] = matrix[i, j];
                        subCol++;
                    }
                }
                subRow++;
            }
        }

        return Calculate4(submatrix);
    }


}
