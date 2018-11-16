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
            Tag tag = new Tag();
            tag.Id = Convert.ToInt32(dr["id"]);
            tag.Name = Convert.ToString(dr["name"]);

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
            DataTable dt = m_SqliteOpera.Query("select * from tag");

            List<Tag> tagList = new List<Tag>();
            foreach (DataRow dr in dt.Rows)
            {
                tagList.Add(DataRowToTag(dr));
            }
            return tagList;
        }
    }
}
