using NHibernate;

using Northwind.Core.Domain;
using Northwind.Core.Write.Commands;

namespace Northwind.Core.Write.CommandHandlers
{
    public class ChangeProductNameCommandHandler : ICommandHandler<ChangeProductNameCommand>
    {
        private readonly ISession session;

        public ChangeProductNameCommandHandler(ISession session)
        {
            this.session = session;
        }

        public void Handle(ChangeProductNameCommand command)
        {
            using (var tx = this.session.BeginTransaction())
            {
                var product = this.session.Get<Product>(command.Id);
                product.ChangeName(command.Name);

                tx.Commit();
            }
        }
    }
}
