// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System;



Console.WriteLine("Starting amount in Account 1 ?");
int acc1 = int.Parse(Console.ReadLine());
Console.WriteLine("Starting amount in Account 2 ?");
int acc2 = int.Parse(Console.ReadLine());




bool loop = true;
while (loop)
{
    int depositAmount = 0;
    int withdrawAmount = 0;
    int acc = -1;
    int accD = -1;
    Console.WriteLine($"Account 1 = {acc1}");
    Console.WriteLine($"Account 2 = {acc2}");
    Console.WriteLine("What would you like to do? Deposit? Pay Bill? Transfer? or Exit");
    string userChoice = Convert.ToString(Console.ReadLine().ToLower());

    if (userChoice == "deposit")
    {
        Console.WriteLine("Please enter the account number 1 or 2");

        if (int.TryParse(Console.ReadLine(), out acc) && (acc == 1 || acc == 2))
        {
            Console.WriteLine("Please enter the $ amount");

            if (int.TryParse(Console.ReadLine(), out depositAmount))
            {
                deposit(depositAmount, acc, ref acc1, ref acc2);
            }
            else
            {
                Console.WriteLine("!! INVALID - ENTER A NUMBER !!");
            }
        }
    }
    if (userChoice == "pay bill")
    {
        Console.WriteLine("PAY BILL");
    }

    if (userChoice == "transfer")
    {
        Console.WriteLine("TRANSFER");
        Console.WriteLine("Please enter the ORIGIN account number 1 or 2");

        if (int.TryParse(Console.ReadLine(), out acc) && (acc == 1 || acc == 2))
        {
            Console.WriteLine("Please enter the Destination Account 1 or 2");
            if (!int.TryParse(Console.ReadLine(), out accD) && (accD == 1 || accD == 2)) { }

            bool validAmount = true;
            while (validAmount)
            {

                if (acc == 1)
                {
                    Console.WriteLine("Enter the $ amount");
                    if (int.TryParse(Console.ReadLine(), out withdrawAmount))
                    {
                        if (withdrawAmount > acc1)
                        {
                            Console.WriteLine("Not Engouh money in Account 1");
                        }
                        if (withdrawAmount <= acc1)
                        {
                            validAmount = false;
                            payBill(acc, accD, withdrawAmount, ref acc1, ref acc2);
                        }
                    }
                }
                if(acc == 2) 
                {
                    Console.WriteLine("Enter the $ amount");
                    if (int.TryParse(Console.ReadLine(), out withdrawAmount))
                    {
                        if (withdrawAmount > acc2)
                        {
                            Console.WriteLine("Not enough money in Account 2");
                        }
                        if (withdrawAmount <= acc2)
                        {
                            validAmount = false;
                            payBill(acc, accD, withdrawAmount, ref acc1, ref acc2);
                        }
                    }
                }
            }

        }

        if (userChoice == "exit")
        {
            loop = false;
        }

    }

    static void deposit(int amount, int accNumber, ref int acc1, ref int acc2)
    {
        Console.WriteLine($"DEPOSIT Amount={amount} &&& Acc#={accNumber}");
        if (accNumber == 1)
        {
            acc1 += amount;
        }
        else
        {
            acc2 += amount;
        }
    }

    static int withdraw(int amount, int accNumber)
    {
        Console.WriteLine($"WITHDRAW Amount={amount} &&& Acc#={accNumber}");
        return 0;
    }

    static void payBill(int originAccount, int destinationAccount, int amount, ref int acc1, ref int acc2)
    {
        Console.WriteLine("PAY BILL FUNCTION EXECUTED");
        if (originAccount == 1)
        {
            acc1 -= amount;
            acc2 += amount;
        }
        else
        {
            acc1 += amount;
            acc2 -= amount;
        }

    }
}
