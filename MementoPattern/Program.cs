﻿using System.Globalization;
using MementoPattern;

Console.WriteLine("======备忘录模式======");

List<ContactPerson> persons = [new("张三", "13513757890"), new("李四", "18563252369"), new("王二", "17825635486")];

Mobile mobile = new Mobile(persons);

mobile.DisplayPhoneBook();

//备份通讯录
Console.WriteLine("===通讯录已备份===");
Caretaker caretaker = new Caretaker();
string key = DateTime.Now.ToString(CultureInfo.InvariantCulture);
caretaker.ContactMementoes.Add(DateTime.Now.ToString(CultureInfo.InvariantCulture), mobile.CreateMemento());
Console.WriteLine($"==={key}：通讯录已备份===");

//移除第一个联系人
Console.WriteLine("----移除联系人----");
mobile.GetPhoneBook().RemoveAt(0);
mobile.DisplayPhoneBook();

Thread.Sleep(1000);
string key2 = DateTime.Now.ToString(CultureInfo.InvariantCulture);
caretaker.ContactMementoes.Add(DateTime.Now.ToString(CultureInfo.InvariantCulture), mobile.CreateMemento());
Console.WriteLine($"==={key2}：通讯录已备份===");

//再移除一个联系人
Console.WriteLine("----移除联系人----");
mobile.GetPhoneBook().RemoveAt(0);
mobile.DisplayPhoneBook();

//恢复通讯录
Console.WriteLine($"----恢复到最后一次通讯录备份：{caretaker.ContactMementoes.LastOrDefault().Key}----");
mobile.RestoreMemento(caretaker.ContactMementoes.LastOrDefault().Value);

mobile.DisplayPhoneBook();

Console.ReadLine();