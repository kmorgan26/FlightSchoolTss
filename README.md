# Flight School TSS

## Goals of Application 

The long term goal goes well beyond the scope of this Readme file. 

To start, I want to design a web api to perform CRUD operations on the model entities that will reside in an SQL database. The initial underlying model will include entities for simulators, rctd lots, rctd man-modules, hardware and software components, and the versions of those components.

Other entities and database tables will include abstractions, such as a Platform Table to separate information by individual platform. Another example will be a Status Table, where different status conditions can be defined and assigned to the other entities in the database. 

Care will be taken to abstract the tables as much as practical to allow for customization. For example, a Configurations Table will be used to build configurations for various other entities. Simulators can be configured with any number of hardware or software components and versions, then create a named configuration that can be associated with whichever simulator or simulator type. These configurations can then be saved in the configuration table and may contain as many or few definitions as desired.

The API Endpoints will be documented to provide the JSON Requests required, and the JSON Results for each request.
