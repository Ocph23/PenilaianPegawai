using Microsoft.Owin;

namespace PenilaianPegawaiWeb.Models
{
    public class IdentityDbContext<T>
    {
        private string v;
        private bool throwIfV1Schema;

        public IdentityDbContext(string v, bool throwIfV1Schema)
        {
            this.v = v;
            this.throwIfV1Schema = throwIfV1Schema;
        }
    }
}