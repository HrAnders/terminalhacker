using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    enum Screen { NameScreen, MainScreen, GameScreen, WinScreen, SecretScreen }; //Liste der einzelnen Bildschirme
    Screen currentScreen; //Variable für den Bildschirm
    int level; //Variable für das Level
    string Username; //Variable für den Nutzernamen
    string password;
    List<string> level1passwords = new List<string> {"Lupe", "Stift", "Rechner", "Lineal", "Brille"};
    List<string> level2passwords = new List<string> { "Virus", "Bakterium", "Erreger", "Ausbreitung", "Übertragung" };
    List<string> level3passwords = new List<string> { "Raketensilo", "Abschussrampe", "Explosionsradius", "Nachtsichtgerät", "Tarnvorrichtung" };



    void Start() // Startbildschirm
    {
        Terminal.ClearScreen();
        currentScreen = Screen.NameScreen;
        Terminal.WriteLine("Willkommen im Octagon-Netzwerk");
        Terminal.WriteLine("");
        Terminal.WriteLine("Bitte geben Sie Ihren Namen ein:");   
    }

    void ShowMainMenu() //Hauptmenü
    {
        RunMainMenu();
    }

    void StartGame() //startet Spiel je nach Leveleingabe
    {
        Terminal.ClearScreen();
        currentScreen = Screen.GameScreen;
        Terminal.WriteLine("Bitte geben Sie das Passwort ein. Tipp:" + password.Anagram());
    }

    void RunMainMenu() //Hauptmenü wird angezeigt
    {
        MainMenu();
        ReachSecretLevel();
    }

    void ReachSecretLevel()
    {
        if (level1passwords.Count == 0 & level2passwords.Count == 0 & level3passwords.Count == 0)
        {
            ShowSecretLevel();
        }
    } //Voraussetzungen zum Erreichen des Geheimlevels

    void ShowSecretLevel()
    {
        currentScreen = Screen.SecretScreen;
        Terminal.ClearScreen();
        Terminal.WriteLine("Sie haben die versteckte Ebene         erreicht!");
        Terminal.WriteLine("");
        Terminal.WriteLine("Leider ist diese aber noch nicht fertig :)");
    } //Aufbau des Geheimlevels

    void MainMenu()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.MainScreen;
        Terminal.WriteLine("Octagon-Netzwerk");
        Terminal.WriteLine("");
        Terminal.WriteLine("Willkommen " + Username);
        Terminal.WriteLine("");
        Terminal.WriteLine("1. Grundlagenforschung " + "(" + level1passwords.Count + " verbleiben)");
        Terminal.WriteLine("2. Biochemielabor " + "(" + level2passwords.Count + " verbleiben)");
        Terminal.WriteLine("3. Waffenforschung " + "(" + level3passwords.Count + " verbleiben)");
        Terminal.WriteLine("4. Benutzer wechseln");
        Terminal.WriteLine("");
        Terminal.WriteLine("Bitte wählen Sie ein System:");
    } //Aufbau des Hauptmenüs

    void OnUserInput(string input) //Eingaben des Benutzers werden geprüft
    {
        if (currentScreen != Screen.NameScreen & input == "Menü")
        {
            ShowMainMenu();
        }
        
        else if (currentScreen == Screen.NameScreen)
        {
            SetUsername(input);
        }

        else if (currentScreen == Screen.MainScreen)
        {
            ChooseLevel(input);
        }

        else if (currentScreen == Screen.GameScreen)
        {
            CheckPassword(input);
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            currentScreen = Screen.WinScreen;
            Terminal.ClearScreen();
            Terminal.WriteLine("Sehr gut.");
            level1passwords.Remove(password);
            level2passwords.Remove(password);
            level3passwords.Remove(password);
            PasswordMessage();

            ShowMenuHint();
        }
        else
        {
            StartGame();
            Terminal.WriteLine("");
            Terminal.WriteLine("Bitte geben Sie das korrekte Passwort  ein.");
            Terminal.WriteLine("");
            ShowMenuHint();
        }
    } //Die Eingabe des Benutzers wird überprüft

    void PasswordMessage()
    {
        if (level == 1)
        {
            Terminal.WriteLine("Verbleibende Passwörter der ersten     Ebene: " + level1passwords.Count);
            Terminal.WriteLine("");
        }

        else if (level == 2)
        {
            Terminal.WriteLine("Verbleibende Passwörter der zweiten    Ebene: " + level2passwords.Count);
            Terminal.WriteLine("");
        }

        else if (level == 3)
        {
            Terminal.WriteLine("Verbleibende Passwörter der dritten    Ebene: " + level3passwords.Count);
            Terminal.WriteLine("");
        }
    }

    void ChooseLevel(string input) //Auswahl des Levels
    {
     
        if (input == "1")
        {
                level = 1;
                password = level1passwords[Random.Range(0, 4)];
                StartGame();
        }

        else if (input == "2")
        {
                level = 2;
                password = level2passwords[Random.Range(0, 4)];
                StartGame();
        }

        else if (input == "3")
        {
                level = 3;
                password = level3passwords[Random.Range(0, 4)];
                StartGame();
        }

        else if (input == "4")
        {
            Start();
        }

        else if (input == "Matrix.exe")
        {
            ShowSecretLevel();
        }

        else
        {
            ShowMainMenu();
            Terminal.WriteLine("");
            Terminal.WriteLine("Bitte wählen Sie einen gültigen Pfad.");
        }
    }

    void SetUsername(string input)
    {
 
        if (currentScreen == Screen.NameScreen & input != "1" & input != "2" & input != "3")
        {
            Username = input;
            ShowMainMenu();
        }

        else
        {
            Terminal.WriteLine("Bitte wählen Sie einen anderen         Nutzernamen.");
        }
    } //Speichern des Benutzernames

    void ShowMenuHint()
    {
        Terminal.WriteLine("Tippen Sie 'Menü', um ins Hauptmenü    zurückzukehren.");
    } // Menü-Hinweis

}
