For This Assignment I decided to Create A Distributed system on the flights booking of Ryanair and Aer Lingus. I decided to do an Airport Booking form because having a distributed system will allow users to seamlessly book flights with multiple airlines and pay using their preferred payment method. This creates a more convenient
booking process for users.

There are a number of reasons why you would use a distributed approach when building a system - some of these concepts are visible in this project. 

The system is designed as a single client application that interacts with a number of distributed web services. I decided to design the distributed system by using 3 Databases in Sql Server, and 4 C# .Net projects. 
- The databases were Air Lingus flights/booking, RyanAir flights/booking, and the VISA payment database. 
- The projects were 1 Windows Forms app, and 3 ASP.Net Core Web API's - one for each of the databases.

The windows form app was the Main project. It includes all the visual components that are used.
The 3 asp.net web APIs are used for a database each. 

The functionality of the system is as follows:
1.) the user can enter dates for a return airline journey and search for available flights for those dates
2.) flights are retrieved from both RyanAir and Aer Lingus -by calling their Web API's
3.) the user can select return flights and is then able to enter booking/payment information
4.) the system will then book the flights on the relevant airline and write a record to the VISA database (using it's API)

My distributed system utilises HTTPS (Hypertext Transfer Protocol Secure) to ensure that all communication is encrypted and secure. 
All data exchanged between the client and the API's is protected by SSL/TLS encryption, which prevents the data from being accessed or tampered with by unauthorised parties.

The use of web services means that the system could scale if required (by adding more load balanced web servers). Another issue to be considered was minimising locking. particularly deadlocks. Using Web API's means that we don't have a direct connection from the client to the databases - as such, the client does not lock database resources. In fact, the web APIs are Stateless. This is when requests are done in complete isolation, which means that the servers never rely on information from previous requests.

The key advantages of the approach are in relation to latency and concurrency:
- As the Web API's are called asynchronously, the client does not have to wait on their responses
- Also, this allows API calls to run in parallel - for example, the Aer Lingus call is made (asynchronously) and then the RyanAir call - but both can be running at the same time.

Marshalling is handled by the .Net Core libraries - using methods such as PostAsync in conjunction with async and await commands.

It was also important to try to ensure that updates were kept in sync - so that a booking wouldn't be confirmed without a payment, or a payment made without any record of a booking.

The distributed system goes through a set steps each time a booking is made.
1.) the system creates unconfirmed bookings in the designated web service (either Aer Lingus or Ryanair).
2.) it then takes the VISA payment via the VISA web service.
3.) Only when payment is taken does it confirm the Bookings in the designated web service from step one.

If the first step comes back as false, then no bookings are made.
If the second step comes back as false, then no payment is made, which means the bookings remain unconfirmed. The back-end system could then remove the bookings.
If the first 2 steps come back as true then the bookings are confirmed by updating the bookings with the Payment Reference.

After my analysis I have come to the conclusion that there are a number of benefits and trade-offs for each possible design. 
While my distributed system can be easily scaled as needed, has improved performance due to concurrency and latency. it also has some big trade-offs, such as
an increased complexity, increased cost, and a split security due to each server needing their own security.

from this I believe that my systems benefits outweigh the trade-offs. however with a big enough company or system the trade-offs could my mitigated to a degree.

