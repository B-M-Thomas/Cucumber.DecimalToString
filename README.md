# Cucumber.DecimalToString

I have used a dotnet core web api which is communicated to via a React SPA. To Run the solution simply open in Visual Studio and run the App Project. 
This will start the React Application along with the Web API.

I used a static approach creating a static helper class for doing the conversion work along with creating a decimal extension method to make using the converter simple and easy to read.
I opted for the recursive approach over the iterative approach.

Credit to StackOverflow here: https://stackoverflow.com/questions/794663/net-convert-number-to-string-representation-1-to-one-2-to-two-etc

Modifications were made to the code to fit the requirement. I was unsure by the hypenating between numbers as there were not enough examples to understand it
therefore I have chosen to mitigate them.




