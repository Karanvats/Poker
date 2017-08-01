# Poker
Poker kata solution Console based app C#


Similar input format from the code exercise instructions:
Black: 2H 3D 5S 9C KD White: 2C 3H 4S 8C AH
Black: 2H 4S 4C 2D 4H White: 2S 8S AS QS 3S
Black: 2H 3D 5S 9C KD White: 2C 3H 4S 8C KH
Black: 2H 3D 5S 9C KD White: 2D 3H 5C 9S KH

Design :

Since the solution of the problem was simple enough it wasn't nessassary to create a whole design which would only consume time .

Solution proposed has following classes:

Card- it represents every card with suit and value associated with it .it extends Icomparable interface that helps with the sorting based on the value not the suit
 	
Player class is responsible to get the cards from the input selection and preparing the hand value with sorted cards.

Game class contains list of player at the table and each player has certain no of cards in hand. 

GameEntry class is the main execution thread class which Communicates with the user through Console window .There are centain limitations ont he input format needed for execution

Workflow:
Application accepts input from user for no of players on the poker table
new game class is initialized with memory allocated based on the user input .If input is non parsable then the application shows that input is invalid and loops back
then it loops to get player name and then the hand values for the users .the string is split into a jagged array containing all different hands
the jagged array is looped and each player card is set based on input .
If any of the input suit value is invalid it will error out and loop back to starting of the game
when all the hands are accoundted for then game class calculates and compares each hand value to another based on handranking.
if the hand ranking is same then the high card values are compared.

Its a console based app c# solution file is checked in along with the unit test cases .download the files to the drive and open the solution file in visual studio .
Build and run 
Enjoy!!!
