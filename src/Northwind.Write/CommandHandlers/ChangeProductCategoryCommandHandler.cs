using System.Data;

using NHibernate;

using Northwind.Core.Domain;
using Northwind.Write.Commands;

namespace Northwind.Write.CommandHandlers
{
    public class ChangeProductCategoryCommandHandler : ICommandHandler<ChangeProductCategoryCommand>
    {
        private readonly ISession session;

        public ChangeProductCategoryCommandHandler(ISession session)
        {
            this.session = session;
        }

        public void Handle(ChangeProductCategoryCommand command)
        {
            using (var tx = this.session.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                var product = this.session.Get<Product>(command.Id);
                var category = this.session.Get<Category>(command.CategoryId);

                product.ChangeCategory(category);

                tx.Commit();
            }
        }
    }
}
