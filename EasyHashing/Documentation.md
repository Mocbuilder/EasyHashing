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
But even something like an email address or a randomly genereated string/byte[] is ok, as long as its unique and can be permanently assigned to the password/data. 

The salt is passed on together with the password in the .EncryptPassword() function


```
string examplePassword = "IAmAPassword";
string username = "user";

EncryptedPassword encryptedExample = new EncryptedPassword();

encryptedExample.EncryptPassword(examplePassword, username);
```

Now your ```encryptedExample``` has a property called Hash (```encryptedExample.Hash```) which holds a byte-array.