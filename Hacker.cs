using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {


    
    string[] level1Passwords = { "DepartmentofFinance", "DepartmentofEnergy", "DepartmentOfTourism", "DepartmentofEducation" };
    string[] level2Passwords = { "RodrigoDuterte", "GloriaArroyo", "NoynoyAquino" ,"EmilioAguinaldo" ,"JoseLaurel" ,"CarlosGarcia"};
    string[] level3Passwords = { "ChizEscudero", "AntonioTrillanes", "GracePoe", "KikoPangilinan", "JVEjercito"};
    int level;
	enum Screen {MainMenu, Password, Win};
    Screen currentScreen;
    string password;
	const string alert = "Type 'menu' to go back.";

    void Start()
    {
        ShowMainMenu();       
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Scanning network......");
        Terminal.WriteLine("Loading files......");
		Terminal.WriteLine("Verifying IP Address.........");
		Terminal.WriteLine("GPS Turn on.........");
		Terminal.WriteLine("Locking location.........");
        Terminal.WriteLine("COMPLETED");
        Terminal.WriteLine("");
		Terminal.WriteLine("-----------------------------------");
		Terminal.WriteLine("    REPUBLIC OF THE PHILLIPINES    ");
		Terminal.WriteLine("		Official Site Admin        ");
		Terminal.WriteLine("-----------------------------------");
		Terminal.WriteLine(" 1 > Government Agencies ");
		Terminal.WriteLine(" 2 > President Lists     ");
		Terminal.WriteLine(" 3 > Current Legislators ");


    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }


    }

    void RunMainMenu(string input)
    {

        
        if (input == "1" || input == "2" || input == "3" )
        {
            level = int.Parse(input);
            Debug.Log("Player entered: " + input);
            SetRandomPassword();
            AskForPassword();
        }
        else 
        {
            Terminal.WriteLine("Warning!! Incorrect Input.");
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Establishing connection.........");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("CONNECTED");
        Terminal.WriteLine(password.Anagram());
        Terminal.WriteLine("Enter Password: ");

    }

    void SetRandomPassword()
    {
        switch (level)
        {

            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password= level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            
        }
    } 

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
		else if (input == "exit")
        {
            ShowMainMenu();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"────▄▄▄▄▄▄▄▄▄▄▄▄▄▄
▀▀▀█─▄▄▄▄▄▄─▄─▄─▄─█
───█─█────█─▄▀▄▀▄─█
───█─█▄▄▄▄█─▄▀▄▀▄─█
───▀▄▄▄▄▄▄▄▄▄▄▄▄▄▄▀
");
                Terminal.WriteLine("You can now access government owned telecom around. Type 'menu' to acess more.");
                break;
            case 2:
                Terminal.WriteLine(@"░░▄▀▀▀▄░▄▄░░░░░░╠▓░░░░
░░░▄▀▀▄█▄░▀▄░░░▓╬▓▓▓░░
░░▀░░░░█░▀▄░░░▓▓╬▓▓▓▓░
░░░░░░▐▌░░░░▀▀███████▀
▒▒▄██████▄▒▒▒▒▒▒▒▒▒▒▒▒
 ");
                Terminal.WriteLine("You can now access government owned properties around. Type 'menu' to acess more.");
                break;
            case 3:
                Terminal.WriteLine(@"──▄▀▀▀▄───────────────
──█───█───────────────
─███████─────────▄▀▀▄─
░██─▀─██░░█▀█▀▀▀▀█░░█░
░███▄███░░▀░▀░░░░░▀▀░░
 ");
                Terminal.WriteLine("You can now unlock any government owned sites. Type 'menu' to acess more.");
                break;
            default:
                Debug.LogError("Invalid level reached!");
                break;
        }
    }
}
