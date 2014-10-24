using System.Data;

using NHibernate;

using Northwind.Core.Domain;
using Northwind.Core.Write.Commands;

namespace Northwind.Core.Write.CommandHandlers
{
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
    {
        private readonly ISession session;

        public CreateCategoryCommandHandler(ISession session)
        {
            this.session = session;
        }

        public void Handle(CreateCategoryCommand command)
        {
            using (var tx = this.session.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                var category = Category.Create(command.Name, command.Description);
                this.session.Save(category);
                tx.Commit();
            }
        }
    }
}
