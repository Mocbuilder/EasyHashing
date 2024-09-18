# EasyHashing
EasyHashing is a nuget package that helps you with encrypting and hashing your data (currently supports only text/string data).
It has two "modes" or ways to be used. In this documentation, "password" is used for the data that is to be encrypted, as it its a common use-case. What is meant is any string of characters or byte arrays. The same goes for the "username" as salt. Both are detailed below:

## 1. Using the EncryptedPassword class
The faster and easier way to use EH is with the EncryptedPassword class. For each unique password/string you create an EncryptedPassword instance.
For Example:
```
string examplePassword = "IAmAPassword";

EncryptedPassword encryptedExamplePw = new EncryptedPassword();
```
To now encrypt your plaintext ```examplePassword```, you just need to call .EncryptPassword() on your EncryptedPasswordd instance and pass on your plaintext password. 
Also, you need some salt. 

Salt is some data/text that you most of the time can store less securely (e.g. a username). 
But even something like an email address or a randomly genereated string/byte array is ok, as long as its unique and can be permanently assigned to the password/data. 

The salt is passed on together with the password in the .EncryptPassword() function


```
string examplePassword = "IAmAPassword";
string username = "user";

EncryptedPassword encryptedExample = new EncryptedPassword();

encryptedExample.EncryptPassword(examplePassword, username);
```

Now your ```encryptedExample``` has a property called Hash (```encryptedExample.Hash```) which holds a byte-array.
The Hash can be stored in your DB, or whatever you want to do with your encrypted data, and can not be directly decrypted. For that you have to use ```.CheckPassword()``` function.
This function compares to byte array to check if they are the same. So, to check if e.g. a user has entered the correct password,
you would encrypt the newly entered password with the same salt as the original one (thats why its got to be unique and identifiable).
The new byte array can than be compared with the function, which returns a bool if the password is correct.
```
//Encrypt the newly entered password to get the byte array
string secondExample = "IAmANewlyEnteredPassword"

EncryptedPassword enteredPassword = new EncryptedPassword();
enteredPassword.EncryptPassword(secondExample, username);

Console.WriteLine("Is your entered Password correct: " + encryptedExample.CheckPassword(enteredPassword));
//This example will return false, because the passwords dont match (IAmAPassword vs IAmANewlyEnteredPassword)
```

## 2. Manual Encryption and Hashing
This method is for more experienced Users and all who want to seperate the byte array creation, encrypting and hashing.
To´provide these options, EasyHashing provides the EHService class, which contains all the methods that you need. 
Below they are all explained in the order that you would need them for the upper example to work.

#### 1. ToByte()
```.ToByte()``` takes one OR two strings and puts them in one byte array. 

#### 2. .GenerateSaltedHash()
```.GenerateSaltedHash()``` takes two byte arrays, first the password and then the salt and returns one hashed and encrpted byte array.

#### 3. .CompareByteArrays()
```.CompareByteArrays()``` takes two byte arrays and compares if they are identical and returns a bool. If this is true, it means that the same string(s) are the basis of them, if the same algorithm for hashing and encryting was used. Practicaly you can hash and encrypt the user-entered password to them compare it to the hash that you have stored. If they are the same, the passwords match.

#### Example:
An example of the one- and two-string-salt methods.
```
//Example for one string, typical Pw/Un combination
string username = "User1"
string password = "pw1"

EHSerive ehs = new EHService();

byte[] salt = ehs.ToByte[username];
byte[] pwAsByte = ehs.ToByte[password]

//Get byte arrays for password and salt, then generate the hash

byte[] Hash = ehs.GenerateSaltedHash(pwAsByte, salt);

//Example for two strings, e.g. Pw and Un/Email for the salt, which can make it more secure
string username = "User1"
string password = "pw1"
string email = "user1@example.com"

EHSerive ehs = new EHService();

byte[] salt = ehs.ToByte(username, email);
byte[] pwAsByte = ehs.ToByte(password)

//Get byte arrays, with salt being a combination of Un/Email.
//Continue like above
```


