# Contact Information Api
* A simple ASP.NET Web API service for Contact Information.
* Swashbuckle is used for display purposes, endpoint testing, sample json data, and simple documentation.
* There are five simple endpoints used for Creating, Reading, Reading All, Updating, and Deleting the Contact information.
* The project has a "Seed.cs" class to populate with dummy data.
* The project uses Entity Framework Core In-Memory database.
* All of the external dependencies are available via Nuget packages.
# Using the API
* This API was built using Visual Studio 2022. When built/ran it will navigate to the Swashbuckle page for a basic documentation of the API. All of the following instructions can also be found on the Swashbuckle page in more detail. Note: the ID within the URL and the "Seed.cs" objects must match.
* It is strongly recommended to use the Swashbuckle documentation page for endpoint testing, and example data sets.
  * Creating a new contact. POST https://localhost:7094/api/Contact with a Contact object in the body.
  * Retrieving all contacts. GET https://localhost:7094/api/Contact
  * Retrieving a single contact. GET https://localhost:7094/api/Contact/{id} with the ID of the contact in the url
  * Updating a single contact. PUT https://localhost:7094/api/Contact/{id} with the ID of the contact in the url, and the contact json object in the body.
  * Deleting a single contact. DELETE https://localhost:7094/api/Contact/{id} with the ID of the ontact in the url
