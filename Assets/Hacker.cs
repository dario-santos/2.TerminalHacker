using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configuration data
    string[] level1Passwords = {"dog", "cat", "bird", "rabit", "fish" };
    string[] level2Passwords = {"monkey", "toucan", "frog", "snake", "crocodile"};
    string[] level3Passwords = { "elephant", "giraffe", "rinoceront", "hyena", "bison" };

    //Game State
    int level;

    enum Screens { MainMenu , Password, Win}
    Screens currentScreen = Screens.MainMenu;
    string password;


    // Use this for initialization
    void Start()
    {
        ShowMenu();
    }


    void ShowMenu()
    {

        Terminal.ClearScreen();
        currentScreen = Screens.MainMenu;
        Terminal.WriteLine("Welcome to the Anagram of Animals");
        Terminal.WriteLine("");
        Terminal.WriteLine("");
        Terminal.WriteLine("1 - Easy level");
        Terminal.WriteLine("2 - Medium level");
        Terminal.WriteLine("3 - Hard level");

        Terminal.WriteLine("Input: ");

    }


    void OnUserInput(string input)
    {

        Terminal.ClearScreen();
        if (input == "menu")
        {
            ShowMenu();
        }
        else if (currentScreen == Screens.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screens.Password)
        {
            CheckPassword(input);
        }
        else if (currentScreen == Screens.Win)
        {
            ShowMenu();
        }
        else
        {
            ShowMenu();
            Terminal.WriteLine("Invalid input");
            Terminal.WriteLine("Type menu to return to menu");
        }

    }


    void RunMainMenu(string input)
    {

        switch (input)
        {
            case "1":
            case "2":
            case "3":
                level = int.Parse(input);
                StartGame();
                break;

            case "007":
                break;

            default:
                Terminal.WriteLine("Invalid input");
                Terminal.WriteLine("Type menu to return to menu");
                break;
        }
    }

    
    void StartGame()
    {
        currentScreen = Screens.Password;
        choosePassword(level);

        Terminal.WriteLine("Playing level" + level);
        Terminal.WriteLine("Type menu to return to menu");
        Terminal.WriteLine("What is this animal :" + password.Anagram());

    }


    void choosePassword(int level)
    {
        int i = 0;

        switch (level)
        {
            case 1:
                i = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[i];
                break;

            case 2:
                i = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[i];
                break;

            case 3:
                i = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[i];
                break;

            default:
                Terminal.WriteLine("Level out of range, level is now 1");
                password = level3Passwords[2];
                break;
        }

    }


    void CheckPassword(string input)
    {
        if (input != password)
        {
            Terminal.WriteLine("Wrong!");
            Terminal.WriteLine("Theres a new way to see things: " + password.Anagram());
        }
        else
        {
            currentScreen = Screens.Win;

            WinMenu();

        }

    }


    void WinMenu()
    {
        switch (level)
        {
            case 1: //Casa

                Terminal.WriteLine(@"

                     ___
                   //. .\\  
                  __\_._/
                /|     |
                ");
                Terminal.WriteLine("You win");
                break;


            case 2:
                Terminal.WriteLine("You win");
                break;
            case 3:
                Terminal.WriteLine("You win");
                break;


        }

        Terminal.WriteLine("Type menu to return to menu");

    }
}


	
	
