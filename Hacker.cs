using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    const string menuHint = "[REMINDER]: type 'menu' to go back.";
    string[] level1Passwords = { "yoda", "darth", "sith", "rebel", "jedi" };
    string[] level2Passwords = { "batman", "lantern", "amazon", "martian", "cyborg" };
    string[] level3Passwords = { "infantry", "sentinel", "everquest", "starblazer", "granstream" };
    
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome, Aiden Pearce");
        Terminal.WriteLine("Where do you like to hack into?");
        Terminal.WriteLine("Press 1 for Lucas Films");
        Terminal.WriteLine("Press 2 for DC Comics");
        Terminal.WriteLine("Press 3 for Sony Interactive Gaming");
        Terminal.WriteLine("\nEnter your selection:");        
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            Terminal.ClearScreen();
            ShowMainMenu();
        }
        else if (input.Equals("egg") && currentScreen == Screen.MainMenu)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("\n EASTER EGG! Literally :)\nType 'menu' and choose a level.");
            Terminal.WriteLine(@"
      .-*)) `*-.
     / * ((*   *'.
    |   *))  *   *\
    | *  ((*   *  /
     \  *))  *  .'
      '-.((*_.-'
                ");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            Terminal.ClearScreen();
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        if (input.Equals("1"))
        {
            level = 1;
            StartGame();
        }
        else if (input.Equals("2"))
        {
            level = 2;
            StartGame();
        }
        else if (input.Equals("3"))
        {
            level = 3;
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid file");
            Terminal.WriteLine(menuHint);
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
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
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("INVALID!");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayScreen();
        }
        else
        {
            StartGame();
        }
    }

    void DisplayScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You Successfully hacked Lucas Films database");
                Terminal.WriteLine("You received Episode V Plot Twist File");
                Terminal.WriteLine(@"      
     _-------_
    /'        `\
   | _--_  _--_ | I AM YOUR FATHER!
   |/-___||___-\|
  / \___-||-___/ \
 /   \  .HH.  /   \
/-----\'HHHH`/-----\ '    
    "
                );
                break;
            case 2:
                Terminal.WriteLine("You successfully hacked DC database");
                Terminal.WriteLine(@"
     ___     |\__/|     ___
   / 888~~\__(8OO8)__/~~888 \
  /88888888888888888888888888\
 |8888888888888888888888888888|
 \8888/~\88/~\8888/~\88/~\8888/
  \88/   \/   (88)   \/   \88/
   \/          \/          \/        
        "
                );
                break;
            case 3:
                Terminal.WriteLine("You successfully hacked Sony!");
                Terminal.WriteLine("You received a PS4 code");
                Terminal.WriteLine(@"
   ________________
  |   |,'    `.|   | in menu
  |   /  SONY  \   | type egg 
  |O _\   />   /_  |   __  __
  |_(_)'.____.'(_)_|==(+)oo(+)
  [___|[=]__[=]|___]  //    \\
    "
                );
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
