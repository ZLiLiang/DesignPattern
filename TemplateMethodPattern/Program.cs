﻿using TemplateMethodPattern;

//组装HP电脑
Console.WriteLine("开始组织Hp电脑:");
AssembleComputer assembleHpComputer = new AssembleHpComputer();
assembleHpComputer.Assemble();

Console.WriteLine("================================");

//组装DELL电脑
Console.WriteLine("开始组织DELL电脑:");
AssembleComputer assembleDellComputer = new AssembleDellComputer();
assembleDellComputer.Assemble();

Console.ReadLine();