# Hash_tables
Hash tables tutorial project

The main task:
Implement search using hashing:

A. Develop two hash functions, provide for collision handling. Hash functions and a method for resolving collisions to choose any of those specified in the theoretical part.

B. Hashed the input. Evaluate the implemented hash functions for the number of collisions in the original dataset and then use a hash function that minimizes collisions.

C. Based on the received hash values, build a hash table.

D. Implement Search, Add, Remove Items.

Input and output data:

The program accepts an array of records containing 25 elements as input. In this case, the input data for hashing is completely created in the body of the program in a separate procedure.

Functional description:

a. Data

The program works with the created Track data structure. It is used in a 25-element array of records, with fields for each record being randomly generated and populated.
The output is two hash tables, organized by division and mid-squares methods, which are color-coded with the element numbers of the tables. 
Tables are displayed in the console window (see Figure 1). Dialogue with the user is carried out in the same way using the console window.

b. Program structure

The program is implemented in the OOP C # language.

c. Functions and classes

Created two main classes to implement hashing functions:

  Divide_Hash - Class for implementing the division method
  
  Square_Hash - Class for implementing the mid-squares method
  
  
  

