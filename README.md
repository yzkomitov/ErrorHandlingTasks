### Error Handling Exercise Tasks:
The project contains a simple console app, which accesses the AdventureWorksLT2022 database directly through Microsoft.Data.SqlClient. You may find, that the code is suboptimal, but your task is not to fix it. Instead, let's keep it simple:

1. Write a try/catch block, catching at least 3 different exception types
2. Use a finally block
3. Use exception filters on at least one of the caught exceptions
4. Rethrow the exception if it is a System.Exception
5. Create a custom exception and use the .Data property to pass additional data to your custom exception. You can change the if(false) block so your execution reaches adoDbReader.ExecuteNonQuery() and use the thrown SqlException for this purpose. Of course, feel free to do something else.
6. Bonus Question: What does the StaticClass.DoWork method do?