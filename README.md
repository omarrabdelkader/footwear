# restAPIDotNet6

## Introduction 
I have been developing numerous rest APIs in different technologies. restAPIDotNet6 is a rest API of a shoes store where you can display this API in your website by fetching the data. I will expounding in details every code line in this project.

## Shoes Class
Shoes Class is a public class where it contains properties of the SQL table. This class is a blue-print, or a schema where it defines fields of the table, as well as the data type of values that each coloumn will receive. 

## DataContext Class
We have used Microsoft.EntityFrameWorkCore which helped us to use the DbContext which is the heart of Entity Framework. We have created a DataContext class and derived it from DbContext base class. Then, we have created a constructor in order to create an object options. DbContextOptions carries the configuration information needed to configure the DbContext, and it will be used in the program.cs file in order to configure it. 
DbSet represents all the entities in the context and we have exposed the DbSet property to become a part of the context.

## Program Class
We register the DataContext in the dependency injection as we will be using it in the controller file. Over and above that, we have configured a connection to the Microsoft SQL Server using the GetStringConnection method.

## Controller
