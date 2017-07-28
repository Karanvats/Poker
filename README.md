# Poker
Poker kata solution Console based app C#

Design :

Since the solution of the problem was simple enough it wasn't nessassary to create a whole design which would only consume time .

Solution proposed has following classes:

Card- it represents every card with suit and value associated with it .it extends Icomparable interface that helps with the sorting based on the value not the suit
 	
Player class is responsible to get the cards from the input selection and preparing the hand value with sorted cards.

Game class contains list of player at the table and each player has certain no of cards in hand. 

GameEntry class is the main execution thread class which Communicates with the user through Console window .There are centain limitations ont he input format needed for execution

Similar input format from the code exercise instructions:
Black: 2H 3D 5S 9C KD White: 2C 3H 4S 8C AH
Black: 2H 4S 4C 2D 4H White: 2S 8S AS QS 3S
Black: 2H 3D 5S 9C KD White: 2C 3H 4S 8C KH
Black: 2H 3D 5S 9C KD White: 2D 3H 5C 9S KH


Execution:

Its a console based app c# solution file is checked in along with the unit test cases .download the files to the drive and open the solution file in visual studio .
Build and run 
Enjoy!!!
