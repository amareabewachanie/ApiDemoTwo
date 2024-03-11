
namespace Entities.Models
{
    public class Marriage
    {
        public int Id { get; set; }
       
       
        public int HusbandId { get; set; }
        public int WifeId { get; set; }
        public DateTime MariageDate { get; set; }
       
        public  Birth Husband { get; set; }
       
        public  Birth Wife { get; set; }
    }
}
