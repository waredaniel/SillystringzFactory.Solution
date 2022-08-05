using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.JoinEntities = new HashSet<EngineerMachine>();
    }

    public int EngineerId { get; set; }
    public string EngineerName { get; set; }
    [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime EngineerLicenseExpDate { get; set; }
    public int EngineerAccidentCount { get; set; }

    public virtual ICollection<EngineerMachine> JoinEntities { get; set; }
  }
}