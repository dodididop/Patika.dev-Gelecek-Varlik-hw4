# Patika.dev & Gelecek Varlık Full-Stack Bootcamp HW4
Briefly, created web api and LoginFilter attribute, filtering, sorting and pagination were implemented.


## Table of contents
* [General-info](#general-info)
* [Technologies](#technologies)


## General-info
### The behind of the story of the web api implementation
The database first approach was implemented. So, I created relational schema; 
- 3 tables: CUSTOMER, USER, DOCUMENT, and 
- Their relations are based on each CUSTOMER has many USERS, but each USER has only one CUSTOMER, and each DOCUMENT has only one USER, but each USER has many DOCUMENTS. 
- Connect with entity framework.
- Implemented endpoints.
- Filtering, sorting and pagination were created in one method.
- Login filter attribute was added.
	
## Technologies
Project is created with:
* .Net Core 5.0.403
* Sql Server 2019
	
