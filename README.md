# What is it?

This is a **demo** for mongodb provider for the EntityFramework Core made by Chris Hairr (Thanks Chris!).

EFCore MongoDb provider repo: https://github.com/crhairr/EntityFrameworkCore.MongoDb

# Architecture

The demo follows uncle Bob **Clean Architecture** (and Steve Smith explanation of N-Tier apps) to achieve a point where projects are not tighly coupled.

![](/images/architecture.png?raw=true)

### EFMongoDemo.Core

It is where the **entities and interfaces** are located.
    
### EFMongoDemo.Data

This is the place where the application communicates with the **database**, and the mongodb provider goes here too.
	
### EFMongoDemo.Web

The web application which has the **UI**.

### EFMongoDemo.Tests

Tests for all previous projects. MSDN recommends to use a seperate test project for each project, but it will just make VS much slower.