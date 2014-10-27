using System.Data;

using NHibernate;

using Northwind.Core.Domain;
using Northwind.Write.Commands;

namespace Northwind.Write.CommandHandlers
{
    public class ChangeCategoryCommandHandler : ICommandHandler<ChangeCategoryCommand>
    {
        private readonly ISession session;

        public ChangeCategoryCommandHandler(ISession session)
        {
            this.session = session;
        }

        public void Handle(ChangeCategoryCommand command)
        {
            using (var tx = this.session.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                var category = this.session.Get<Category>(command.Id);
                category.ChangeName(command.Name);
                category.ChangeDescription(command.Description);

                tx.Commit();
            }
        }
    }
}
