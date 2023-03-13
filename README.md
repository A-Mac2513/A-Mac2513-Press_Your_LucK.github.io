# PRESS YOUR LUCK APPLICATION 
 School Assignment - Faux Gambling Card Matching App
 Inline-style: ![alt text](https://github.com/A-Mac2513/A-Mac2513-Press_Your_LucK.github.io/blob/main/Images/icon.ico "Icon Logo")
 ___
 # ABOUT

 > This app a simple betting game that uses sessions, serialization and cookies to keep track of most of the information in this game.
 
 > ### The following highlights some of the techniques you will be employing in this assignment.  
 >	The current player name and their total number of current coins will be stored in a cookie so that it can persist across sessions
 >	The current game state (for the current player) will be stored in a Session
 >	Essentially a game consists of a List of (randomly generated) Tile objects. 
 >  You will use the `NewtonSoft.Json` package to serialize/deserialize the current game to/from the session as Json strings.
 >	You will implement some static helper methods along the way to make it easier to interact with the required Session & Cookie data
 >	__NOT IMPLEMENTED YET__ Once that is all working you will build on the solution to store an audit trail in a SQL server database


 ___
  # Game Play
 > To start with, you enter your Name and the number of coins you’re starting with.
 > To start playing, you choose how many coins to bet, then 12 tiles are shuffled face down.
 > Each round you either choose a tile or take the coins you’ve won so far.  
 > If you choose a tile and it shows 0, you bust and lose your bet.  
 > If it has a number, your bet is multiplied by that number and the remaining tile values are doubled.
 > Once you choose to take the coins, the amount is added to your total coins, and you can start a new game or cash out and stop playing.
 > In addition to this, you’ll also create audit records to keep track of winnings and losings.

___
 # Repository
 ## If you wish to navigate my repo and you find your self at the [base page](https://github.com/A-Mac2513/):
 > Find the __Press Your Lcuk Repo__ and click.
 > Then you should be at the root of the repo. if you are unable to find the repo [click here](https://github.com/A-Mac2513/A-Mac2513-Press_Your_LucK.github.io).
 > From here you can go to the [app root folder](https://github.com/A-Mac2513/A-Mac2513-Press_Your_LucK.github.io/tree/main/PressYourLuck).
 > Or you can view the LICENSE, README, OR WIKI.
 > The Azure deployment [yaml file](https://github.com/A-Mac2513/A-Mac2513-Press_Your_LucK.github.io/tree/main/PressYourLuck/.github/workflows) can be found here. This is what is used to set up the cloud enviroment for hosting the app.
 > The [Domain objects](https://github.com/A-Mac2513/A-Mac2513-Press_Your_LucK.github.io/tree/main/PressYourLuck/Models) can be found in the Models directory.
 > The HTML pages can be found in the [View directory](https://github.com/A-Mac2513/A-Mac2513-Press_Your_LucK.github.io/tree/main/PressYourLuck/Views)
 > And all the business logic can be found in the [Controllers directory](https://github.com/A-Mac2513/A-Mac2513-Press_Your_LucK.github.io/tree/main/PressYourLuck/Controllers) 

___
# For Developers
## Guidelines
> I only ask that you don't change the database structure, or which database is used.
> Keep the cookies and session storage objects being kept in the user's browser.
> You may change any images that you wish, just do not delete the old ones.
> All pull requests and commits will first have to be approved by a repo moderator.

## Testing
> Testing can be done using Selenium or NUnit.
> If using NUnit, ensure the program code has Dependency Injection set up in order to test Cotrollers.
> Any found issues can be submitted under the [Issues tab](https://github.com/A-Mac2513/A-Mac2513-Press_Your_LucK.github.io/issues)

## Building and Deploying the App
### Local Deployment
1. You can build and deploy the App locally by right-clicking the project name and then selecting "Publish"
2. Then select "Folder"
3. Usually the default Folder Location is sufficient, however you may choose the create the Folder any where on your hard drive.
4. Click __Finish__
5. Next the app is ready to publish so click __Publish__
6. After the app has build and published you can click the link to go directly to the new folder by clicking __Open Folder__
7. Locate the __PressYourLuck.exe__ file
8. This is what will allow you to use the [url](http://localhost:5000) or the [secured url](https://localhost:5001)
9. As long as the .exe file is running, any device connected to your local network can run the application in their browser.

### Cloud Deployment
1. Create a GitHub repo
2. Clone that repo to the ASP.NET Core project directory
3. If the application is ready for deployment, run `git add .` , then `git commit -m "<Enter Description here >"` , then `git push`
4. Navigate to the Azure Portal, and sign in
5. Choose __Web App__ to make a new web application
6. Enter the app name, what you are publishing (Code, Docker), the runtime stack, which is the .NET version of the project you made, and the Operting System you wish to use for the app
7. After clicking __Create__ when the page reloads click __Get Publish Profile__
8. This will download a file, open it and copy its content
9. Navigate to GitHub and your repo, click __Settings__
10. On the left side locate __Secrets and Variables__ and click
11. Click on __New Repository Secret__
12. Past the contents you copied to the file body
13. Name the repo Secret
14. Commit the changes
15. Go to the __Actions__ tab
16. Choose a workflow template. For this app: __Deploy a .Net Core app to an Azure Web App__
17. Click __Configure__
18. You can choose the `on:` event that triggers the workflow to run
19. Navigate to `deploy:, steps:, name: Deploy to Azure Web App, with:, publish profile:` and enter \"secret\.<the name you gave the \.yaml file>\"
20. Commit the changes, this will trigger the workflow and the app should be deployed
21. Copy the URL from the Azure Portal for the app
22. This link is how you can run and app

___
#CI/CD, Future Enhancement/Bug Fixes
> The way we deployed the app ensures is a Constant Integration/Constand Deploment pipeline.
> This repo is set up that any workflows triggered by a push, must be reviewed and approved before being integrated
> There will be a second branch created for testing and bug fixing
> Once a workflow has been approved it is automatically published to Azure.

___
# How to \'RUN\' the App
> The link that is given to you on the Azure portal is how this app is \'run\'.  By just clicking it you can play the game.

