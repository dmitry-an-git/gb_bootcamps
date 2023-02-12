class DataBase
{
  List<Department> dep_table;
  List<Worker> worker_table;

  public DataBase()
  {
    this.dep_table = new();
    this.worker_table = new List<Worker>();
  }

  public void append_worker(Worker worker)
  {
    worker_table.Add(worker);
  }

  public void append_dep(Department department)
  {
    dep_table.Add(department);
  }

  public string select_all_dep()
  {
    string output = String.Empty;

    foreach (var item in dep_table)
    {
      output += $"{item.title}\n";
    }

    return output;
  }

  public string select_all_worker()
  {
    string output = String.Empty;

    foreach (var item in worker_table)
    {
      output += $"{item.fullName} {item.age}\n";
    }

    return output;
  }

  public List<(string, int, int)> report()
  {
    List<(string, int, int)> rep = new();
    foreach (var item in worker_table)
    {
      rep.Add((item.fullName, item.age, item.depId));
    }
    return rep;
  }
}