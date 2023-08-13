Book your next stay at AwesomeHotel, a project built with C#/.NET/Dapper!
This is an MVP practice project - a full stack application built with ASP.NET and Dapper using SQL Server locally.
For this app, I focused more on the back end functionality than the front end design.

Features:
The user can easily book a room at AwesomeHotel for their next getaway: Choose from a Single King, Double Queen or a Suite.
The app finds the available rooms for the desired date range and creates a new reservation for those dates.
The user is presented with a 'confirmed success' screen and can view their booking detais, including a unique reservation GUID confirmation number. 

Future Features List:
- Prevent the user from being able to search for a date range that extends at all into the past
- Prevent the user from being able to search for a desired check in date that is prior to the desired check out date
- Create a separate user portal for use by hotel employees, which allows them to look up the guest's info, and reservations.
- The employee portal will also allow the employee to document guest check in, check out, and internal notes
- Add a way to securely store credit card information (such as a Strpe integration), and a way to add info in the database re: when the bill was paid and how much/how much is outstanding 
- For the employee portal 'find guest info' or 'find guest's reservation' feature: Optimize search performance by adding a way to prevent the employee from searching an empty string or anything under 2 letters/characters (otherwise they'll see a bunch of info coming back)
- Probably more
