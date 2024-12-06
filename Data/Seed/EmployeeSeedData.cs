namespace PublishingHouse.DAL.Data.Seed
{
    public class EmployeeSeed
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }

        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public int PositionId { get; set; }
        public int ProductionId { get; set; }

        public string? UserId { get; set; }
    }

    public static class EmployeeSeedData
    {
        private static List<EmployeeSeed>? _employeeSeeds;

        public static List<EmployeeSeed> GetEmployeeSeeds()
        {
            if (_employeeSeeds != null)
                return _employeeSeeds;

            _employeeSeeds =
            [
                new EmployeeSeed
                {
                    EmployeeId = 1,
                    Name = "Alice Johnson",
                    UserName = "alice.johnson",
                    Email = "alice.johnson@example.com",
                    Password = "AlicePass123!",
                    PositionId = 1,
                    ProductionId = 1,
                },
                new EmployeeSeed
                {
                    EmployeeId = 2,
                    Name = "Bob Smith",
                    UserName = "bob.smith",
                    Email = "bob.smith@example.com",
                    Password = "BobPass123!",
                    PositionId = 2,
                    ProductionId = 1,
                },
                new EmployeeSeed
                {
                    EmployeeId = 3,
                    Name = "Carol Williams",
                    UserName = "carol.williams",
                    Email = "carol.williams@example.com",
                    Password = "CarolPass123!",
                    PositionId = 3,
                    ProductionId = 2,
                },
                new EmployeeSeed
                {
                    EmployeeId = 4,
                    Name = "David Brown",
                    UserName = "david.brown",
                    Email = "david.brown@example.com",
                    Password = "DavidPass123!",
                    PositionId = 4,
                    ProductionId = 2,
                },
                new EmployeeSeed
                {
                    EmployeeId = 5,
                    Name = "Emily Davis",
                    UserName = "emily.davis",
                    Email = "emily.davis@example.com",
                    Password = "EmilyPass123!",
                    PositionId = 5,
                    ProductionId = 3,
                },
                new EmployeeSeed
                {
                    EmployeeId = 6,
                    Name = "Frank Miller",
                    UserName = "frank.miller",
                    Email = "frank.miller@example.com",
                    Password = "FrankPass123!",
                    PositionId = 1,
                    ProductionId = 3,
                },
                new EmployeeSeed
                {
                    EmployeeId = 7,
                    Name = "Grace Wilson",
                    UserName = "grace.wilson",
                    Email = "grace.wilson@example.com",
                    Password = "GracePass123!",
                    PositionId = 2,
                    ProductionId = 4,
                },
                new EmployeeSeed
                {
                    EmployeeId = 8,
                    Name = "Henry Moore",
                    UserName = "henry.moore",
                    Email = "henry.moore@example.com",
                    Password = "HenryPass123!",
                    PositionId = 3,
                    ProductionId = 4,
                },
                new EmployeeSeed
                {
                    EmployeeId = 9,
                    Name = "Isabella Taylor",
                    UserName = "isabella.taylor",
                    Email = "isabella.taylor@example.com",
                    Password = "IsabellaPass123!",
                    PositionId = 4,
                    ProductionId = 5,
                },
                new EmployeeSeed
                {
                    EmployeeId = 10,
                    Name = "Jack Anderson",
                    UserName = "jack.anderson",
                    Email = "jack.anderson@example.com",
                    Password = "JackPass123!",
                    PositionId = 5,
                    ProductionId = 5,
                }
            ];

            return _employeeSeeds;
        }

        public static void UpdateEmployeeSeedUserIds(Dictionary<string, string> userIdMappings)
        {
            if (_employeeSeeds == null) return;

            foreach (var seed in _employeeSeeds)
            {
                if (userIdMappings.TryGetValue(seed.Email ?? string.Empty, out var newUserId))
                {
                    seed.UserId = newUserId;
                }
            }
        }
    }
}