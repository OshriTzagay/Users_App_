using Users_App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

User AUser = new User();
AUser.FirstName = "Leo";
AUser.LastName = "Messi";
AUser.Email = "LM@Gmail.com";
AUser.BirthYear = 1989;

Student AStudent = new Student("Shimi", "Shimoney", "SShmoney@gmail.com", 2000, "Yud-Alef");
//Console.WriteLine(AStudent.printStudInfo());
List<User> list = new List<User>();


void AddUser(List<User> list)
{
    try
    {
        Console.WriteLine("FName:");
        string FName = Console.ReadLine();
        Console.WriteLine("LName:");
        string LName = Console.ReadLine();
        Console.WriteLine("Email:");
        string Email = Console.ReadLine();
        Console.WriteLine("Birth:");
        int Birth = int.Parse(Console.ReadLine());

        User user = new User(FName, LName, Email, Birth);
        list.Add(user);
        SaveFile(user);


    }

    catch (FormatException)
    {
        Console.WriteLine("Wrong Format Bro");
    }
    catch (ArgumentException)
    {
        Console.WriteLine("Arguement Ex Detected!");
    }
    catch (Exception)
    {
        Console.WriteLine("->Exception<-");
    }


}

//----------> not on the same go w// the task . <----------
//void ReadFile(string Name)
//{

//    FileStream fileStream = new FileStream($@"c:\Test\UsersApp\{Name}.txt", FileMode.Open);
//    using (StreamReader sr = new StreamReader(fileStream))
//    {
//        Console.WriteLine(sr.ReadToEnd());
//    }

//}


void SaveFile(User obj)
{
    try
    {

        FileStream myFile = new FileStream($@"c:\Test\UsersApp\{obj.FirstName} {obj.LastName}.txt", FileMode.Create);
        using (StreamWriter sw = new StreamWriter(myFile))
        {
            sw.WriteLine($"{obj.FirstName} , {obj.LastName}, {obj.Email} , {obj.BirthYear}");
        }
        SaveListToFile(obj);

    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("--->FNF Exception<---");
    }
    catch (ArgumentException)
    {
        Console.WriteLine("---->Argu Exception---");
    }
    catch (Exception)
    {
        Console.WriteLine("Some Exception has been Found , Try Again.");
    }
}


void Menu(List<User> list)
{
    Console.WriteLine("Hello , This is Our User App Menu !");
    Console.WriteLine("For Add User Press [[1]]");
    Console.WriteLine("For Edit User Press [[2]]");
    Console.WriteLine("For Delete User Press [[3]]");
    Console.WriteLine("For Show Specific User Info - Press [[4]]");
    Console.WriteLine("For Exit Menu[[5]]");

    int pick = int.Parse(Console.ReadLine());

    switch (pick)
    {
        case 1:
            AddUser(list);
            Menu(list);
            break;
        case 2:
            EditUserFile();
            break;
        case 3:
            DelUser(list);
            Menu(list);
            break;
        case 4:
            //Get userFrom File -->
            GetUserFromFile();

            //Get userFrom List -->
            //GetUser(list);
            Menu(list);
            break;
        case 5:
            Console.WriteLine("Bye");
            break;
    }
}
Menu(list);



void DelUser(List<User> list)
{
    try
    {
        Console.WriteLine("Gimmie Yo Full - Name !");
        string userFName = Console.ReadLine();
        File.Delete($@"c:\Test\UsersApp\{userFName}.txt");
    }
    catch (FormatException)
    {
        Console.WriteLine("__________Format Exception Bro_________");
    }
    catch (ArgumentException)
    {
        Console.WriteLine("__________Argu Exception Bro_________");
    }
    catch (Exception)
    {
        Console.WriteLine("Some Exception has been Found , Try Again.");
    }
    //Remove From List . less optional -->

    //foreach (User user in list)
    //{
    //    if (userFName == $"{user.FirstName}")
    //    {
    //        Console.WriteLine($"{user.FirstName},{user.LastName} Has Been Deleted. Bye!");

    //        list.Remove(user);
    //    }

    //}
}


//Get User From File -->

void GetUserFromFile()
{
    try
    {
        Console.WriteLine("Gimmie Name ex: Oshri_Tzagay");
        string FName = Console.ReadLine();
        FileStream fileStream = new FileStream($@"c:\Test\UsersApp\{FName}.txt", FileMode.Open);
        using (StreamReader sr = new StreamReader(fileStream))
        {
            Console.WriteLine(sr.ReadToEnd());
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("_____This is Format-Ex____");
    }
    catch (ArgumentException)
    {
        Console.WriteLine("Argu Exception");
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("FNF Exception.");
    }

}

/// ---> Get User From List --->
/// 

//void GetUser(List<User> list)
//{
//    try
//    {
//        Console.WriteLine("Gimmie First Name !");
//        string FName = Console.ReadLine();

//        foreach (User user in list)
//        {
//            if (FName == user.FirstName)
//            {
//                Console.WriteLine($"{user.FirstName},{user.LastName},{user.Email} ,{user.BirthYear}");
//            }
//        }
//    }


//    catch (FormatException)
//    {
//        Console.WriteLine("Worng Format bruh..");

//    }
//}


void SaveListToFile(User user)
{
    //foreach (User user in somList)
    //{
    FileStream fileStream = new FileStream($@"c:\Test\UsersApp\AllUsers.txt", FileMode.Append);
    using (StreamWriter sw = new StreamWriter(fileStream))
    {
        sw.WriteLine($"{user.FirstName},{user.LastName},{user.Email}.");
    }

    //}
}

void EditUserFile()
{
    Console.WriteLine("which User u want to Edit  ?");
    string fullName = Console.ReadLine();

    Console.WriteLine("Gimmie A first name ?");
    string fName = Console.ReadLine();

    Console.WriteLine("Gimmie A last name ?");
    string lastName = Console.ReadLine();
    Console.WriteLine("Gimmie A Email ?");
    string email = Console.ReadLine();

    Console.WriteLine("Birth Year ?");
    int birthYear = int.Parse(Console.ReadLine());

    FileStream fileStream = new FileStream($@"c:\Test\UsersApp\{fullName}.txt", FileMode.Create);
    using (StreamWriter sw = new StreamWriter(fileStream))
    {
        sw.WriteLine($"{fName},{lastName},{email}.");
    }
    Console.WriteLine($" Edited User : {fName} , Last Name : {lastName}, Email : {email}");

}
