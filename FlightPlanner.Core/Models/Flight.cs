using System.ComponentModel.DataAnnotations.Schema;

namespace FlightPlanner.Core.Models
{
    public class Flight : Entity
    {
        [ForeignKey(nameof(FromId))]
        public virtual Airport From { get; set; }
        [ForeignKey(nameof(ToId))]
        public virtual Airport To { get; set; }
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        [Column("From_Id")]
        public int? FromId { get; set; }
        [Column("To_Id")]
        public int? ToId { get; set; }

        public Flight(Airport from, Airport to, string carrier, string departureTime, string arrivalTime)
        {
            From = from;
            To = to;
            Carrier = carrier;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
        }

        public Flight()
        {

        }
    }
}