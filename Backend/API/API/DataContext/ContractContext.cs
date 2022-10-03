using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.DataContext
{
    public class ContractContext : DbContext
    {
        // Chuỗi kết nối tới CSDL (MS SQL Server)
        private const string connectionString = @"Server= localhost; Database= DotNetPractice; Integrated Security=True;";

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ContractProduct> ContractProducts { get; set; }

        // Phương thức OnConfiguring gọi mỗi khi một đối tượng DbContext được tạo
        // Nạp chồng nó để thiết lập các cấu hình, như thiết lập chuỗi kết nối
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
