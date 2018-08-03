The InventoryManager project

This is a simple console application written in C#.NET. Its purpose is to take in an input file containing a list of items in the following format:
<Item name> <Item sell-in value> <Item quality value>
This file can have multiple rows of items listed. Each line denotes a unique item. The item name is not required to be case-sensitive.

The output of the program will be a list of the same items but with the Item sell-in and quantity values modified depending on the item name and other factors. The new values will reflect changes after 1 day.

To download the project InventoryManager from GitHub:

1. Create a directory where you wish to place the project.
2. Go in to this directory and right click in it. Select the menu item "Git GUI Here".
3. When the Git GUI comes up, select "Clone Existing Repository".
4. Enter https://github.com/ahmadnb/InventoryManager.git in Source Location.
   Enter the path to the directory you created in Step 1 above, and append the string "\InventoryManager" to it.
   Hit the Clone button and wait until it's done before closing out the Git GUI app.

To run the InventoryManager application in Visual Studio.NET:

5. Open up Visual Studio.NET. I used Visual Studio.NET 2017 to build this application.
6. Go to the menu item File->Open->Project/Solution... and open up the InventoryManager.sln file located in the InventoryManager subdirectory created in Step 4 above.
7. Select the menu item Build->Build Solution.
8. After the project has been built, hit the green triangular start button just below the main menu bar. You will get an error.
9. To correct this error, we need to enter a command line argument: A file containing items that will need to be processed. One has already been included in the project; the file ItemList.txt. You may include this file or any other file that you wish to use. Please use the one included here as an example; feel free to edit it, add to it or remove items from it.
10. To add the file containing items and its path to the command line argument, right-click on the InventoryManager project in the Solution Explorer (NOT on the solution itself) and select Properties. When this comes up, click on the Debug tab on the left side.
11. Enter the full path including the filename of your chosen file containing items to be processed.
12. Hit the Start button again. You will see the results of the processing of the items in the console that comes up. These results will also be recorded in an output file located in the same directory as the item list file you have chosen, but will have the .out extension added to it.