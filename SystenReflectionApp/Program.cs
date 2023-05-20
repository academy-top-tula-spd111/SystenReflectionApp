using System.Reflection;
using SystenReflectionApp;

Person person = new("Bob", 32);

Type myType = person.GetType();
Console.WriteLine(myType);

Console.WriteLine($"Name: {myType.Name}");
Console.WriteLine($"Full Name: {myType.FullName}");
Console.WriteLine($"Namespace: {myType.Namespace}");
Console.WriteLine($"Is struct: {myType.IsValueType}");
Console.WriteLine($"Is class: {myType.IsClass}");

Console.WriteLine("\nMembers:");
foreach (var t in myType.GetMembers(BindingFlags.Instance | BindingFlags.NonPublic))
    Console.WriteLine($"\t{t.MemberType} {t.DeclaringType} {t.Name}");

Console.WriteLine("\nIntefaces:");
foreach (var t in myType.GetInterfaces())
    Console.WriteLine($"\t{t.Name}");

Console.WriteLine("\nMethods");
foreach(var t in myType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
{
    string str = $"{t.Name}: ";
    str += t.IsConstructor ? " construct" : " non construct";
    str += t.IsVirtual ? " virtual" : " non virtual";
    str += t.IsPublic ? " public" : "";
    str += t.IsPrivate ? " private" : "";

    Console.WriteLine($"\t{str}");

    foreach(var p in t.GetParameters())
    {
        string pstr = $"{p.Name}: ";
        pstr += p.ParameterType.Name;
        pstr += p.IsOut ? " Out" : "";
        pstr += p.IsIn ? " In" : "";

        Console.WriteLine($"\t\t{pstr}");
    }
    if(t.GetParameters().Length == 0)
    {
        t?.Invoke(person, parameters: null);
    }
        
}
    

Console.WriteLine("\nMethods Print");
foreach (var t in myType.GetMember("Print", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic ))
    Console.WriteLine($"\t{t.Name}");


