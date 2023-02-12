class Department
{
  public int id;
  public string title;

  public Department(int id, string title)
  {
    this.id = id;
    this.title = title;
  }

  public override string ToString()
  {
    return $"title: {this.title}  id: {this.id}";
  }

}