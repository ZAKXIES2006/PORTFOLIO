my sReflection on Inheritance

Inheritance nhertiance reduces duplicated code because common properties and methods can be placed in the BankAccount base class instead of being written separately in SavingsAccount and CheckingAccount. For example, Owner, Balance, Deposit(), and the basic withdrawal functionality are shared by both account types. The subclasses automatically inherit these features from BankAccount.

Each subclass has its own additional responsibilities. SavingsAccount is responsible for storing an interest rate and applying interest to the balance. CheckingAccount is responsible for storing a transaction fee and deducting that fee whenever a withdrawal is made.

Using inheritance makethe code more organised because common functionality is kept in the base class, while accountspecific functionality is kept in the appropriate subclass. It also makes the program easier to maintain because changes to shared functionality only need to be made in BankAccount.