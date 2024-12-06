using PublishingHouse.Abstractions.Entity;
using System.ComponentModel.DataAnnotations;

namespace PublishingHouse.DAL.Model
{
    public partial class Employee : IEmployee
    {
        public int EmployeeId { get; set; }

        public int PositionId { get; set; }

        public int ProductionId { get; set; }

        public string? Name { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public string? UserId { get; set; }

        public virtual Position Position { get; set; } = null!;

        public virtual ICollection<PrintOrder> PrintOrders { get; set; } = (List<PrintOrder>)[];

        public virtual Production Production { get; set; } = null!;

        IPosition IEmployee.Position
        {
            get => Position;
            set => Position = (Position)value;
        }

        ICollection<IPrintOrder> IEmployee.PrintOrders
        {
            get => PrintOrders.Cast<IPrintOrder>().ToList();
            set => PrintOrders = value.Cast<PrintOrder>().ToList();
        }

        IProduction IEmployee.Production
        {
            get => Production;
            set => Production = (Production)value;
        }
    }
}
