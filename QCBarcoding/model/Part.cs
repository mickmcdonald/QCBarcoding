using System;
using SQLite;

namespace QCBarcoding.model
{
  [Table("OS_Part")]
  public class Part
  {
   [PrimaryKey, AutoIncrement, Column("_id")]
    public int Id { get; set; }
    public int PartId { get; set; }
    [MaxLength(50)]
    public string PartNo {get; set; }
    public string InspectionDate {get; set; }
    public string SerialNo {get; set; }
    public string LotNo {get; set; }
    public string ManufactureDate {get; set; }
    public int ContainerQuantity {get; set; }
    public string DateCreated { get; set; }
  }
}