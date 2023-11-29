# Design:
   **Purpose and Scope of the project:** <br/>
    Purpose of the project is creating an airline ticketing transactions using web services.<br/>
   **The project offers several functionalities:**<br/>
      1- Get, update , delete and create flights.<br/>
      2- Query tickets with date, from, to, and number of people.(Supports pagination)<br/>
      3- Booking tickets with flight no, date, from, to, and passenger name.<br/>
      4- Login and register for authentication.<br/>
 **Authentication:**<br/>
    For authentication, I used JWT tokens.<br/>
    When user login, token will be given to user.<br/>
    There are 2 types of users, admin and passenger.<br/>
    Admins have access to all API endpoints.<br/>
    Passengers can only access query ticket, book ticket, login, and register endpoints.<br/>
  **Pagination:**<br/>
    Users can query tickets with pagination.<br/>
  **Versioning:**  <br/>
    The project has two versions.<br/>
    v2 has some differences than v1. <br/>
    For example: In v1 user can get flight with flight id, In v2 user can get it with flight number.<br/>
    
 # Assumptions:
    In the booking ticket part, it was requested to book a flight with date, from, to, and passenger name.<br/>
    However, I added a flight number to prevent any confusion because there could be multiple flights with the same date, from, and to.

 # Issues encountered:
    1- I struggled with how to start the project at first due to a lack of practice. So, I took a course about REST APIs. First, <br/>
      I developed the project from the course and tried to understand the structure of the REST API. Then, I developed the project using the example I received from the course and the example provided in the class.<br/>
    2- Adding dependencies to the config file, I encountered some errors that drove me insane because I forgot to include them in the program.cs file. I asked ChatGPT and corrected it.<br/>
    3- I got some mapping errors because I forgot to install AutoMapper.<br/>


# Data Model

    ![image](https://github.com/berk2k/se4458_midterm_19070006043/blob/master/dm/dm.JPG)
# Video
https://se4458storageaccount.blob.core.windows.net/19070006043midtermvideo/19070006043_se4458midterm.mp4

