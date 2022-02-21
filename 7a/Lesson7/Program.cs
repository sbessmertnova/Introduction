// Decompiled with JetBrains decompiler
// Type: Lesson7.Program
// Assembly: Lesson7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 65AAE19A-7C16-423B-8592-FF5A2FD43764
// Assembly location: C:\Users\minni\source\repos\Introduction\Lesson7\bin\Debug\net5.0\publish\Lesson7.dll

using System;

namespace Lesson7
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      string str = "123456";
      Console.WriteLine("Введите пароль");
      if (!(Console.ReadLine() == str))
        return;
      Console.WriteLine("Пароль верный");
    }
  }
}
