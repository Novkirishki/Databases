# Database Systems - Overview

### 1.What database models do you know?
* Network Model and Hierarchical Model
* Relational Model
* Object-oriented Model
* Object-relational Model

### 2.Which are the main functions performed by a Relational Database Management System (RDBMS)?
A relational database management system (RDBMS) is a database management system (DBMS) that is based on the relational model. The main goal of a RDBMS is to manage data stored in tables.

RDBMSs typically implement:
* Creating / altering / deleting tables and relationships between them (database schema)
* Adding, changing, deleting, searching and retrieving of data stored in the tables
* Support for the SQL language
* Transaction management (optional)

### 3.Define what is "table" in database terms.
A table is a collection of related data held in a structured format within a database. It consists of fields (columns), and rows.

In relational databases and flat file databases, a table is a set of data elements (values) using a model of vertical columns (identifiable by name) and horizontal rows, the cell being the unit where a row and column intersect. A table has a specified number of columns, but can have any number of rows. Each row is identified by one or more values appearing in a particular column subset. The columns subset which uniquely identifies a row is called the primary key.

"Table" is another term for "relation"; although there is the difference in that a table is usually a multiset (bag) of rows where a relation is a set and does not allow duplicates. Besides the actual data rows, tables generally have associated with them some metadata, such as constraints on the table or on the values within particular columns.

### 4.Explain the difference between a primary and a foreign key.
* Primary key uniquely identify a record in the table. - Foreign key is a field in the table that is primary key in another table.
* Primary Key can't accept null values. - Foreign key can accept multiple null value.
* By default, Primary key is clustered index and data in the database table is physically organized in the sequence of clustered index. - Foreign key do not automatically create an index, clustered or non-clustered. You can manually create an index on foreign key.
* We can have only one Primary key in a table. - We can have more than one foreign key in a table.

### 5.Explain the different kinds of relationships between tables in relational databases.
* **One-to-one**: Both tables can have only one record on either side of the relationship. Each primary key value relates to only one (or no) record in the related table. They're like spouses—you may or may not be married, but if you are, both you and your spouse have only one spouse. Most one-to-one relationships are forced by business rules and don't flow naturally from the data. In the absence of such a rule, you can usually combine both tables into one table without breaking any normalization rules.
* **One-to-many**: The primary key table contains only one record that relates to none, one, or many records in the related table. This relationship is similar to the one between you and a parent. You have only one mother, but your mother may have several children.
* **Many-to-many**: Each record in both tables can relate to any number of records (or no records) in the other table. For instance, if you have several siblings, so do your siblings (have many siblings). Many-to-many relationships require a third table, known as an associate or linking table, because relational systems can't directly accommodate the relationship.

### 6.When is a certain database schema normalized? What are the advantages of normalized databases?
Normalization is done when there is duplicate and redundant data in the database. The main goal is to avoid data corruption.  Normalization is part of successful database design; without normalization, database systems can be inaccurate, slow, and inefficient, and they might not produce the data you expect.

A poorly normalized database and poorly normalized tables can cause problems ranging from excessive disk I/O and subsequent poor system performance to inaccurate data. An improperly normalized condition can result in extensive data redundancy, which puts a burden on all programs that modify the data.

From a business perspective, the expense of bad normalization is poorly operating systems and inaccurate, incorrect, or missing data. Applying normalization techniques to OLTP database design helps create efficient systems that produce accurate data and reliable information.

### 7.What are database integrity constraints and when are they used?
Integrity constraints are used to ensure accuracy and consistency of data in a relational database. Data integrity is handled in a relational database through the concept of referential integrity. Many types of integrity constraints play a role in referential integrity (RI).
#### Primary Key Constraints
Primary key is the term used to identify one or more columns in a table that make a row of data unique. Although the primary key typically consists of one column in a table, more than one column can comprise the primary key. For example, either the employee's Social Security number or an assigned employee identification number is the logical primary key for an employee table. The objective is for every record to have a unique primary key or value for the employee's identification number. Because there is probably no need to have more than one record for each employee in an employee table, the employee identification number makes a logical primary key. The primary key is assigned at table creation.
#### Unique Constraints
A unique column constraint in a table is similar to a primary key in that the value in that column for every row of data in the table must have a unique value. Although a primary key constraint is placed on one column, you can place a unique constraint on another column even though it is not actually for use as the primary key.
#### Foreign Key Constraints
A foreign key is a column in a child table that references a primary key in the parent table. A foreign key constraint is the main mechanism used to enforce referential integrity between tables in a relational database. A column defined as a foreign key is used to reference a column defined as a primary key in another table.
#### NOT NULL Constraints
Previous examples use the keywords NULL and NOT NULL listed on the same line as each column and after the data type. NOT NULL is a constraint that you can place on a table's column. This constraint disallows the entrance of NULL values into a column; in other words, data is required in a NOT NULL column for each row of data in the table. NULL is generally the default for a column if NOT NULL is not specified, allowing NULL values in a column.
#### Check Constraints
Check (CHK) constraints can be utilized to check the validity of data entered into particular table columns. Check constraints are used to provide back-end database edits, although edits are commonly found in the front-end application as well. General edits restrict values that can be entered into columns or objects, whether within the database itself or on a front-end application. The check constraint is a way of providing another protective layer for the data.

### 8.Point out the pros and cons of using indexes in a database.
**Advantages**: use an index for quick access to a database table specific information. The index is a structure of the database table the value of one or more columns to sort
As a general rule, only when the data in the index column Frequent queries, only need to create an index on the table. The index take up disk space and reduce to add, delete, and update the line speed. In most cases, the speed advantages of indexes for data retrieval greatly exceeds it. 

**Disadvantages**: too index will affect the speed of update and insert, because it requires the same update each index file. For a frequently updated and inserted into the table, there is no need for a rarely used where the words indexed separately, small table, the cost of sorting will not be great, there is no need to create additional indexes. In some cases, the indexing words may not be fast, for example, the index is placed in a contiguous memory space, which will increase the burden of disk read, which is optimal, it should be through the actual use of the environment to be tested.

### 9.What's the main purpose of the SQL language?
SQL allows users to access data stored in a relational database management system. Users can create and delete databases, as well as set permissions on database tables, views and procedures. It also allows users to manipulate the data within a database.

In SQL, there are two main sets of commands that are used to create and modify databases. These are the Data Definition Language and the Data Manipulation Language. The former contains commands used to develop and delete databases and its objects, and the latter contains commands used to insert, modify and delete data stored in a database.

SQL language is divided into several elements: clauses, expressions, predicates, queries and statements. SQL queries are the most essential and common SQL operations. An SQL query helps users retrieve needed data from a database, and it is executed using the ‘Select’ statement.

### 10.What are transactions used for?
A transaction symbolizes a unit of work performed within a database management system (or similar system) against a database, and treated in a coherent and reliable way independent of other transactions. A transaction generally represents any change in database. Transactions in a database environment have two main purposes:

* To provide reliable units of work that allow correct recovery from failures and keep a database consistent even in cases of system failure, when execution stops (completely or partially) and many operations upon a database remain uncompleted, with unclear status.
* To provide isolation between programs accessing a database concurrently. If this isolation is not provided, the programs' outcomes are possibly erroneous.
A database transaction, by definition, must be atomic, consistent, isolated and durable.[1] Database practitioners often refer to these properties of database transactions using the acronym ACID.

Transactions provide an "all-or-nothing" proposition, stating that each work-unit performed in a database must either complete in its entirety or have no effect whatsoever. Further, the system must isolate each transaction from other transactions, results must conform to existing constraints in the database, and transactions that complete successfully must get written to durable storage.

Examples from double-entry accounting systems often illustrate the concept of transactions. In double-entry accounting every debit requires the recording of an associated credit. If one writes a check for $100 to buy groceries, a transactional double-entry accounting system must record the following two entries to cover the single transaction:

* Debit $100 to Groceries Expense Account
* Credit $100 to Checking Account
* 
A transactional system would make both entries pass or both entries would fail. By treating the recording of multiple entries as an atomic transactional unit of work the system maintains the integrity of the data recorded. In other words, nobody ends up with a situation in which a debit is recorded but no associated credit is recorded, or vice versa.

### 11.What is a NoSQL database?
NoSQL encompasses a wide variety of different database technologies that were developed in response to a rise in the volume of data stored about users, objects and products, the frequency in which this data is accessed, and performance and processing needs. Relational databases, on the other hand, were not designed to cope with the scale and agility challenges that face modern applications, nor were they built to take advantage of the cheap storage and processing power available today.

### 12.Explain the classical non-relational data models.
* **Document databases** pair each key with a complex data structure known as a document. Documents can contain many different key-value pairs, or key-array pairs, or even nested documents.
* **Graph stores** are used to store information about networks, such as social connections. Graph stores include Neo4J and HyperGraphDB.
* **Key-value stores** are the simplest NoSQL databases. Every single item in the database is stored as an attribute name (or "key"), together with its value. Examples of key-value stores are Riak and Voldemort. Some key-value stores, such as Redis, allow each value to have a type, such as "integer", which adds functionality.
* **Wide-column stores** such as Cassandra and HBase are optimized for queries over large datasets, and store columns of data together, instead of rows.

### 13.Give few examples of NoSQL databases and their pros and cons.
* **Column**: Accumulo, Cassandra, Druid, HBase, Vertica
* **Document**: Clusterpoint, Apache CouchDB, Couchbase, DocumentDB, HyperDex, Lotus Notes, MarkLogic, MongoDB, OrientDB, Qizx
* **Key-value**: CouchDB, Oracle NoSQL Database, Dynamo, FoundationDB, HyperDex, MemcacheDB, Redis, Riak, FairCom c-treeACE, Aerospike, OrientDB, MUMPS
* **Graph**: Allegro, Neo4J, InfiniteGraph, OrientDB, Virtuoso, Stardog

![NoSQL DBs pros and cons](db_pros&cons.png)