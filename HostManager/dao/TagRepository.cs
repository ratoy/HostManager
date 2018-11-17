using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HostManager.dao
{
    class TagRepository
    {
        SQLiteOperation m_SqliteOpera = DbOperation.Instance.GetSqliteOpera();

        internal Tag FindByTagName(String tagName)
        {
            DataTable dt = m_SqliteOpera.Query("select * from tag where name='" + tagName + "'");

            Tag tag = null;
            foreach (DataRow dr in dt.Rows)
            {
                tag = DataRowToTag(dr);
                break;
            }
            return tag;
        }

        private Tag DataRowToTag(DataRow dr)
        {
            Tag tag = new Tag(Convert.ToInt32(dr["id"]), Convert.ToString(dr["name"]));

            return tag;
        }

        internal void Save(Tag tag)
        {
            Tag oldTag = FindByTagName(tag.Name);
            if (oldTag == null)
            {
                m_SqliteOpera.InsertData("insert into tag(name) values('" + tag.Name + "')");
            }
        }

        internal void DeleteByTagName(string tagName)
        {
            m_SqliteOpera.DeleteData("delete from tag where name='" + tagName + "'");
        }

        internal List<Tag> FindAll()
        {
            DataTable dt = m_SqliteOpera.Query("select * from tag order by name");

            List<Tag> tagList = new List<Tag>();
            foreach (DataRow dr in dt.Rows)
            {
                tagList.Add(DataRowToTag(dr));
            }
            return tagList;
        }

        internal void Save(List<Tag> NewTagList)
        {
            List<String> sqlList = new List<string>();
            foreach (Tag tag in NewTagList)
            {
                Tag oldTag = FindByTagName(tag.Name);
                if (oldTag == null)
                {
                    sqlList.Add("insert into tag(name) values('" + tag.Name + "')");
                }
            }

            m_SqliteOpera.BatProcess(sqlList);
        }
    }
}
