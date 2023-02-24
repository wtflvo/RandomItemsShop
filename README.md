# RandomItemsShop
Project presents Shop with fake items info, that is stored at server DB.
Before using application you need to create DB(currently it is "usersDB"). After that you need to change connection string in ".\DBEntity\UsersDBContext.cs".
To populate DB (ShopTable), and create tables with users info and items, use relative SQL commands in "SQL Queries" folder. For creating tables you also can use DB migration.
  
To Run application you can use VISUAL STUDIO interface, "dotnet run" command etc. After that application will run at http://localhost:5262.
First of all you have to Sign Up, then LogIn and finally you can get access to shop 
