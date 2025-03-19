namespace nep_hrms.Server.nep_hrms.DAL;


public class Document
{
    public int Id { get; set; }
    public byte[] Content { get; set; } // VARBINARY(MAX)
    public string? Description { get; set; } // NVARCHAR(500)
    public string Type { get; set; } // NVARCHAR(255)
    public string CreatedBy { get; set; } // NVARCHAR(100)
    public DateTime? CreatedDt { get; set; } // DATETIME
    public string? UpdatedBy { get; set; } // NVARCHAR(100)
    public DateTime? UpdatedDt { get; set; } // DATETIME
    public bool? Active { get; set; } // BIT
}
