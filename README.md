# winFormsClassChat

For my Senior Project, I needed to create something that would take the skills I had learned over the years and challenge myself to learn even more. I came up with the idea for an application that would help connect classmates instantly.

 Powered by a SQL Server database and a windows console application hosted on a Virtual Machine off campus, class chat was a windows forms application that allowed users to create an account and enter the courses they were currently taking. For each class, a button would appear, which when clicked would bring them to a window with a chatroom. These chatrooms connected to the console application via a tcplistener. The server application kept a record of each connection in a dictionary along with a string sent by the client machine to identify which chatroom they belonged to, and  used this dictionary to forward messages to the appropriate chatrooms. 

I also wanted to allow for some kind of file transfer service, to allow the sharing of class notes or other important pieces of information, but was not able to accomplish this feat within the semester. However, it is a project I plan on returning to in the near future. 
