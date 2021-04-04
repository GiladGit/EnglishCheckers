# EnglishCheckers  
////////////////////////////////////////////////////////  
To play the game go to: EnglishCheckers\GUI\bin\Debug  
Then download: GameAPI.dll, GameLogic.dll, GUI.exe  
Open GUI.exe to start the game.  

////////////////////////////////////////////////////////  
Code:  
The Solution is divided into 3 projects: 2 dlls + 1 winform project.
  

The GameLogic.dll contain all the logic of a checkers game.  
GameLogic.Game class provides the interface to interact with the dll.  

The GameAPI.dll manages the Server - Client code:  
It holds the server code which contains an instance of the GameLogic.Game class and update clients about game development and competitors chat msgs  
And provides the interface the GUI needs inorder to request commands from the server, through the GameInterface class.  

The GUI project holds all the game forms and the GUI.FormsManagement.cs class which contains nevigation between forms logic.  
