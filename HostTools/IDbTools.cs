using System;
using System.Data;
using System.Collections.Generic;
namespace HostTools
{
    public interface IDbTools
    {
        string LastErrorMsg { get; }
        bool TestDB();
        DataTable Query(string QueryCmd);
        bool BatProcess(List<string> BatCmdList);
        bool InsertData(string InsertCmd);
        bool DeleteData(string DeleteCmd);
        bool UpdateData(string UpdateCmd);
        bool ExecuteSql(string SqlCmd);
        bool BakDb(Host FileServerHost);
        bool RecoverDb(Host FileServerHost);
    }
}