using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Reflection;

namespace HostTools
{
    public class DbOperation
    {
        IDbTools m_SqliteOpera = null;
        private static DbOperation mInstance;

        private DbOperation(IDbTools dbTools)
        {
            this.m_SqliteOpera = dbTools;
        }

        public IDbTools GetSqliteOpera()
        {
            return m_SqliteOpera;
        }

        public static DbOperation Instance
        {
            get
            {
                return mInstance;
            }
        }

        public static void Create(IDbTools dbTools)
        {
            if (mInstance != null)
            {
                return;
            }
            mInstance = new DbOperation(dbTools);
        }
    }

}
