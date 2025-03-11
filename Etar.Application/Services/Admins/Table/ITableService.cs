using Etar.Application.Interfaces.Context;
using Etar.Application.Services.Admins.Table.Commands.AddTable;
using Etar.Application.Services.Admins.Table.Commands.RemoveTable;
using Etar.Application.Services.Admins.Table.Commands.UpdateTable;
using Etar.Application.Services.Admins.Table.Queries.GetTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.Table
{
    public interface ITableService
    {
        IAddTableService AddTableService { get; }
        IGetTablesService GetTablesService { get; }
        IRemoveTableService RemoveTableService { get; }
        IUpdateTableService UpdateTableService { get; }
    }

    public class TableService : ITableService
    {
        private readonly IDataBaseContext _context;

        public TableService(IDataBaseContext context)
        {
            _context = context;
        }

        private IAddTableService _addTable;
        public IAddTableService AddTableService
        {
            get
            {
                return _addTable = _addTable?? new AddTableService(_context);
            }
        }

        private IGetTablesService _getTables;
        public IGetTablesService GetTablesService
        {
            get
            {
                return _getTables = _getTables ?? new GetTablesService(_context);
            }
        }

        private IRemoveTableService _removeTable;
        public IRemoveTableService RemoveTableService
        {
            get
            {
                return _removeTable = _removeTable ?? new RemoveTableService(_context);
            }
        }

        private IUpdateTableService _updateTable;
        public IUpdateTableService  UpdateTableService
        {
            get
            {
                return _updateTable = _updateTable ?? new UpdateTableSrvice(_context);
            }
        }
    }
}
