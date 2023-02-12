

Department dep1 = new Department(0, "Информационные технологии");
Department dep2 = new Department(1, "Отдел кадров");
Department dep3 = new Department(2, "Бухгалтерия");
Console.WriteLine(dep1);
Console.WriteLine(dep2);
Console.WriteLine(dep3);

Worker worker1 = new Worker(0, 2, 23, "Мария Ивановна", 1234);
Worker worker2 = new Worker(1, 0, 26, "Мария Степановна", 3456);
Worker worker3 = new Worker(2, 2, 33, "Василий Петрович", 5432);
Worker worker4 = new Worker(3, 0, 33, "Игнат Петрович", 5432);

Console.WriteLine(worker1);
Console.WriteLine(worker2);
Console.WriteLine(worker3);
Console.WriteLine(worker4);

DataBase db = new();

db.append_dep(dep1);
db.append_dep(dep2);
db.append_dep(dep3);

db.append_worker(worker1);
db.append_worker(worker2);
db.append_worker(worker3);
db.append_worker(worker4);

Console.WriteLine(db.select_all_dep());
Console.WriteLine();
Console.WriteLine(db.select_all_worker());
Console.WriteLine();
Console.WriteLine(string.Join(", ", db.report()));
