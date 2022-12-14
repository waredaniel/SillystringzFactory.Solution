using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.JoinEntities = new HashSet<EngineerMachine>();
    }

    public int MachineId { get; set; }
    public string MachineName { get; set; }
    public string MachineLocation { get; set; }
    public string MachineStatus { get; set; }

    public virtual ICollection<EngineerMachine> JoinEntities { get; }
  }
}