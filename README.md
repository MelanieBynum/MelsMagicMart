# Mel's MagicMart
A small supermarket simulator.
---------------------
This was my penultimate assignment in my C# class. The UWP receives all the shopping cart information from the Shopping Cart API. The API will save the contents of the cart while the API is still running. You may close out of the UWP client and reopen it and your items should still be present. I run Mel's MagicMart in Visual Studio 2019. All of my descriptions assume you are also using this application to run Mel's MagicMart.

If you are setting this up on your local machine, these are the steps you will need to take to properly run Mel's MagicMart:
1. Download the UWP and API and open them in VS2019 as Administrator. If you do not open as Administrator, Windows may not allow you to run the API.
2. Within the UWP (Dynamic Buttons solution), you will need to Rebuild the solution, which is located under the "Build" tab. 
3. In the API, go to the Solution Explorer. Under Dependencies/Assemblies, there may be a "ShoppingCartLibrary" reference that is invalid. Delete it and readd it by right clicking on Dependencies and hitting "Add COM Reference".
4. Within the Reference Manager, click "Browse" and find the MagicMartUWP on your system. Navigate into the folders until you see "Dynamic Buttons" and "Shopping Cart Library". Go into the "Shopping Cart Library" folder, "Bin", and continue navigating until you find the "ShoppingCartLibrary.dll". Select the dll and hit Add. This will add in the library necessary for the API.
5. Mel's MagicMart should now be available to use! Whenever running Mel's MagicMart, always run the API first and then the UWP. Happy shopping!
---------------------
Some features of Mel's MagicMart include:
- Products organized by quantity and by weight
- Clearing the contents of your cart
- Adding new items to your cart or additional quantity/weight of an existing item to your cart
- Removing items altogether or partial removal of items
- Seeing a list of all items currently in your cart
- "Checking out" and having your itemized receipt saved as a text file locally
- Updates the API when you make changes to your cart
- UWP receives lists of products within the supermarket from the API
---------------------
Please let me know if you have trouble using this application. I will upload a video explaining my code and giving a small walk through of the application soon. Enjoy!
