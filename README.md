# Capital-Placement-Interview-Project
---
> Brief explanation of updates made
- So, first off i created a structure for the project, defined folders such as Extensions, Services, Repositories and the likes to establish separation of concerns.
- I then configured cosmos with entity framework core, defined my models and then my DTOs.
- Then I started creating my repositories, after that i implemented some extension methods for registering my services in the service container.
- I created controllers followed by handlers encapsulating validation logic for controllers where necessary
- I configured swagger for easy api documentation and interaction, i also added log4net for logging.
- There's also a postman collection i included to ease testing.
