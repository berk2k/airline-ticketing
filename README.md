# Design:
 # Purpose and Scope of the project:
    Purpose of the project is creating an airline ticketing transactions using web services.
   # The project offers several functionalities:
      1- Get, update , delete and create flights.
      2- Query tickets with date, from, to, and number of people.(Supports pagination)
      3- Booking tickets with flight no, date, from, to, and passenger name.
      4- Login and register for authentication.
 # Authentication:
    For authentication, I used JWT tokens.
    When user login, token will be given to user.
    There are 2 types of users, admin and passenger.
    Admins have access to all API endpoints.
    Passengers can only access query ticket, book ticket, login, and register endpoints.
 # Pagination:
    Users can query tickets with pagination.
 # Versioning:  
    The project has two versions.
    v2 has some differences than v1. 
    For example: In v1 user can get flight with flight id, In v2 user can get it with flight number.
    
 # Assumptions:
    In the booking ticket part, it was requested to book a flight with date, from, to, and passenger name.
    However, I added a flight number to prevent any confusion because there could be multiple flights with the same date, from, and to.

 # Issues encountered:
    1- I struggled with how to start the project at first due to a lack of practice. So, I took a course about REST APIs. First, 
      I developed the project from the course and tried to understand the structure of the REST API. Then, I developed the project using the example I received from the course and the example provided in the class.
    2- Adding dependencies to the config file, I encountered some errors that drove me insane because I forgot to include them in the program.cs file. I asked ChatGPT and corrected it.
    3- I got some mapping errors because I forgot to install AutoMapper.


# Data Model

    ![image](https://github.com/berk2k/se4458_midterm_19070006043/assets/96010671/3c223a66-556c-4512-8769-19b36ffe6aca)

