This project provides an example form that looks and behaves very much like the SQL Server Login form you see in SQL Server Management Studio, SQL Server Profiler, and other products Microsoft provides that logs on to SQL Server.
It does not "share" the saved credentials with the Microsoft products.  It stores those credentials in User Specific Settings for the specific application.
Passwords are encrypted using the Windows Machine key (DPAPI), therefore this code will not work if used on Linux.
