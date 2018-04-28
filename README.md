# EtlDemo
Simple ETL project using C# and some existing NuGet packages to transform and load data

# Overview:

This repository contains code for simple ETL project that uses C# to import data from a file, transform it, 
and output the data to a file and a database table.  

Some of the technologies involved include:
- [Rhino-Etl](http://hibernatingrhinos.com/oss/rhino-etl)

# Local Setup:

Initial Setup:
- Download or clone the repository and open it in [Visual Studio 2017](https://www.visualstudio.com/downloads/).  
- Rebuild the solution.
- If you want to load the data into a database, then you will need to have that database created first.  A sql script file is included in the project to create the appropriate target table in the database.

Running the solution:
- Run the solution.
- You should see results in the data/output directory as well as the database table.  There are also logs written to the logs directory.
