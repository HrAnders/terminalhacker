using UnityEngine;

public class Hacker : MonoBehaviour {

    //Game configuration data
    const string menuHint = "You may type menu at any time";
    string[] level1Passwords = { "human", "life", "virus", "heart", "breath", "android" };
    string[] level2Passwords = { "astronaut", "rocket", "planet", "telescope", "alien", "starsign" };
    string[] level3Passwords = { "nuclear bomb", "machine gun", "sub marine", "shield dome", "weapon test" };


    //GameStates
    int level;
    string password;
        //Define the enum for different screens
    enum Screen { MainMenu, Password, Win }
        //Declare variable Screen named currentScreen
    Screen currentScreen;


    // Use this for initialization
    void Start () {
        ShowMainMenu();
    }

    void ShowMainMenu ()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Obelisk Security");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Welcome to Obelisk Security.");
        Terminal.WriteLine("Please choose your entrance path:");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Press 1: GoTo Human Labs - Easy");
        Terminal.WriteLine("Press 2: GoTo Space Labs - Medium");
        Terminal.WriteLine("Press 3: GoTo Weapon Labs - Hard");

        Terminal.WriteLine("Your decision: ");

    }

    void OnUserInput(string input) //Only decides what to do on user input
    {
       
        if (input == "menu") //you can always go to MainMenu
            {
            ShowMainMenu();
            }

        else if(currentScreen == Screen.MainMenu) //if the current screen is the MainMenu, then look for user input and decide by checking inputs in RunMainMenu
        {
            RunMainMenu(input);
        }

        else if(currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3"); // || stands for OR
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }

        else
        {
            Terminal.WriteLine("Take a correct path or enter your code.");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        //Set variable currentScreen to Screen.password
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password. Hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {

            case 1: //number 1 declares level number
                int index1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index1];
                break;
            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index2];
                break;
            case 3:
                int index3 = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index3];
                break;
            default:
                Debug.LogError("Ivalid level number");
                break;

        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
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
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine(@"
**********************************
* .-. .-. .-. .   .-. . . .-. .-. *
* |-| |-' |-' |   |-| | | `-. |-  *
* ` ' '   '   `-' ` ' `-' `-' `-' *                      
**********************************                      
");
            break;

            case 2:
                Terminal.WriteLine(@"
 #     #                       
  #   #  ######   ##   #    #  
   # #   #       #  #  #    #  
    #    #####  #    # ######    
    #    #      ###### #    #     
    #    #      #    # #    #  
    #    ###### #    # #    #  
");
                break;

            case 3:
                Terminal.WriteLine(@"
        |
       / \
      / _ \
     |.o '.|
     |'._.'|
     |     |
   ,'|  |  |`.
  /  |  |  |  \
  |,-'--|--'-.| 
    Good job!
");
                break;
        }
        
    }
}
