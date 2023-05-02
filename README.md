# WebApiTrainingApp

## Goals of Application 

The long term goal goes well beyond the scope of this Readme file. 

To start, I want to design a web api to perform CRUD operations on the model entities that will reside in an SQL database. The initial underlying model will include entities for simulators, rctd lots, rctd man modules, hardware and software components, and the versions of those components.

Other entities and database tables will include abstractions, such as a Platform Table to separate information by individual platform. Another example will be a Status Table, where different status conditions can be defined and assigned to the other entities in the database. 

Care will be taken to abstract the tables as much as practical to allow for customization.  