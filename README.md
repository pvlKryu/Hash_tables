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
Each class implements similar functions for performing basic operations with hash tables:
  private int Divide (int item) - hash function of division. In this case (the division method) returns the remainder of dividing the hashing field (route number) by 48 and adds one. The resulting number will be the hash key (address)
  public void Add (Track item) - the function of adding an item to the hash table. Calls the Divide function and the resulting new hash key adds a list to the end of the structure (an object of the Divide_Hash class)
  public int Search (int item) - the function of searching for an item in the hash table. First, it finds the elements of the hash table by the hash key (Spanish: Divide), then it searches for an element in the list, since collision phenomena are possible. When you search in a list, the item you are looking for is compared with each item in the list.
  public bool Delete (int item) - function for deleting an item in a hash table. First, it finds the elements of the hash table by the hash key (Spanish: Divide), then it searches for an element in the list, since collision phenomena are possible. After finding, the property of removing the list from the structure is used.
  public void Display () - function of formal display of all elements of the hash table. If the condition is met (the list items are not empty), then the hash table number is highlighted in green. Empty cells are not highlighted.
Item class - describes the element of the hash table, represented by a linked list (used by the class in C # LinkedList). Contains a linked list and a constructor.
Track class - is a class that describes the record and its fields, namely “Destination A”, “Destination B” and “Route number”. The class contains the following functions:
  public Track (int payer, int payee, int money) - sets the values ​​of the class fields using function overloading.
  public void Show () - formal display of class object fields.
  public static void Fill (Track [] arr) - generates class field values ​​and calls the Track function to assign them.
