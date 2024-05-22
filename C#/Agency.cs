using System.ComponentModel.DataAnnotations.Schema;

namespace C_
{
    public class Agency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }

        [ForeignKey("AgencyId")]
        public virtual List<Tour> Tours { get; set; }
    }
}
