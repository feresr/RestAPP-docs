using System.Data.Entity.ModelConfiguration;
using RestApp.Core.Domain.Banks;

namespace RestApp.Data.Mapping.Banks
{
    public class BankMap : EntityTypeConfiguration<Bank>
    {
        public BankMap()
        {
            this.ToTable("Bank");
            this.HasKey(t => t.Id);

            this.Property(t => t.Code).IsRequired();
            this.Property(t => t.Name).IsRequired();
            this.Property(t => t.Account).IsRequired();
        }
    }
}
