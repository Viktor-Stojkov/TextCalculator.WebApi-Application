# TextCalculator.WebApi-Application

There are two ways to run the application:

1. With run from Visual Studio<br><br>
	1.1. To run the Web application<br>
	   - Open Visual studio<br>
	   - Open the solution with visual studio<br>
	   - Set TextCalculator project as startup project<br>
           - Run the project<br>
 	   This will open instance of chrome with the view for entering the number<br>

	1.2. To run the Web Api<br><br>
	   - Open new instance of Visual Studio<br>
           - Open the solution in the new instance of Visual Studio<br>
	   - Set the TextController.WebApi project as startup project<br>
	   - Run the project<br> 
	   This will open new instance of chrome and display the api/swagger.
 
	NOTE: Without the Api running, you won't be able to test the application
    	

2. With website created from IIS
	1. Create new folder Debug in C:/ 
	2. Create new folder TextControllerApi in C:/Debug folder
	3. Follow the following instrunction to configure the DNS and set up the IIS website https://www.dnnsoftware.com/docs/administrators/setup/set-up-dnn-folder.html
	4. Enable and set up IIS https://www.dnnsoftware.com/docs/administrators/setup/set-up-iis.html
        5. Create new website https://textcalculatorapi.mk
        6. Open the solution with visual studio
	7. Right click on the TextController.WebApi -> Publish -> Folder -> Set the path to the C:/Debug/TectControllerApi
	8. Click on publish
	9. Open web browser and type https://textcalculatorapi.mk
	- This needs to open the api/swagger in the web browser
	11. In C:/Debug create TextCalculator folder
 	12. Create new website for the web application https://textcalculator.mk in IIS
        13. Right click on the TextController -> Publish -> Folder -> Set the path to the C:/Debug/TectController
	14. Click on publish
	15. Open web browser and type https://textcalculator.mk
	- This needs to open the application in the web browser
	NOTE: Make sure that the api is running in order to manually test the application
