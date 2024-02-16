using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace Pac_Man.abstractClasses
{
    public abstract class sqlBase
    {
        #region Vars & Objs

        SqlConnectionStringBuilder builder;

        protected string sSqlServer;
        protected string sSqlUser;
        protected string sSqlPassword;
        protected string sSqlCatalog;

        protected string sSqlTable;

        #endregion

        #region Costructors

        public sqlBase()
        {

        }

        public sqlBase(string sqlServer)
        {
            this.sSqlServer = @sqlServer;
            this.sSqlUser = @"sa";
            this.sSqlPassword = @"PASSWORD";
            this.sSqlCatalog = @"";

            builder = new SqlConnectionStringBuilder();
        }

        #endregion

        #region Methods

        protected void connectSql()
        {
            builder.DataSource = sSqlServer;
            builder.UserID = this.sSqlUser;
            builder.Password = this.sSqlPassword;
            builder.InitialCatalog = this.sSqlCatalog;
        }

        #endregion
    }
}
