using System;
using SQLite;

namespace QCBarcoding.model
{
  [Table("OS_Job")]
  public class Job
  {
   [PrimaryKey, AutoIncrement, Column("_id")]
    public int Id { get; set; }
    public int JobId { get; set; }
    [MaxLength(50)]
    public string JobNo {get; set; }
    public string DateCreated { get; set; }
  }
}