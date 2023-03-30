For This Assignment I decided to Create A Distributed system on the flights booking of Ryanair and Aer Lingus. I decided to do an Airport Booking form because having a distributed system will allow users to seamlessly book flights with multiple airlines and pay using their preferred payment method. This creates a more conveniant
booking process for users.
This will also increase efficiency and decrease errors that are usually caused by a manual booking process. which can lead to reduced costs, faster booking times and a more reliable service.

The requirements for This Distributed system to be developed is to include concepts such as concurrency, Fault tolerance, Process Scheduling, Scalability, transparency, and Latency.

The ones that will be included in this Distributed system are Concurrency, Fault Tolerance, Scalability and Latency.

One issue that had to be overcome was preventing Deadlocks. This is when a process requests a resource while it already is holding another one.
to prevent this I decided to make it so the web APIs are Stateless. This is when requests are done in complete isolation. which means that the servers never rely on information from previous requests.

The distributed system goes through a set steps each time a booking is made.
1.) the system creates an unconfirmed booking in the designated web service(either AirLingus or Ryanair).
2.) takes the payment Visa via the VISA web service.
3.) Confirms Booking in the designated web service from step one.

If the first step comes back as false, then no booking is made.
If the second step comes back as false, then no payment is made, which means the booking remains unconfirmed. The back-end system then removes the bookings.
If the first 2 steps come back as true then the booking is confirmed.

I decided to design the distributed system by using 3 Databases in sql server management studio, and 4 visual studio projects. 
The databases were Air Lingus flights, RyanAir flights, and the VISA payment databases. While the projects were 1 windows form app, and 3 asp.net core web API.

The windows form app was the Main project. It includes all the visual components that are used.
The 3 asp.net web APIs are used for a database each. 

My distributed system utilises HTTPS (Hypertext Transfer Protocol Secure) to ensure that all communication is encrypted and secure. 
All data exchanged between the client and the server is protected by SSL/TLS encryption, which prevents the data from being accessed or tampered by unauthorised parties.   

My analysis of this distributed system is that it includes many of the properties of a distributed system. Mainly Concurrency, Process Scheduling, Scalability, and Latency.

Concurrency & process Scheduling is being used because the web services are being called Asynchronously. This is done using async and await commands.
The web services are called in parallel. this is so the client can continue requesting while the UI is not affected.
I also use the Marshaling that is handled by the .net Core to reformat the data when needed. This is also done in parallel so it doesnt effect the client.

Scalability is covered due to the ability to create additional web servers to balance the load without sacrificing performance or reliability.

Latency is influenced behind the scenes. It is improved by calling the web services and marshsaling in parallel, increasing the number of web servers used in load balancing.

After my analysis I have come to the conclusion that there are a number of benefits and trade-offs for each possible design. 
While my distributed system can be easily scaled as needed, has improved performance due to concurrency and latency. it also has some big trade-offs, such as
an increased complexity, increased cost, and a split security due to each server needing their own security.

from this I believe that my systems benefits outweigh the trade-offs. however with a big enough company or system the trade-offs could my mitigated to a degree.

