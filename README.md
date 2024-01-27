This project that exposes a REST API to retrieve all models for a specific car. The API should receive a car make and manufacture year, and return all models produced in that year.

Below are step-by-step instructions for setting up and running the .NET Core application locally. Before proceeding, ensure you have the necessary tools installed, including .NET Core SDK and a code editor like Visual Studio Code or Visual Studio.

Steps:
Clone the Repository:

Open a terminal and run the following command to clone the GitHub repository:

git clone https://github.com/fadi1234/Car.Manufacturingfadi

Run the Application:

Test the API Locally:

Open a web browser or a tool like Postman to test the API locally.

Make a GET request to the following URL, replacing make and modelyear with your desired values:

For example:
https://localhost:7201/api/models?modelyear=2015&make=LINCOLN

You should receive a JSON response with the list of models for the specified car make and model year.
