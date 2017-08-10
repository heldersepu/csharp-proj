using System;

abstract class Parent<T> {
    public T Put(T id, char value) {
        return id;
    }
}

class Child : Parent<int> {
    public string Get(Guid guid) {
        return "aei";
    }
}

class Program {
    static void Main(string[] args) {
        foreach (var methodInfo in typeof(Parent<int>).GetMethods()) {
            if (!methodInfo.IsVirtual && methodInfo.GetParameters().Length > 0) {
                Console.WriteLine(methodInfo.Name);
                foreach (var param in methodInfo.GetParameters()) {
                    Console.Write("  " + param.Name + " IsGenericType=");
                    Console.WriteLine(param.ParameterType.IsGenericType);
                }
            }
        }
        Console.ReadKey();
    }
}
